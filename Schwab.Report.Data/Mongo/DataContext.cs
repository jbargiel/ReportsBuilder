using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using MongoDB;
using MongoDB.Driver;

namespace Schwab.Report.Data
{
    public class DataContext : IDisposable
    {
        MongoClient _client;
        IMongoDatabase _db;

        public DataContext(string dbname)
        {
            _client = new MongoClient(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            _db = _client.GetDatabase(dbname);
        }

        public IMongoDatabase GetDatabase()
        {
            return _db;
        }

        public void DropDatabase(string dbName)
        {
            _client.DropDatabase(dbName);
        }

        public MongoClient GetClient()
        {
            return _client;
        }

        public void Dispose()
        {

        }
    }
}
