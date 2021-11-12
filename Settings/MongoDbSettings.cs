namespace Catalog.Settings;

public class MongoDbSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string ConnectionString
    {
        get
        {
            return $"mongodb://{Host}:{Port}";
        }
    }
    /*sudo docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo*/
}