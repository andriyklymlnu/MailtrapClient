#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;

namespace AndriiKlym.Mailtrap.Client.Models
{
    public class MailtrapMessage
    {
        /// <summary>
        /// The email address of the sender.
        /// </summary>
        private MailAddress _from;

        /// <summary>
        /// The email address of the recipient.
        /// </summary>
        private MailAddress _to;

        /// <summary>
        /// The subject of the email.
        /// </summary>
        private string? _subject;

        /// <summary>
        /// The email address of the sender.
        /// </summary>
        [DisallowNull]
        public MailAddress From
        {
            get
            {
                return _from;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                _from = value;
            }
        }

        /// <summary>
        /// The email address of the recipient.
        /// </summary>
        [DisallowNull]
        public MailAddress To
        {
            get
            {
                return _to;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                _to = value;
            }
        }

        /// <summary>
        /// The subject of the email.
        /// </summary>
        [AllowNull]
        public string Subject
        {
            get
            {
                return _subject ?? string.Empty;
            }
            set
            {
                _subject = value;
            }
        }

        /// <summary>
        /// The plain text content of the email.
        /// </summary>
        /// <remarks>
        /// Html property will override Text property.
        /// </remarks>
        public string? Text { get; set; }

        /// <summary>
        /// The HTML content of the email.
        /// </summary>
        /// <remarks>
        /// Html property will override Text property.
        /// </remarks>
        public string? Html { get; set; }

        /// <summary>
        /// The list of attachments for the email.
        /// </summary>
        public List<Attachment>? Attachments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MailtrapMessage"/> class.
        /// </summary>
        /// <param name="from">The email address of the sender.</param>
        /// <param name="to">The email address of the recipient.</param>
        public MailtrapMessage(MailAddress from, MailAddress to)
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MailtrapMessage"/> class.
        /// </summary>
        /// <param name="from">The email address of the sender.</param>
        /// <param name="to">The email address of the recipient.</param>
        public MailtrapMessage(string from, string to)
            : this(new MailAddress(from), new MailAddress(to))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MailtrapMessage"/> class.
        /// </summary>
        /// <param name="from">The email address of the sender.</param>
        /// <param name="to">The email address of the recipient.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="text">The plain text content of the email. Html property will override Text property.</param>
        /// <param name="html">The HTML content of the email. Html property will override Text property.</param>
        /// <param name="attachments">The list of attachments for the email.</param>
        public MailtrapMessage(MailAddress from, MailAddress to, string? subject = null, string? text = null, string? html = null,
            List<Attachment>? attachments = null) : this(from, to)
        {
            _subject = subject;
            From = from;
            To = to;
            Subject = subject;
            Text = text;
            Html = html;
            Attachments = attachments;
        }
    }
}
