namespace UniLibrary;

public class Borrow
{
    private ILibraryItem borrowedItem;
    private string deadline;
    public Guid borrowId;

    public Borrow(ILibraryItem item, string _deadline)
    {
        borrowedItem = item;
        deadline = _deadline;
        borrowId = Guid.NewGuid();
    }

    public string getDeadline()
    {
        return deadline;
    }

    public void prolongDeadline(string newDeadline)
    {
        deadline = newDeadline;
    }

    public bool InTime()
    {
        // should compare current time to deadline
        return true;
    }


}