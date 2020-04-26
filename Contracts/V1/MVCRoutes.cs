using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.MVC.Contracts.V1
{
    public static class MVCRoutes
    {
        public static string Version = "/V1";
        
        public static class Admin
        {
            public static string Base = Version+ "/Admin";
            public static string AdminHome = Base  + "/Home";

            public static class Moderators
            {
                public static string Base = Admin.Base + "/Moderators";
                // Managing Moderators 
                public static string GetModerators = Base +"/";
                public static string GetModeratorById = Base + "/{MID}";
                public static string SearchModerator = Base + "/{SearchItem}";
                public static string UpdateModerator = Base + "/{MID}";
                public static string CreateModerator = Base + "/";
                public static string DeleteModerator = Base + "/{MID}";
            }
            public static class Customers
            {
                public static string Base = Admin.Base + "/Customers";
                // Managing Customers 
                public static string GetCustomers = Base  +"/" ;
                public static string GetCustomerById = Base + "/{MID}";
                public static string SearchCustomer = Base + "/{SearchItem}";
                public static string UpdateCustomer = Base + "/{MID}";
                public static string CreateCustomer = Base + "/";
                public static string DeleteCustomer = Base + "/{MID}";
            }
            // Statistics and Monitoring

            public static class Monitoring
            {
                public static string DayBase = Base + "/Monitoring/Day";
                public static string MonthBase = Base + "/Monitoring/Month";
                #region Daily
                public static string DayBrands = DayBase + "/Brands";
                  public static string DayCategories = DayBase + "/Categories";
                  public static string DayBestSales = DayBase + "/BestSales";
                #endregion



                #region Monthly
                    public static string PaymentBerDays = MonthBase + "/Brands";
                    public static string MonthBestSales = MonthBase + "/BestSales";
                    public static string MonthCategories = MonthBase + "/Categories";

                #endregion
            }

            //Logging
            public static string Logs = "/Admin/Logs";



        }

        public static class Moderator
        {
            public static string Base = Version + "/Moderator";
            public static string ModeratorHome = Base + "/Home";
            // Manage Products 
            public static class Products
            {
                
                public static string Base = Moderator.Base + "/Products";
                public static string GetProducts = Base +"/";
                public static string GetProductById = Base + "/{PID}";
                public static string UpdateProduct = Base + "/{PID}";
                public static string CreateProduct = Base + "/";
                public static string DeleteProduct = Base + "/{PID}";
            }


            // Manage Orders

            public static class Orders
            {
                public static string Base = Moderator.Base + "/Orders";

                public static string GetAcceptedOrders = Base + "/";
                public static string DeleteOrder = Base + "/{OID}";
                public static string ShippingOrder = Base + "/Ship/{OID}";
                public static string RecievingOrder = Base + "/Recieve/{OID}";
                
            }



        }

        


        

    }
}
