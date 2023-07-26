namespace Byteology.Website.Inquiry;

public class SubmissionEventArgs : EventArgs
{
	public bool Success { get; private set; }

	public SubmissionEventArgs(bool success)
	{
		Success = success;
	}
}
