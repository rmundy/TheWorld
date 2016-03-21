namespace TheWorldVS.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    [Serializable]
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
