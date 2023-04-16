using System.ComponentModel.DataAnnotations;

namespace MiodOdStaniula.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Podaj swoje imię")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Podaj swoje nazwisko")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Podaj nr telefonu")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Podaj swoj adres email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Podaj miejscowość")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Podaj ulicę")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Podaj nr domu")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Podaj kod pocztowy")]
        public string? PostalCode { get; set; }
    }
}
