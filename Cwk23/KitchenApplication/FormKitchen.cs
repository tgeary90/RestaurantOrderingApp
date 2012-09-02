using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KitchenApplication
{
    public partial class FormKitchen : Form
    {
        // For the SQL connection string, the computer name

        string myComputer = System.Environment.MachineName;

        SqlConnection kitchConn;
        SqlDataAdapter daPending = new SqlDataAdapter();
        
        DataSet dsPending;
        DataSet dsSent;

        string errorMsg;

        public FormKitchen()
        {
            InitializeComponent();

            kitchConn = new SqlConnection
                ("server=" + myComputer + @"\SQLExpress;Integrated Security=SSPI;database=KitchenDatabase");

            getPendingOrders();
        }

        void getPendingOrders()
        {
            StringBuilder strBldr = new StringBuilder();

            // fills DataSet with latest Orders (OrdersReceived = 'yes', OrderReady = 'no')
            // and binds it to the pendingOrders grid

            dsPending = new DataSet();     
            SqlCommand sqlCmd = new SqlCommand
                (@"SELECT OrderNo, Waiter, TimeOrdered, OrderReady FROM dbo.Orders WHERE OrderReady = 'no' AND OrderReceived = 'yes'",kitchConn);
            daPending.SelectCommand = sqlCmd;

            try
            {
                daPending.Fill(dsPending, "Orders");
            }
            catch (Exception ex)
            {
                errorMsg = strBldr.Append(ex.Message).ToString();
            } 
            dataGridViewOrdersPending.DataSource = dsPending.Tables["Orders"];
        }

        private void timerGetPendingOrders_Tick(object sender, EventArgs e)
        {
            // gets pending orders on a 10 second interval
            // and adds new pending orders to pending order listbox

            getPendingOrders();

            int i = 0;
            string strOrderNo;

            // initialize listbox of pending orders

            listBoxOrders.Items.Clear();
            
            // now populate the listbox

            while (i < dsPending.Tables["Orders"].Rows.Count)
            {
                strOrderNo = dsPending.Tables["Orders"].Rows[i]["OrderNo"].ToString();
                    listBoxOrders.Items.Add(strOrderNo);
                    i++;
            }
        }

        private void listBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            // allows chef to mark orders as ready (OrderReady = 'yes')

            if (listBoxOrders.Items.Count > 0)
                buttonOrderReady.Enabled = true;
        }

        private void buttonOrderReady_Click(object sender, EventArgs e)
        {
            // We have a DataSet from getPendingOrders() so
            // we can set the order as ready

            int orderNo = Convert.ToInt32(listBoxOrders.SelectedItem);

            foreach( DataRow dr in dsPending.Tables["Orders"].Rows)
            {
                if ((int)dr["OrderNo"] == orderNo)
                {
                    dr["OrderReady"] = "yes";
                    break;
                }
            }
            
            // Now we commit the update back to the data source

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = "UPDATE Orders SET OrderReady = 'yes' WHERE OrderNo = @OrderNo";
            sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
            daPending = new SqlDataAdapter(sqlCmd.CommandText, kitchConn);
            daPending.UpdateCommand = sqlCmd;
            daPending.UpdateCommand.Connection = kitchConn;
            daPending.Update(dsPending, "Orders");

            // But we also need to move the ready order over to the sent order datagrid view

            dsSent = new DataSet();
            sqlCmd.CommandText = @"SELECT TOP 10 OrderNo, Waiter, TimeOrdered, OrderReady FROM " + 
                "dbo.Orders WHERE OrderReady = 'yes' AND OrderReceived = 'yes' ORDER BY OrderNO DESC";
            SqlDataAdapter daSent = new SqlDataAdapter(sqlCmd.CommandText, kitchConn);
            daSent.SelectCommand = sqlCmd;
            daSent.Fill(dsSent, "Orders");
            dataGridViewOrdersSent.DataSource = dsSent.Tables["Orders"];
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            FormStatistics fs = new FormStatistics();
            fs.Activate();
            fs.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
