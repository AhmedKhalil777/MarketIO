using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.Contracts.V1
{
    public static class MVCRoutes
    {
        public const string Trapdoor = "/Trapdoor";
        public const string Signout = "/Signout";
        public const string ChangeImage = "/Image";
        public const string Version = "";



        public static class Admin
        {
            public const string Base = Version + "/Admin";
            public const string AdminHome = Base + "/Home";
            public const string EditAdmin = AdminHome + "/Edit";

            public static class Moderators
            {
                public const string Base = Admin.Base + "/Moderators";
                // Managing Moderators 
                public const string GetModerators = Base +"/"; 
                public const string GetModeratorById = Base + "/{MID}";
                public const string SearchModerator = Base + "/{SearchItem}";
                public const string UpdateModerator = Base + "/{MID}";
                public const string CreateModerator = Base + "/";
                public const string DeleteModerator = Base + "/{MID}";
            }
            public static class Customers
            {
                public const string Base = Admin.Base + "/Customers";
                // Managing Customers 
                public const string GetCustomers = Base  +"/" ;
                public const string GetCustomerById = Base + "/{MID}";
                public const string SearchCustomer = Base + "/{SearchItem}";
                public const string UpdateCustomer = Base + "/{MID}";
                public const string CreateCustomer = Base + "/";
                public const string DeleteCustomer = Base + "/{MID}";
            }
            // Statistics and Monitoring

            public static class Monitoring
            {
                public const string DayBase = Base + "/Monitoring/Day";
                public const string MonthBase = Base + "/Monitoring/Month";
                #region Daily
                public const string DayBrands = DayBase + "/Brands";
                  public const string DayCategories = DayBase + "/Categories";
                  public const string DayBestSales = DayBase + "/BestSales";
                #endregion



                #region Monthly
                    public const string PaymentBerDays = MonthBase + "/Brands";
                    public const string MonthBestSales = MonthBase + "/BestSales";
                    public const string MonthCategories = MonthBase + "/Categories";

                #endregion
            }

            //Logging
            public const string Logs = "/Admin/Logs";



        }

        public static class Moderator
        {
            public const string Base = Version + "/Moderator";
            public const string ModeratorHome = Base + "/Home";
            // Manage Products 
            public static class Products
            {
                
                public const string Base = Moderator.Base + "/Products";
                public const string GetProducts = Base + "/";
                public const string GetProductById = Base + "/{PID}";
                public const string UpdateProduct = Base + "/EditProduct/{ProductId}";
                public const string CreateProduct = Base + "/Create";
                public const string DeleteProduct = Base + "/Delete/{ProductId}";
            }


            // Manage Orders

            public static class Orders
            {
                public const string Base = Moderator.Base + "/Orders";

                public const  string GetAcceptedOrders = Base + "/";
                public const string DeleteOrder = Base + "/{OID}";
                public const string ShippingOrder = Base + "/Ship/{OID}";
                public const string RecievingOrder = Base + "/Recieve/{OID}";
                
            }



        }


        public static class Application
        {
            public const string Base = Version + "/";
            public const string SignIn = Base +"SignIn/";
            public const string Register = Base + "Register/";

            
            public static class Products
            {
                public const string Base = Application.Base ;
                public const string GetProducts = Base ;
                public const string ProductDetails = Base + "/{PID}";
                public const string SearchProduct = Base + "/Search/{PID}";


                

            }

        }


        


    }
}
