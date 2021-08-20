using System;
using System.Collections.Generic;
using System.Text;
//libs
using SQLite;
using GoldenRhino.Model;
using System.Threading.Tasks;

namespace GoldenRhino.Data
{
    public class Database
    {
         readonly SQLiteAsyncConnection database;

         public Database(string path)
         {
             database = new SQLiteAsyncConnection(path);
             database.CreateTableAsync<User>().Wait();
         }

         public Task<int> Insert(User item)
         {
             if (item.ID != 0)
             {
                 return database.UpdateAsync(item);
             }
             else
             {
                 return database.InsertAsync(item);
             }
         }

         public Task<List<User>> GetAllItems()
         {
             return database.Table<User>().ToListAsync();
         }
    }
}
