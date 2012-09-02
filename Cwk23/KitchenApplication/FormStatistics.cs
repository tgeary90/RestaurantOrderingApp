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
    public partial class FormStatistics : Form
    {
        string errorMsg;

        public FormStatistics()
        {
            InitializeComponent();
            populateDataSets();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void populateDataSets()
        {
            string myComputer = System.Environment.MachineName;

            SqlConnection statConn = new SqlConnection
                ("server=" + myComputer + @"\SQLExpress;Integrated Security=SSPI;database=KitchenDatabase");
            SqlDataAdapter daPopMeal = new SqlDataAdapter();
            SqlDataAdapter daPopTable = new SqlDataAdapter();
            SqlDataAdapter daOrderTimes = new SqlDataAdapter();
            SqlCommand sqlCmd;

            
            StringBuilder strBldr = new StringBuilder();

            // Now to fill the datasets

            // 1. Most popular meal

            DataSet dsPopMeal = new DataSet();     
            sqlCmd = new SqlCommand
            (@"SELECT MealType, SUM(MealPrice) AS ""£ per meal type"", COUNT(MealNo) AS ""Most Popular Meal"" FROM Meals GROUP BY MealType ORDER BY COUNT(MealNo) DESC", statConn);
            daPopMeal.SelectCommand = sqlCmd;

            try
            {
                daPopMeal.Fill(dsPopMeal, "Meals");
            }
            catch (Exception ex)
            {
                errorMsg = strBldr.Append(ex.Message).ToString();
            }

            dataGridViewPopMeal.DataSource = dsPopMeal.Tables["Meals"];

            // 2. Most popular table

            DataSet dsPopTable = new DataSet();
            sqlCmd = new SqlCommand
            (@"SELECT TableNo, COUNT(MealNo) AS ""Most Popular Table (Meals)"" FROM Meals GROUP BY TableNo ORDER BY COUNT(MealNo) DESC", statConn);

            daPopTable.SelectCommand = sqlCmd;
            try
            {
                daPopTable.Fill(dsPopTable, "Meals");
            }
            catch (Exception ex)
            {
                errorMsg = strBldr.Append(ex.Message).ToString();
            }

            dataGridViewPopTable.DataSource = dsPopTable.Tables["Meals"];

            // 3. Order Delivery Times

            DataSet dsOrderTimes = new DataSet();
            sqlCmd = new SqlCommand
            (@"SELECT OrderNo, DATEDIFF(second,TimeOrdered,TimeDelivered) AS ""Order Delivery Time (secs)"" FROM Orders", statConn);

            daOrderTimes.SelectCommand = sqlCmd;
            try
            {
                daOrderTimes.Fill(dsPopTable, "Orders");
            }
            catch (Exception ex)
            {
                errorMsg = strBldr.Append(ex.Message).ToString();
            }

            dataGridViewOrderTimes.DataSource = dsPopTable.Tables["Orders"];
        }

        private void buttonReturnToKitchen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            populateDataSets();
        }
    }
}
