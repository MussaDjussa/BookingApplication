using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using BookingApplication;
using System.Threading.Tasks;

namespace BookingApplication.Data
{
    public class UserDB
    {
        readonly SQLiteAsyncConnection db;

        public UserDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);

            db.CreateTableAsync<UserModel>().Wait();
        }

        public Task<List<UserModel>> GetUsers()
        {
            return db.Table<UserModel>().ToListAsync();
        }

        public Task<UserModel> GetUserOnly(string email, string password)
        {
            return db.Table<UserModel>().Where(q=>q.Email == email 
                                                    && q.Password == password)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveUser(UserModel userModel)
        {
            if(userModel.ID != 0)
            {
                return db.UpdateAsync(userModel);
            }
            else
            {
                return db.InsertAsync(userModel);
            }
        }

        public Task<int> DeleteUser(UserModel userModel)
        {
            return db.DeleteAsync(userModel);
        }
    }
}
