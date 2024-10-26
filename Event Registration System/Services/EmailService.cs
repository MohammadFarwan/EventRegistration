using SendGrid.Helpers.Mail;
using SendGrid;

namespace Event_Registration_System.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendConfirmationEmailAsync(string toEmail, string participantName, string eventTitle)
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("hasankarraz7@gmail.com", "Event Registration");
            var subject = "Event Registration Confirmation";
            var to = new EmailAddress(toEmail, participantName);
            var plainTextContent = $"Hello {participantName}, you have successfully registered for {eventTitle}.";
            var htmlContent = $"<strong>Hello {participantName}</strong>,<br>You have successfully registered for <strong>{eventTitle}</strong>.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }

}
