using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Collections;
using System.IO;

namespace TabletApplication
{
    public partial class FormTablet : Form
    {
        // declare our local database objects

        SqlCeDataAdapter da;
        DataSet ds;
        SqlCeConnection conn;

        // declare our helper objects

        LocalDataProcessor ldp = null;
        WebServiceProcessor wsp = null;

        // declare our order processing objects

        Table[] tables = new Table[10];
        Table selectedTable = null;
        Seat selectedSeat = null;
        Order newOrder = null;
        List<int> readyOrdersNosList = new List<int>();
        StringBuilder readyTables;

        int nextMealNumber = 0;

        public FormTablet()
        {
            InitializeComponent();
            initObjects();
        }

        private void buttonStartOrder_Click(object sender, EventArgs e)
        {
            // trap door the event if mid-order

            if (selectedTable.OrderPlaced == true)
                return;

            // The selected table (table 0 if just started application)
            // has its seats enabled and colored green

            foreach (Seat s in selectedTable.seated)
            {
                s.Enabled = true;
                s.Image = Properties.Resources.Button_Blank_Green_icon;
            }

            // An order cannot be restarted halfway through...

            buttonStartOrder.Enabled = false;

            // raise a new order by pulling next available order no. from local db

            newOrder = new Order(ldp.getNextOrderNo(), selectedTable.TableNo, labelWaiter.Text);
            listBoxSummary.Items.Add("New Order raised by " + newOrder.Waiter);
        }

        private void buttonAssignWaiter_Click(object sender, EventArgs e)
        {
            // trapdoor if mid order

            if ((newOrder != null) || (textBoxWaiterName.Text.Length > 2))
                return;

            labelWaiter.Text = textBoxWaiterName.Text;
            buttonStartOrder.Enabled = true;
            buttonAssignWaiter.Enabled = false;
            tabControl1.Enabled = true;
            listBoxSummary.Items.Add("Waiter: " + labelWaiter.Text + " logged on");
        }

        private void listBoxMeals_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The point of this method is to assign a meal to an order.
            // To that end we trap door the event if the table has already ordered

            if ((selectedTable.OrderPlaced == true) || (selectedTable.ordered.Contains(selectedSeat)))
                return;

            // If not all diners at the table have ordered we add their meal

            // ordered = 2 or less

            if (selectedTable.ordered.Count < 3)
            {
                selectedTable.ordered.Add(selectedSeat);
                selectedTable.seated.Remove(selectedSeat);

                // ordered = 3 or less

                // when the listbox is selected a new meal is created with a mealtype 
                // corresponding to the index of the item in the listbox cast to enum, 
                // mealNo is incremented (to keep each meal unique)

                newOrder.addMealToOrder(new Meal((mealType)listBoxMeals.SelectedIndex, ++nextMealNumber));
                listBoxSummary.Items.Add("Meal added at table: " + selectedTable.TableNo);
                
                // finally all ordered seats are changed to yellow

                foreach (Seat s in selectedTable.ordered)
                {
                    s.Image = Properties.Resources.Button_Blank_Yellow_icon;
                }             
            }  

            else
            {
                selectedTable.ordered.Add(selectedSeat);
                selectedTable.seated.Remove(selectedSeat);

                // ordered = 4

                // when the listbox is selected a new meal is created with a mealtype 
                // corresponding to the index of the item in the listbox cast to enum, 
                // mealNo is incremented (to keep each meal unique)

                newOrder.addMealToOrder(new Meal((mealType)listBoxMeals.SelectedIndex, ++nextMealNumber));
                listBoxSummary.Items.Add("Meal added at table: " + selectedTable.TableNo);

                // finally the last ordered seat is changed to yellow
             
                selectedSeat.Image = Properties.Resources.Button_Blank_Yellow_icon;
                       
                buttonCompleteOrder.Enabled = true;
                listBoxMeals.Enabled = false;        
            }
        }

