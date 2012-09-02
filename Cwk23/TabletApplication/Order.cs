using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TabletApplication
{
    public class Order
    {
        // Constructor

        public Order(int orderNo, int tableNo, string waiter)
        {
            timeOrdered = DateTime.Now;
            this.waiter = waiter;
            this.orderNo = orderNo;
            this.tableNo = tableNo;
        }

        // Private Members

        int orderNo;
        String waiter;
        int tableNo;     

        ArrayList meals = new ArrayList();
        DateTime timeOrdered;

        // Public Methods

        public string addMealToOrder(Meal meal)
        {
            try
            {
                meals.Add(meal);
                return "Meal Added";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int getNumberOfMeals()
        {
            return  meals.Count;
        }

        public Meal[] getMeals()
        {
            int i = 0;
            Meal[] mealsInOrder = new Meal[ meals.Count ];
            foreach( Meal m in meals)
            {
                mealsInOrder[i] = m;
                i++;
            }
            return mealsInOrder;
        }

        // Read-Only Properties

        /// <summary>
        /// Gets the new Order Number
        /// </summary>
        public int OrderNo
        {
            get { return orderNo; }
        }

        public int TableNo
        {
            get { return tableNo; }
        }

        public String Waiter
        {
            get { return waiter; }
        }
    }
}
