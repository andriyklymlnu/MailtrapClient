using AndriiKlym.Mailtrap.Client;
using AndriiKlym.Mailtrap.Client.Models;
using System.Net.Mail;

using IMailtrapClient client = new MailtrapClient("", "");

var message = new MailtrapMessage(new MailAddress("from@example.com"), new MailAddress("to@example.com"),
    "Test subject", "My first email", "<b>Message</b>");

await client.Send(message);