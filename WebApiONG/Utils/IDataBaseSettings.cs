namespace WebApiONG.Utils
{
    public interface IDatabaseSettings
    {
        string AddressCollectionName { get; set; }
        string AnimalsCollectionName { get; set; }   
        string PersonCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
