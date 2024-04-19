namespace UniLibrary;

public class Reader
{
    private string role;
    private List<Borrow> borrows = new List<Borrow>(); // Initialized to avoid null reference
    public string userID;
    private int maxBooksLimit;
    private int inTimeReturns;

    public Reader(string _role, string _userId, int initialLimit)
    {
        role = _role;
        userID = _userId;
        maxBooksLimit = initialLimit;
    }

    public bool AddBorrow(Borrow newBorrow)
    {
        if (maxBooksLimit > borrows.Count && !HasOverdueItems())
        {
            borrows.Add(newBorrow);
            return true;
        }
        return false;
    }

    public bool ReturnBook(Borrow borrow)
    {
        if (borrows.Contains(borrow))
        {
            borrows.Remove(borrow);
            if (borrow.InTime())
            {
                inTimeReturns++;
            }
            UpdateBorrowingLimit();
            return true;
        }
        return false;
    }

    public bool ProlongDeadline(Borrow borrow, string newDeadline)
    {
        if (borrows.Contains(borrow))
        {
            borrow.prolongDeadline(newDeadline);
            return true;
        }
        return false;
    }

    private void UpdateBorrowingLimit()
    {
        if (role == "guest" && inTimeReturns >= 5)
        {
            maxBooksLimit = 10;
        }
    }

    private bool HasOverdueItems()
    {
        return borrows.Any(b => DateTime.Parse(b.getDeadline()) < DateTime.Now);
    }
}