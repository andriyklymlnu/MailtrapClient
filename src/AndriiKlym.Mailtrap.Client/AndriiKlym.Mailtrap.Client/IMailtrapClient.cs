using AndriiKlym.Mailtrap.Client.Models;

namespace AndriiKlym.Mailtrap.Client
{
    public interface IMailtrapClient: IDisposable
    {
        /// <summary>
        /// Sends an email using given mail params.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Send(MailtrapMessage message);
    }
}