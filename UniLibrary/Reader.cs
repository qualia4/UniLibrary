namespace UniLibrary;

public class Reader
{
    private string role;
    private List<Borrow> borrows;
    private string userID;
    private int maxBooksLimit;
    private int inTimeReturns;

    public Reader(string _role, string _userId)
    {
        role = _role;
        userID = _userId;
    }

    public bool addBorrow(Borrow newBorrow)
    {
        if (maxBooksLimit > borrows.Count)
        {
            borrows.Add(newBorrow);
            return true;
        }
        return false;
    }

    public bool returnBook(Borrow borrow)
    {
        if (borrows.Contains(borrow))
        {
            borrows.Remove(borrow);
            return true;
        }

        return false;
    }

    public bool prolongDeadlin(Borrow borrow, string newDeadline)
    {
        if(borrows.Contains(borrow))
        {
            borrow.prolongDeadline(newDeadline);
            return true;
        }
        return false;
    }


}