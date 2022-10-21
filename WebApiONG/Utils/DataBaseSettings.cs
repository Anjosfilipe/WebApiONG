namespace WebApiONG.Utils
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AddressCollectionName { get; set; }
        public string AnimalsCollectionName { get; set; }
        public string PersonCollectionName { get; set; }
    }
}
