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
    internal class DBConnect
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

        /*
        
        public static float displayBudget()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                float output = cnn.Query<Budget>("SELECT * FROM Budgets ORDER BY column DESC LIMIT 1;", new DynamicParameters());
                return output;
            }
        }

        public static void saveBudget(Budget newBudget) {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnString()))
            {
                cnn.Execute("insert into Budgets (budgetPrice) values (@budgetPrice)", newBudget);
            }
        }
         */

        private static string LoadConnString(string id = "Default")
        {
            // allos us to talk to app.config
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
