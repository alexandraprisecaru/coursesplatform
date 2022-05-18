namespace MongoDb.Models
{
    /// <summary>
    /// Mongo DB settings
    /// </summary>
    public class MongoDbSettings
    {
        /// <summary>
        /// Connections string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Database
        /// </summary>
        public string Database { get; set; }
    }
}
