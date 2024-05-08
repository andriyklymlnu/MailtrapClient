using AndriiKlym.Mailtrap.Client.Models;
using System.Net;
using System.Net.Mail;

namespace AndriiKlym.Mailtrap.Client
{
    /// <summary>
    /// Mailtrap client class. Initializes instance with available methods.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class MailtrapClient: IDisposable
    {
        /// <summary>
        /// The SMTP client
        /// </summary>
        private readonly SmtpClient _client;

        /// <summary>
        /// The dispose SMTP client
        /// </summary>
        private readonly bool _disposeSmtpClient;

        /// <summary>
        /// The lock
        /// </summary>
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="MailtrapClient" /> class.
        /// </summary>
        /// <param name="username">Mailtrap username.</param>
        /// <param name="password">Mailtrap password.</param>
        /// <param name="host">Optional mailtrap host. Skip this param to use default value</param>
        /// <param name="port">Optional mailtrap port. Skip this param to use default value</param>
        /// <param name="_disposeSmtpClient">if set to <c>true</c> [dispose SMTP client]. Use false to create singleton MailtrapClient</param>
        public MailtrapClient(string username, string password, string host = "sandbox.smtp.mailtrap.io", int port = 2525,
            bool _disposeSmtpClient = true)
        {
            _client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_disposeSmtpClient)
            {
                _client.Dispose();
            }
        }

        /// <summary>
        /// Sends an email using given mail params.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Send(MailtrapMessage message)
        {
            ValidateParams(message);

            var mailMessage = PrepareMailMessage(message);

            await Send(mailMessage);
        }

        /// <summary>
        /// Sends the specified mail message.
        /// </summary>
        /// <param name="mailMessage">The mail message.</param>
        private async Task Send(MailMessage mailMessage)
        {
            await _lock.WaitAsync();
            try
            {
                await _client.SendMailAsync(mailMessage);
            }
            finally
            {
                _lock.Release();
            }
        }

        /// <summary>
        /// Validates the parameters.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="InvalidOperationException">SMTP client is not initialized.</exception>
        /// <exception cref="ArgumentNullException">message</exception>
        private void ValidateParams(MailtrapMessage message)
        {
            if (_client is null) throw new InvalidOperationException("SMTP client is not initialized.");
            if (message is null) throw new ArgumentNullException(nameof(message));
        }

        /// <summary>
        /// Prepares the mail message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The prepared <see cref="MailMessage"/>.</returns>
        private static MailMessage PrepareMailMessage(MailtrapMessage message)
        {
            var mailMessage = new MailMessage(message.From, message.To);

            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Html ?? message.Text;
            mailMessage.IsBodyHtml = !string.IsNullOrEmpty(message.Html);

            if (message.Attachments?.Any() ?? false)
                message.Attachments.ForEach(mailMessage.Attachments.Add);
            return mailMessage;
        }
    }
}
