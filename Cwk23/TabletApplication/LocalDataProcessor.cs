using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;


namespace TabletApplication
{
    class LocalDataProcessor
    {
        /* Class to process orders locally */

        // Constructor 
        // Sets up the connection 

        SqlCeConnection conn;

        public LocalDataProcessor()
        {
            try
            {
                string connString;
                connString = Properties.Settings.Default.TabletDatabaseConnectionString;
                conn = new SqlCeConnection(connString);
            }
            catch (Exception ex)
            {
                dbError = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        string dbError;

        // Readonly Property defined

        public string DbError
        {
            get { return dbError; }
        }

        public int getNextOrderNo()
        {
            // Get the next order number from the local database

            int orderNo = 0;
            try
            {
                conn.Open();
                SqlCeCommand sqlCmd = new SqlCeCommand("SELECT OrderNo FROM Orders", conn);
                SqlCeDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    orderNo = rdr.GetInt32(0);
                }
            }

            catch (Exception ex)
            {
                dbError = ex.Message;
                return -1;
            }

            finally
            {
                conn.Close();
            }

            return ++orderNo;
        }

        public int getTableForAnOrder( int orderNo )
        {
            // We need to ascertain the table that an order was made for in
            // order to mark that order as complete. This sql statement does this.

            int  tableNo = 0;
            try
            {
                conn.Open();
                SqlCeCommand sqlCmd = new SqlCeCommand("SELECT TableNo FROM Orders WHERE OrderNo = @OrderNo", conn);
                sqlCmd.Parameters.AddWithValue("@OrderNo", orderNo);

                SqlCeDataReader rdr = sqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    tableNo = rdr.GetInt32(0);
                }
            }

            catch (Exception ex)
            {
                dbError = ex.Message;
                return -1;
            }

            finally
            {
                conn.Close();          
            }
            return tableNo;
        }

        public DataSet insertNewOrder(int orderNo, int tableNo, DataSet ds)
        {
            DataRow dr = ds.Tables["Orders"].NewRow();
            dr["OrderNo"] = orderNo;
            dr["TableNo"] = tableNo;
            dr["OrderSent"] = "yes";
            dr["OrderReceived"] = "no";
            ds.Tables["Orders"].Rows.Add(dr);

            return ds;
        }

        public DataSet markOrderReady(int tableNo, DataSet ds)
        {
            foreach (DataRow dr in ds.Tables["Orders"].Rows)
            {
                if ((int)dr["TableNo"] == tableNo)
                {
                    dr["OrderReceived"] = "yes";
                }
            }
            return ds;
        }

        public DataSet clearLocalDatabase(DataSet ds)
        {
            foreach (DataRow dr in ds.Tables["Orders"].Rows)
            {
                dr.Delete();
            }
            return ds;
        }
    }
}
