namespace UniLibrary;

public class Journal: ILibraryItem
{
    public event Action<ILibraryItem>? bookAvailable;
    private string id;
    private string Title;
    private string Country;
    private string Issue_Date;
    private int amountInLibrary;

    public Journal(string _title, string _country, string _issueDate, string _id)
    {
        Title = _title;
        Country = _country;
        Issue_Date = _issueDate;
        id = _id;
        amountInLibrary = 0;
    }

    public string getTitle()
    {
        return Title;
    }

    public int getAmount()
    {
        return amountInLibrary;
    }

    public bool borrow()
    {
        if (amountInLibrary > 0)
        {
            amountInLibrary--;
            return true;
        }

        return false;
    }

    public void returnItem()
    {
        if (amountInLibrary > 0)
        {
            amountInLibrary++;
            return;
        }
        amountInLibrary++;
        bookAvailable?.Invoke(this);
    }

    public string getId()
    {
        return id;
    }

    public void addToStock(int amount)
    {
        amountInLibrary += amount;
        if (amountInLibrary - amount == 0)
        {
            bookAvailable?.Invoke(this);
        }
    }
}