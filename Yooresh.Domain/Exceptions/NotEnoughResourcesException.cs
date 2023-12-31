namespace Yooresh.Domain.Exceptions;

public class NotEnoughResourcesException : DomainException
{
    private const string Error = "Not enough resources";

    public NotEnoughResourcesException() : base(Error)
    {
    }
}