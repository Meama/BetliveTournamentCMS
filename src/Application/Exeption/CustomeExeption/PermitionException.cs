namespace Application.Exeption.CustomeExeption;

public class PermitionException : Exception
{
	public PermitionException(string[] messages, string permitionName) : base(messages?.FirstOrDefault())
	{
		Messages = messages;
        PermitionName = permitionName;
	}
	
	public string[] Messages { get; set; }

	public string PermitionName { get; set; }
}