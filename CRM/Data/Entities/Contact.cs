namespace Crm.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum PhoneNrType : byte
    {
        Other, Mobile, Home, Work
    }

    [Table("Contacts")]
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public PhoneNrType PhoneType { get; set; }

        [Required, StringLength(32, MinimumLength = 1)]
        public string PhoneNr { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}