using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using System.IO;

namespace WindowsFormsApp1
{
    internal static class DBConnect
    {
        
        public static void createBudgetTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("create table if not exists Budget(" +
                    "ID integer PRIMARY KEY     ," +
                    "budgetPrice            REAL)");

            }
        }

        public static void clearData()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("DROP TABLE Budget");

            }
        }
        
        public static List<Item> LoadItem()
        {
            // using statemnt opens connection and no matter what happens, whether we finish running this or we crash, the connection to db will close
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                var output = cnn.Query<Item>("select * from Items");
                return output.ToList();
            }
        }

        public static void DeleteItem(int itemID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("DELETE FROM Items WHERE Id = @Id", new { Id = itemID});
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

        

        //supposed to display most recent Budget entry
        public static float displayBudget()
        {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
                {
                    return cnn.QueryFirstOrDefault<float>("SELECT budgetPrice FROM Budget LIMIT 1", 0f);
                }
        }

        //supposed to save budget into Budget table
        public static void saveBudget(float f) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                MyBudget b = new MyBudget();
                b.setMyBudget(f);
                int budCount = cnn.ExecuteScalar<int>("SELECT COUNT(*) FROM Budget");
                if(budCount == 0)
                {
                    cnn.Execute("insert into Budget (budgetPrice) values (@budgetPri)", new { budgetPri = f});
                }
                else
                {
                    cnn.Execute("update Budget SET budgetPrice = " + b.getMyBudget() + " WHERE ID = 1");
                }
                    
            }
        }
        
        //supposed to display the total cost of all expenses
        public static float displayTotal()
        {
            float total = 0;
            List<Item> allItems = LoadItem();
            if (allItems.Count != 0 || allItems != null)
            {
                foreach (Item i in allItems)
                {
                    total += i.Cost;
                }
            }
            return total;
        }

        private static string LoadConnString(string id = "Default")
        {
            // allos us to talk to app.config
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
