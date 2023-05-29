var logger = new Logger(new FileStore());
logger.Log("Hello");

var anotherLogger = new Logger(new DatabaseStore());
anotherLogger.Log("Hello");


public class Logger
{
    private readonly IStore _store;

    public Logger(IStore fileStore) => _store = fileStore;

    public void Log(string message) => _store.Write($"Information {message}");
}

public interface IStore
{
    void Write(string message);
}

public class FileStore : IStore
{
    //this class can handle files
    public void Write(string message)
    {

    }
}

public class DatabaseStore : IStore
{
    //this class can handle files
    public void Write(string message)
    {
        //here handling the database
    }
}