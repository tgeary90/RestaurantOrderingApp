using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TabletApplication
{
    class Table
    {
        public Table( int tableNo )
        {
            this.tableNo = tableNo;
        }

        // Private Members

        public ArrayList seated = new ArrayList();
        public ArrayList ordered = new ArrayList();

        int tableNo;
        bool orderPlaced;
        string waiter;

        // Properties

        /// <summary>
        /// get/Set order placed for the table
        /// </summary>
        public bool OrderPlaced
        {
            get { return orderPlaced; }
            set { orderPlaced = value; }
        }

        /// <summary>
        /// get/set the waiter for the table
        /// </summary>
        public string Waiter
        {
            get { return waiter; }
            set { waiter = value; }
        }

        // Read-only Property

        /// <summary>
        ///get table number 
        /// </summary>
        public int TableNo
        {
            get { return tableNo; }
        }
    }
}
