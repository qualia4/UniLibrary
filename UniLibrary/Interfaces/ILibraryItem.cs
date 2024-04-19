namespace UniLibrary;

public interface ILibraryItem
{
    public string getTitle();
    public int getAmount();
    public bool borrow();
    public event Action<ILibraryItem>? bookAvailable;
    public void returnItem();
    void addToStock(int amount);
}