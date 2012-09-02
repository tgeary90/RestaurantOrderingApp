using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabletApplication
{
    
    public enum mealType
    {
        EggsonToast = 5,
        AllDayBreakfast = 10,
        MarmaladeOnToast = 3,
        BoiledEgg = 4,
        EggsBenedict = 8,
        SalmonOnCroissant = 6,
        CheeseOmelette = 7,
    }

    
    public class Meal
    {
        public Meal(mealType type, int mealNo)
        {
            this.type = type;
            this.mealNo = mealNo;

            // set the meals price from its type enum
            this.Price = (int)type;
        }

        // Private Members

        int mealNo;
        int price;      
        mealType type;
        bool availability;

        // Properties

        /// <summary>
        /// The setter takes the mealtype as a value and 
        /// sets the price member variable according to its
        /// translated price, based on enum value lookup.
        /// </summary>
        public int Price
        {
            get { return price; }
            set
            {
                switch ((int)type)
                {
                    case 0:
                        price = (int)mealType.EggsonToast;
                        break;
                    case 1:
                        price = (int)mealType.AllDayBreakfast;
                        break;
                    case 2:
                        price = (int)mealType.CheeseOmelette;
                        break;
                    case 3:
                        price = (int)mealType.EggsBenedict;
                        break;
                    case 4:
                        price = (int)mealType.EggsonToast;
                        break;
                    case 5:
                        price = (int)mealType.MarmaladeOnToast;
                        break;
                    case 6:
                        price = (int)mealType.SalmonOnCroissant;
                        break;
                }
            }
        }

        // Read only Properties

        public mealType Type
        {
            get { return type; }
        }

        public int MealNo
        {
            get { return mealNo; }
        }

        /// <summary>
        /// Not used in this version, this is simulated via flat file.
        /// </summary>
        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }      
    }
}