        private void initObjects()
        {
            // We create an object to manage all the local database interactions

            ldp = new LocalDataProcessor();
            wsp = new WebServiceProcessor();

            // Create 10 tables

            for (int i = 0; i < 10; i++)
            {
                tables[i] = new Table(i);
            }

            selectedTable = tables[0];

            // to handle seat color changes the table class has a 
            // an arraylist called 'seated' full of seat objects
            // they are added here

            foreach (Control ctrl in tabControl1.TabPages[0].Controls)
            {
                if (ctrl is Seat)
                {
                    if (selectedTable.seated.Count <= 4)
                        selectedTable.seated.Add((Seat)ctrl);
                }
            }

            // What meal is unavailable today? We read in the first
            // entry from a flat 'UnavailableMeals.txt' file here

            string getLocation = Directory.GetCurrentDirectory();

            FileStream fs = 
                new FileStream(getLocation + "\\UnavailableMeals.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string offMeals = sr.ReadLine();
            int offMealNo = int.Parse(offMeals.Substring(0,1));

            sr.Close();

            // write out the stream without the off meal

            fs = new FileStream(getLocation + "\\UnavailableMeals.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            
            sw.Write(offMeals.Substring(1));
            sw.Close();
            fs.Close();

            // and notify the user

            listBoxSummary.Items.Add(listBoxMeals.Items[offMealNo] + " is unavailable");

            // The meal must now be taken off the menu

            listBoxMeals.Items.RemoveAt(offMealNo);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Changing the tab (table) essentially assigns the selectedTable variable

            // trap door the event if we are midway through an order or if the table
            // has already ordered

            if (newOrder != null)
                return;

            selectedSeat = null;

            TabControl selectedTab = (TabControl)sender;

            selectedTable = tables[selectedTab.SelectedIndex];

            // trapdoor the event if the table has already ordered
            // this has to be done after the selectedTable var is
            // updated or a subtle bug is introduced

            if (selectedTable.OrderPlaced == true)
                return;

            // The selected table has its seats added to the 'seated' arraylist
            // for the table object. The seats are disabled in preparation 
            // for when the start new order button is hit          

            foreach (Control ctrl in tabControl1.SelectedTab.Controls)
            {
                if (ctrl is Seat)
                {
                    if (selectedTable.seated.Count < 4)
                    {
                        selectedTable.seated.Add((Seat)ctrl);
                        ctrl.Enabled = false;
                    }
                }
            }
            selectedTable.Waiter = labelWaiter.Text;

            // a new order may now be raised

            buttonStartOrder.Enabled = true;
        }

        private void seat_click(object sender, EventArgs e)
        {
            // A seat has been clicked so we can enable the menu

            listBoxMeals.Enabled = true;
            
            selectedSeat = (Seat)sender;

            // once a seat has ordered it is put on the ordered queue, a member of the table
            // class. We dont want to reorder for a seat so we test this selected seat
            // against each seat that has ordered. If it has ordered already we drop out of
            // the event handler

            foreach (Seat s in selectedTable.ordered)
            {
                if (selectedSeat.Equals(s))
                    return;
            }

            // repaint the seats in case a new seat has been selected

            foreach (Seat s in selectedTable.seated)
            {
                s.Image = Properties.Resources.Button_Blank_Green_icon;
            }

            // the selected seat is now colored blue

            selectedSeat.Image = Properties.Resources.Button_Blank_Blue_icon;
        }

        private void buttonCompleteOrder_Click(object sender, EventArgs e)
        {
            SqlCeCommandBuilder cmdb = new SqlCeCommandBuilder(da);
            string webServiceOutput;

            buttonCompleteOrder.Enabled = false;

            foreach (Seat s in selectedTable.ordered)
            {
                s.Enabled = false;
            }
            selectedTable.OrderPlaced = true;
            buttonStartOrder.Enabled = false;

            // insert into local database (TabletDatabase.sdf)

            ds = ldp.insertNewOrder(newOrder.OrderNo, newOrder.TableNo, ds);
            da.Update(ds, "Orders");

            // call web services

            // 1. Add order to KitchenDatabase.mdf

            webServiceOutput = wsp.sendOrder_local(newOrder.OrderNo, newOrder.Waiter);
            listBoxSummary.Items.Add(webServiceOutput);

            // 2. Add meals in the order to KitchenDatabase.mdf

            Meal[] meals = newOrder.getMeals();

            for (int i = 0; i < 4; i++)
            {
                wsp.sendMeal_local(meals[i].MealNo, (int)meals[i].Type, meals[i].Price, newOrder.OrderNo, (newOrder.TableNo));
            }

            listBoxSummary.Items.Add(webServiceOutput);
            listBoxSummary.Items.Add("Order placed with table: " + (selectedTable.TableNo));

            // The order has now been placed so clear newOrder and enable 
            // new orders to be made

            newOrder = null;
            buttonStartOrder.Enabled = true;
        }

        private void FormTablet_Load(object sender, EventArgs e)
        {
            try
            {
                string connString;
                connString = Properties.Settings.Default.TabletDatabaseConnectionString;
                conn = new SqlCeConnection(connString);
                da = new SqlCeDataAdapter("SELECT * from Orders", conn);
                ds = new DataSet();

                da.Fill(ds, "Orders");
                dataGridViewTableStatus.DataSource = ds.Tables["Orders"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            foreach (Control ctrl in Controls)
            {
                if (ctrl is Seat)
                {
                    Seat s = ctrl as Seat;
                    s.Enabled = false;
                }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string developer = "Tom Geary";
            MessageBox.Show(string.Format("Cwk2/3 by {0}", developer));
        }

        private void timerWebServiceGetReadyOrders_Tick(object sender, EventArgs e)
        {
            int readyTable;
            readyTables = new StringBuilder();
            

            // get the ready orders from the kitchen via web service call

            int[] readyOrderNos = wsp.getReadyOrders_local();

            // Update the Summary listbox

            if (readyOrderNos.Length > readyOrdersNosList.Count)
                listBoxSummary.Items.Add(readyOrderNos.Length + " Ready Orders");

            // the ready orders list is refreshed at each tick.

            readyOrdersNosList.Clear();

            // Now we process the ready orders

            for (int i = 0; i < readyOrderNos.Length; i++)
            {
                // new orders must be added to the ready orders list.
                // This appears clunky but is a workaround for not being
                // able to pass objects via web service. An array is used.
                // This must be copied to the list, which has global scope.

                readyOrdersNosList.Add(readyOrderNos[i]);

                // For each ready order we must set the 'complete order' button to true
                // This is ascertained from the tableNo via local db lookup

                readyTable = ldp.getTableForAnOrder(readyOrderNos[i]);
                foreach (Control ctrl in tabControl1.TabPages[readyTable].Controls)
                {
                    if (ctrl is Button) 
                    {
                        Button b = ctrl as Button;
                        if ((b.Tag).ToString() == "deliver")
                            ctrl.Enabled = true;
                    }
                }
                readyTables.Append(readyTable);
                labelTable.Text = readyTables.ToString();
            }        
        }

        private void deliver_click(object sender, EventArgs e)
        {
            // When the order is complete we mark it as 'received' locally
            
            SqlCeCommandBuilder cmdb = new SqlCeCommandBuilder(da);

            // delivered table number is:

            int deliveredTableNo = tabControl1.SelectedIndex;
            ds = ldp.markOrderReady(deliveredTableNo, ds);
            da.Update(ds, "Orders");

            // We iterate through each ready order and if its for our table
            // notify the kitchen and mark the seats delivered (red)

            for (int i = 0; i <= ds.Tables["Orders"].Rows.Count; i++ )
            {
                try
                {
                    DataRow dr = ds.Tables["Orders"].Rows[i];
                    if (readyOrdersNosList.Contains((int)dr["OrderNo"]))
                    {
                        // We have the order that matches the table.
                        // so update its status remotely to OrderDelivered = 'yes'
                        // via web service. The kitchen then knows it has been sent.

                        int deliveredOrderNo = (int)dr["OrderNo"];
                        wsp.updateOrder_local(deliveredOrderNo);
                        readyOrdersNosList.Remove(deliveredOrderNo);

                        foreach (Control ctrl in tabControl1.SelectedTab.Controls)
                        {
                            if (ctrl is Seat)
                            {
                                Seat s = ctrl as Seat;
                                s.Image = Properties.Resources.Button_Blank_Red_icon__1_;
                            }
                        }
                        Button b = (Button)sender;
                        b.Enabled = false;

                        readyTables.Replace(deliveredTableNo.ToString(), "");
                        labelTable.Text = readyTables.ToString();
                        listBoxSummary.Items.Add(deliveredOrderNo.ToString() + " delivered to table " + deliveredTableNo.ToString());
                        break;
                    }
                }
                catch(Exception ex)
                {
                    listBoxSummary.Items.Add("ERROR: " + ex.Message);
                    return;
                }               
            }

            // enable the table to be cleared

            foreach (Control ctrl in tabControl1.SelectedTab.Controls)
            {
                if (ctrl is Button)
                {
                    Button b = ctrl as Button;
                    if ((string)b.Tag == "clear")
                        ctrl.Enabled = true;
                }
            }
        }

        private void clearAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void FormTablet_FormClosed(object sender, FormClosedEventArgs e)
        {
            clearData();
        }

        void clearData()
        {
            try
            {
                timerWebServiceGetReadyOrders.Enabled = false;
                System.Threading.Thread.Sleep(2000);

                SqlCeCommandBuilder cmdb = new SqlCeCommandBuilder(da);
                ds = ldp.clearLocalDatabase(ds);
                da.Update(ds, "Orders");

                System.Threading.Thread.Sleep(2000);
                wsp.clearOrders_local();

                listBoxSummary.Items.Add("Databases clear");
                labelTable.Text = "";
                timerWebServiceGetReadyOrders.Enabled = true;
            }
            catch
            {
                Application.Exit();
            }

        }

        private void clearTable_Click(object sender, EventArgs e)
        {
            selectedTable.OrderPlaced = false;
            selectedTable.seated.Clear();
            selectedTable.ordered.Clear();

            // initialize the seated arraylist for the selected table.
            // and reset its color to green

            foreach (Control ctrl in tabControl1.SelectedTab.Controls)
            {
                if (ctrl is Seat)
                {
                    Seat s = ctrl as Seat;
                    if (selectedTable.seated.Count <= 4)
                    {
                        selectedTable.seated.Add(s);
                        s.Image = Properties.Resources.Button_Blank_Green_icon;
                        s.Enabled = false;
                    }                              
                }
            }
            selectedTable.Waiter = labelWaiter.Text; 
          
            // reset controls to their state at entry

            listBoxMeals.Enabled = false;
            Button b = (Button)sender;
            b.Enabled = false;
            buttonStartOrder.Enabled = true;
        }

        private void textBoxWaiterName_MouseEnter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
        }
    }
}
