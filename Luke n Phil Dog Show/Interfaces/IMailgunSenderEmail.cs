namespace Luke_n_Phil_Dog_Show.Interfaces
{
    public interface IMailgunSenderEmail
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
