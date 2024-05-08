using AndriiKlym.Mailtrap.Client.Models;
using System.Net.Mail;

namespace AndriiKlym.Mailtrap.Client.Tests
{
    public class MailtrapMessageTests
    {
        /// <summary>
        /// Tests that the constructor initializes the properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            var from = new MailAddress("from@example.com");
            var to = new MailAddress("to@example.com");
            var subject = "Test Subject";
            var text = "Test Text";
            var html = "<p>Test HTML</p>";

            // Act
            var message = new MailtrapMessage(from, to, subject, text, html);

            // Assert
            Assert.Equal(from, message.From);
            Assert.Equal(to, message.To);
            Assert.Equal(subject, message.Subject);
            Assert.Equal(text, message.Text);
            Assert.Equal(html, message.Html);
        }

        [Fact]
        /// <summary>
        /// Tests that the constructor initializes the properties correctly.
        /// </summary>
        public void Constructor_WithStrings_InitializesPropertiesCorrectly()
        {
            // Arrange
            var from = "from@example.com";
            var to = "to@example.com";

            // Act
            var message = new MailtrapMessage(from, to);

            // Assert
            Assert.Equal(from, message.From.Address);
            Assert.Equal(to, message.To.Address);
        }

        [Fact]
        /// <summary>
        /// Tests that the To property can be set and retrieved correctly.
        /// </summary>
        public void ToProperty_GetAndSet_WorksCorrectly()
        {
            // Arrange
            var initialFrom = new MailAddress("from@example.com");
            var initialTo = new MailAddress("to@example.com");
            var message = new MailtrapMessage(initialFrom, initialTo);
            var newTo = new MailAddress("newto@example.com");

            // Act
            message.To = newTo;
            var retrievedTo = message.To;

            // Assert
            Assert.Equal(newTo, retrievedTo);
        }

        [Fact]
        /// <summary>
        /// Tests that the To property can throw an exception when set to null.
        /// </summary>
        public void ToProperty_GetAndSet_ThrowsException()
        {
            // Arrange
            var initialFrom = new MailAddress("from@example.com");
            var initialTo = new MailAddress("to@example.com");
            var message = new MailtrapMessage(initialFrom, initialTo);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => message.To = null);
        }

        [Fact]
        /// <summary>
        /// Tests that the From property can be set and retrieved correctly.
        /// </summary>
        public void FromProperty_GetAndSet_WorksCorrectly()
        {
            // Arrange
            var initialFrom = new MailAddress("from@example.com");
            var initialTo = new MailAddress("to@example.com");
            var message = new MailtrapMessage(initialFrom, initialTo);
            var newFrom = new MailAddress("newfrom@example.com");

            // Act
            message.From = newFrom;
            var retrievedFrom = message.From;

            // Assert
            Assert.Equal(newFrom, retrievedFrom);
        }

        [Fact]
        /// <summary>
        /// Tests that the From property can throw an exception when set to null.
        /// </summary>
        public void FromProperty_GetAndSet_ThrowsException()
        {
            // Arrange
            var initialFrom = new MailAddress("from@example.com");
            var initialTo = new MailAddress("to@example.com");
            var message = new MailtrapMessage(initialFrom, initialTo);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => message.From = null);
        }
    }
}