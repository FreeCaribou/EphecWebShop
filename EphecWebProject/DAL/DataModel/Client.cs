namespace EphecWebProject.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Commandes = new HashSet<Commande>();
        }

        [Key]
        public int CLI_Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nom du client")]
        public string CLI_Nom { get; set; }

        [StringLength(50)]
        public string CLI_Prenom { get; set; }

        [Required]
        [StringLength(50)]
        public string CLI_Civilite { get; set; }

        [Required]
        [StringLength(50)]
        public string CLI_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string CLI_Password { get; set; }

        [Required]
        [StringLength(50)]
        public string CLI_Adresse { get; set; }

        [Required]
        [StringLength(50)]
        public string CLI_CodePostal { get; set; }

        [Required]
        [StringLength(50)]
        public string CLI_Ville { get; set; }

        [Required]
        [StringLength(50)]
        public string CLI_Telephone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
