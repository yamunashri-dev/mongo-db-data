﻿using MongoDB.Driver.Core.Configuration;


namespace MongodbData.Model
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }

    }
}
