namespace UniLibrary;

public class Borrow
{
    private ILibraryItem borrowedItem;
    private string deadline;

    public Borrow(ILibraryItem item, string _deadline)
    {
        borrowedItem = item;
        deadline = _deadline;
    }

    public string getDeadline()
    {
        return deadline;
    }

    public void prolongDeadline(string newDeadline)
    {
        deadline = newDeadline;
    }


}