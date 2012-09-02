using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TabletApplication;
using System.Collections;


namespace WcfServiceSendOrder
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IServiceProcessOrder
    {
        // Computer name for hooking up the database

        string myComputer = System.Environment.MachineName;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string sendOrder(int orderNo, string Waiter)
        {
            // We have just taken an order at the tablet so we have to send
            // those details up to the KitchenDatabase for the kitchen staff to mark as 
            // ready

            StringBuilder strBuilder = new StringBuilder();
            SqlConnection conn = new SqlConnection("server=" + myComputer + @"\SQLExpress;Integrated Security=SSPI;database=KitchenDatabase");

            try
            {
                conn.Open();
                strBuilder.Append("open: KitchenDatabase. ");
                string sql;
                
                SqlCommand sqlCmd; 

                sql = @"INSERT INTO dbo.Orders (OrderNo, Waiter, NoOfMeals, TimeOrdered, OrderReceived, OrderReady, OrderDelivered) VALUES" +
                    " (@OrderNo, @Waiter, @NoOfMeals, @TimeOrdered, 'yes', 'no', 'no')";
                sqlCmd = new SqlCommand(sql, conn);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@Waiter", Waiter);
                sqlCmd.Parameters.AddWithValue("@NoOfMeals", 4);
                sqlCmd.Parameters.Add("@TimeOrdered", SqlDbType.DateTime).Value = DateTime.Now;
                sqlCmd.ExecuteNonQuery();

                strBuilder.Append("Order sent successfully.");
            }
            catch (Exception ex)
            {
                strBuilder.Append
                    ("open fail: KitchenDatabase " + conn.ConnectionString + "\r\n error: " + ex.Message + "\r\n");              
            }
            finally
            {
                conn.Close();               
            }
            return strBuilder.ToString();
        }

        public string updateOrder(int orderNo)
        {
            StringBuilder strBuilder = new StringBuilder();
            SqlConnection conn = new SqlConnection("server=" + myComputer + @"\SQLExpress;Integrated Security=SSPI;database=KitchenDatabase");

            try
            {
                conn.Open();
                strBuilder.Append("open: KitchenDatabase. ");
                string sql;

                SqlCommand sqlCmd;

                sql = @"UPDATE Orders SET OrderDelivered = 'yes', TimeDelivered = @TimeDelivered WHERE OrderNo = @OrderNo";
                sqlCmd = new SqlCommand(sql, conn);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.Add("@TimeDelivered", SqlDbType.DateTime).Value = DateTime.Now;
                sqlCmd.ExecuteNonQuery();

                strBuilder.Append("Order updated successfully.");
            }
            catch (Exception ex)
            {
                strBuilder.Append
                    ("open fail: KitchenDatabase3 " + conn.ConnectionString + "\r\n error: " + ex.Message + "\r\n");
            }
            finally
            {
                conn.Close();
            }
            return strBuilder.ToString();
        }
        public string sendMeal(int mealNo, int mealType, double mealPrice, int orderNo, int tableNo)
        {
            // The Order contains Meals. Those meals need to be sent to the meals 
            // database table "Meals" for later processing

            StringBuilder strBuilder = new StringBuilder();
            SqlConnection conn = new SqlConnection("server=" + myComputer + @"\SQLExpress;Integrated Security=SSPI;database=KitchenDatabase");

            try
            {
                conn.Open();
                strBuilder.Append("open: KitchenDatabase3");
                string sql;
                
                SqlCommand sqlCmd; 

                sql = @"INSERT INTO dbo.Meals (MealNo, MealType, MealPrice, OrderNo, TableNo) VALUES" +
                    " (@MealNo, @MealType, @MealPrice, @OrderNo, @TableNo)";
                sqlCmd = new SqlCommand(sql, conn);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);
                sqlCmd.Parameters.AddWithValue("@MealType", mealType);
                sqlCmd.Parameters.AddWithValue("@MealPrice", mealPrice);
                sqlCmd.Parameters.AddWithValue("@MealNo", mealNo);
                sqlCmd.Parameters.AddWithValue("@TableNo", tableNo);
                sqlCmd.ExecuteNonQuery();

                strBuilder.Append("Meals added successfully sent");
            }
            catch (Exception ex)
            {
                strBuilder.Append("open fail: KitchenDatabase3 " + conn.ConnectionString + "\n error: " + ex.Message);              
            }
            finally
            {
                conn.Close();               
            }
            return strBuilder.ToString();
        }

        public int[] getReadyOrders()
        {
            // This web service returns an array of order numbers that have been
            // marked as OrderReady = 'yes'

            // To communicate over the network the web method returns an array

            StringBuilder strBuilder = new StringBuilder();
            SqlConnection conn =
                new SqlConnection("server=" + myComputer + @"\SQLExpress;Integrated Security=SSPI;database=KitchenDatabase");
            ArrayList readyOrdersList = new ArrayList();
            int[] webServiceFail = new int[] {1};

            try
            {
                conn.Open();
                strBuilder.Append("open: KitchenDatabase3");
                string sql;

                SqlCommand sqlCmd;

                sql = "SELECT OrderNo FROM Orders WHERE OrderReady = 'yes'"
                + " AND OrderDelivered = 'no'";
                sqlCmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    readyOrdersList.Add(rdr.GetInt32(0));
                }

                int[] readyOrders = new int[readyOrdersList.Count];
                for (int i = 0; i < readyOrdersList.Count; i++)
                {
                    readyOrders[i] = (int)readyOrdersList[i];
                }
                strBuilder.Append("Ready Orders retrieved successfully ");
                return readyOrders;
            }
            catch (Exception ex)
            {
                strBuilder.Append("open fail: KitchenDatabase3 " + conn.ConnectionString + "\n error: " + ex.Message);
                return webServiceFail;
            }
            finally
            {
                conn.Close();
            }
        }

        public string clearOrders()
        {
            // We need to clear out the data when the application stops.

            StringBuilder strBuilder = new StringBuilder();

            SqlConnection conn =
                new SqlConnection("server=" + myComputer + @"\SQLExpress;Integrated Security=SSPI;database=KitchenDatabase");

            try
            {
                conn.Open();
                strBuilder.Append("open: KitchenDatabase. ");
                string sql;

                SqlCommand sqlCmd;

                sql = @"DELETE FROM dbo.Orders";
                sqlCmd = new SqlCommand(sql, conn);
                sqlCmd.ExecuteNonQuery();

                sql = @"DELETE FROM dbo.Meals";
                sqlCmd = new SqlCommand(sql, conn);
                sqlCmd.ExecuteNonQuery();

                strBuilder.Append("Database Tables cleared successfully.");
            }
            catch (Exception ex)
            {
                strBuilder.Append
                    ("open fail: KitchenDatabase " + conn.ConnectionString + "\r\n error: " + ex.Message + "\r\n");
                return strBuilder.ToString();
            }
            finally
            {
                conn.Close();
            }
            return strBuilder.ToString();
        }
    }
}
