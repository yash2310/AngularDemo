using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ApplicationCore
{
    public class NotificationLog
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Receiver Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject Required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message Required")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Date Required")]
        public DateTime Date { get; set; }
    }

}
