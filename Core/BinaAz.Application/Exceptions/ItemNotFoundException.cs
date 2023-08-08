namespace BinaAz.Application.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException() : base("Item doesn't exist or you don't have permission to this item.")
    {
    }
    public ItemNotFoundException(string? message) : base(message)
    {
    }
    public ItemNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}