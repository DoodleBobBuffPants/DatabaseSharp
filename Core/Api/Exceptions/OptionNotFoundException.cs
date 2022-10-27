namespace Core.Api.Exceptions;

public class OptionNotFoundException : Exception
{
    public OptionNotFoundException(string option) : base($"Option '{option}' is not configured") { }
}
