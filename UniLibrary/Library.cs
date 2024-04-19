namespace UniLibrary;

public class Library
{
    private List<Reader> readers = new List<Reader>();
    private List<ILibraryItem> libraryItems = new List<ILibraryItem>();
    private List<Borrow> _borrows = new List<Borrow>();
    private IReaderNotifier notifier;

    public Library(IReaderNotifier _notifier)
    {
        notifier = _notifier;
    }

    public void RegisterReader(Reader reader)
    {
        readers.Add(reader);
    }

    public void AddLibraryItem(ILibraryItem item)
    {
        libraryItems.Add(item);
    }

    public void AddStockItem(string id, int amountToAdd)
    {
        foreach (var item in libraryItems)
        {
            if (item.getId() == id)
            {
                item.addToStock(amountToAdd);
                return;
            }
        }
    }

    public bool BorrowItem(string userId, string Id)
    {
        Borrow? newBorrow = null;
        foreach (var item in libraryItems)
        {
            if (item.getId() == Id)
            {
                if (item.borrow())
                {
                    newBorrow = new Borrow(item, "default-deadline");
                }
            }
        }

        if (newBorrow == null)
        {
            return false;
        }
        foreach (var user in readers)
        {
            if (user.userID == userId)
            {
                return user.AddBorrow(newBorrow);
            }
        }
        return false;
    }

    public bool ReturnItem(string userId, Guid borrowId)
    {
        Borrow? borrowToReturn = null;
        foreach (var borrow in _borrows)
        {
            if (borrow.borrowId == borrowId)
            {
                borrowToReturn = borrow;
            }
        }

        if (borrowToReturn == null)
        {
            return false;
        }

        foreach (var user in readers)
        {
            if (user.userID == userId)
            {
                return user.ReturnBook(borrowToReturn);
            }
        }
        return false;
    }
}