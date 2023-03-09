namespace CustomerRegistration.Web.Models
{
    public class ErrorMessageViewModel
    {
        public string Message { get; }

        public ErrorMessageViewModel(string message)
        {
            Message = message;
        }
    }
}