using MongoDB.Driver;

namespace Antonino.Classes
{
    internal sealed class MongoConnection
    {
        private static MongoConnection instance;
        public IMongoDatabase Database { get; private set; }

        private void Connect()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            IMongoDatabase db = client.GetDatabase(MongoDBConfig.DBName);
            Database = db;
        }

        private static object syncRoot = new object();

        private MongoConnection() { }

        public static MongoConnection Instance
        { get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MongoConnection();
                            instance.Connect();
                        }
                    }                    
                }
                return instance;
            }
        }
    }
}
