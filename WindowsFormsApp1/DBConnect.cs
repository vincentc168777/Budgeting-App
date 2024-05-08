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
        public static void createLoginTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("create table if not exists LoginInfo(" +
                    "ID integer PRIMARY KEY," +
                    "username TEXT," +
                    "password TEXT)");

            }
        }

        public static void clearDataLogin()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("DROP TABLE LoginInfo");

            }
        }

        public static void SaveLogin(string user, string pass)
        {
            //clearDataLogin();
            createLoginTable();
            // using statemnt opens connection and no matter what happens, whether we finish running this or we crash, the connection to db will close
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("insert into LoginInfo (username, password) values (@username, @password)", new { username = user, password = pass });
            }
        }

        public static bool FindLogin(string user, string pass)
        {
            createLoginTable();
            // using statemnt opens connection and no matter what happens, whether we finish running this or we crash, the connection to db will close
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                var result = cnn.QueryFirstOrDefault<string>("SELECT  username " +
                    "FROM  LoginInfo " +
                    "WHERE  username = @username AND password = @password;", new { username = user, password = pass });
                if (result == null)
                {
                    return false;
                }
                return true;
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

        //add description column
        public static void AddDescription()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("ALTER TABLE Items " +
                    "ADD Description TEXT");
            }
        }

        //check if description column already exists
        public static bool ColumnExists()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                
                var cmd = cnn.CreateCommand();
                cmd.CommandText = string.Format("PRAGMA table_info('Items')");
                cnn.Open();
                var reader = cmd.ExecuteReader();
                int nameIndex = reader.GetOrdinal("Name");
                while (reader.Read())
                {
                    if (reader.GetString(nameIndex).Equals("Description"))
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
            }
            return false;
        }

        public static void EditItem(int itemID, string newItemName, decimal newCost, string newDescription)
        {
            if (!ColumnExists())
            {
                AddDescription();
            }
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("UPDATE Items " +
                    "SET ItemName = @ItemName, Cost = @Cost, Description = @Description " +
                    "WHERE Id = @Id;", new { Id = itemID, ItemName = newItemName, Cost = newCost, Description = newDescription });
            }
        }

        public static string getName(int itemID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                return cnn.QueryFirstOrDefault<string>("SELECT ItemName FROM Items WHERE Id=@Id", new { Id = itemID });
            }
        }

        public static float getCost(int itemID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                return cnn.QueryFirstOrDefault<float>("SELECT Cost FROM Items WHERE Id=@Id", new { Id = itemID });
            }
        }

        public static string getDescription(int itemID)
        {
            if (!ColumnExists())
            {
                AddDescription();
            }
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                return cnn.QueryFirstOrDefault<string>("SELECT Description FROM Items WHERE Id=@Id", new { Id = itemID });
            }
        }

        public static void SaveItem(Item newItem)
        {
            if (!ColumnExists())
            {
                AddDescription();
            }
            // using statemnt opens connection and no matter what happens, whether we finish running this or we crash, the connection to db will close
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("insert into Items (ItemName, Cost, Description) values (@ItemName, @Cost, @Description)", newItem);
            }
        }

        public static List<Item> GetItemsWithLetters(string input)
        {
            
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                var res = cnn.Query<Item>("SELECT * FROM Items WHERE ItemName Like '%" + input + "%'");
                return res.ToList();

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
