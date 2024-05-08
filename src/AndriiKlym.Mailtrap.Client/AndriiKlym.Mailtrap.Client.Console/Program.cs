using AndriiKlym.Mailtrap.Client;
using AndriiKlym.Mailtrap.Client.Models;
using System.Net.Mail;

using var client = new MailtrapClient("28284b8c6ed2fb", "a697ee4075da06");

var message = new MailtrapMessage(new MailAddress("andriyklymc@gmail.com"), new MailAddress("andrii_klym@epam.com"),
    "Test subject", "My first email", "<b>Message</b>");

await client.Send(message);