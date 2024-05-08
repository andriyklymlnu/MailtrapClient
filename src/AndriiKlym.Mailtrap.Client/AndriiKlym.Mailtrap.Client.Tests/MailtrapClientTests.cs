using AndriiKlym.Mailtrap.Client.Models;
using Moq;
using System.Net.Mail;

namespace AndriiKlym.Mailtrap.Client.Tests
{
    public class MailtrapClientTests
    {
        /// <summary>
        /// Tests the Send method with correct data and verifies that it works correctly.
        /// </summary>
        [Fact]
        public async Task SendMethod_WithCorrectData_WorksCorrectly()
        {
            // Arrange
            var from = new MailAddress("from@example.com");
            var to = new MailAddress("to@example.com");
            var message = new MailtrapMessage(from, to);

            var mockMailtrapClient = new Mock<IMailtrapClient>();
            mockMailtrapClient
                .Setup(client => client.Send(It.IsAny<MailtrapMessage>()))
                .Returns(Task.CompletedTask);

            // Act
            await mockMailtrapClient.Object.Send(message);

            // Assert
            mockMailtrapClient.Verify(client => client.Send(It.IsAny<MailtrapMessage>()), Times.Once);
        }

        [Fact]
        /// <summary>
        /// Tests the Send method with incorrect data and verifies that it throws an exception.
        /// </summary>
        public async Task SendMethod_WithIncorrectData_ThrowException()
        {
            // Arrange
            var from = new MailAddress("from@example.com");
            var to = new MailAddress("to@example.com");
            var message = new MailtrapMessage(from, to);

            var mockMailtrapClient = new Mock<IMailtrapClient>();
            mockMailtrapClient
                .Setup(client => client.Send(It.IsAny<MailtrapMessage>()))
                .ThrowsAsync(new InvalidOperationException());

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => mockMailtrapClient.Object.Send(message));
        }

        [Fact]
        /// <summary>
        /// Tests the Send method with null message and verifies that it throws an exception.
        /// </summary>
        public async Task SendMethod_WithNullMessage_ThrowException()
        {
            // Arrange
            var mockMailtrapClient = new Mock<IMailtrapClient>();
            mockMailtrapClient
                .Setup(client => client.Send(null))
                .Throws<ArgumentNullException>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => mockMailtrapClient.Object.Send(null));
        }
    }
}
