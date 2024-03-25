using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;

namespace WindowsFormsApp1
{
    internal static class DBConnect
    {
        public static List<Item> LoadItem()
        {
            // using statemnt opens connection and no matter what happens, whether we finish running this or we crash, the connection to db will close
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                var output = cnn.Query<Item>("select * from Items", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveItem(Item newItem)
        {
            // using statemnt opens connection and no matter what happens, whether we finish running this or we crash, the connection to db will close
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("insert into Items (ItemName, Cost) values (@ItemName, @Cost)", newItem);
            }
        }

        public static void createBudgetTable()
        {
            
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("create table Budget(" +
                    "ID INT PRIMARY KEY     NOT NULL," +
                    "budgetPrice            REAL)");
            }
        }

        
        
        public static float displayBudget()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                MyBudget output = cnn.QueryFirstOrDefault<MyBudget>("SELECT * FROM Budget ORDER BY column DESC LIMIT 1");
                return output.getMyBudget();
            }
        }
        
        public static void saveBudget(MyBudget newBudget) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("insert into Budget (budgetPrice) values (@budgetPrice)", newBudget);
            }
        }
        
        public static float displayTotal()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                Item output = cnn.QueryFirstOrDefault<Item>("SELECT SUM(Cost) FROM Items", new DynamicParameters());
                return output.Cost;
            }
        }
        


        private static string LoadConnString(string id = "Default")
        {
            // allos us to talk to app.config
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
