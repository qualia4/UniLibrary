namespace UniLibrary;

public interface IReaderNotifier
{
    Task Notify(string userId, string message);
}