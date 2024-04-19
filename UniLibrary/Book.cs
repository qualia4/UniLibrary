namespace UniLibrary;

public class Book: ILibraryItem
{
    private string Title;
    private string Author;
    private string ISBN;
    private string Print_Year;
    private int amountInLibrary;
    public event Action<ILibraryItem>? bookAvailable;

    public Book(string title, string author, string _ISBN, string printYear)
    {
        Title = title;
        Author = author;
        ISBN = _ISBN;
        Print_Year = printYear;
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

    public string getId()
    {
        return ISBN;
    }


    public void addToStock(int amount)
    {
        amountInLibrary += amount;
        if (amountInLibrary - amount == 0)
        {
            bookAvailable?.Invoke(this);
        }
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


}