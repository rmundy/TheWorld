namespace TheWorldVS.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public sealed class ContactViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [StringLength(1024, MinimumLength = 5)]
        public String Message { get; set; }
    }
}
