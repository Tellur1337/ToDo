using SQLite;
using System;
using System.Collections.Generic;
using System.Text;



namespace ToDo
{
    public class JobRP
    {
        SQLiteConnection dataBase;
        public JobRP(string databasePath)
        {
            dataBase = new SQLiteConnection(databasePath);
            dataBase.CreateTable<Job>();
        }
        public IEnumerable<Job> GetItems()
        {
            return dataBase.Table<Job>().ToList();
        }
        public Job GetItem(int id)
        {
            return dataBase.Get<Job>(id);
        }
        public int DeleteItem(int id)
        {
            return dataBase.Delete<Job>(id);
        }
        public int SaveItem(Job item)
        {
            if (item.Id != 0)
            {
                dataBase.Update(item);
                return item.Id;
            }
            else
            {
                return dataBase.Insert(item);
            }
        }
    }
}