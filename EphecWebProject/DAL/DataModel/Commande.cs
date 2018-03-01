namespace EphecWebProject.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Commande")]
    public partial class Commande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commande()
        {
            DetailCommandes = new HashSet<DetailCommande>();
        }

        [Key]
        [Display(Name = "Numéro de commande")]
        public int COM_Id { get; set; }

        public int COM_CLI_Id { get; set; }
        [Display(Name = "Date de commande")]
        public DateTime COM_Date { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Statut de la commande")]
        public string COM_Statut { get; set; }

        [Display(Name = "Date de livraison souhaité")]
        public DateTime COM_DateLivraison { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nom")]
        public string COM_Nom { get; set; }

        [StringLength(50)]
        [Display(Name = "Prénom")]
        public string COM_Prenom { get; set; }

        [Required]
        [StringLength(50)]
        public string COM_Civilite { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Adresse")]
        public string COM_Adresse { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Code postal")]
        public string COM_CodePostal { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ville")]
        public string COM_Ville { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCommande> DetailCommandes { get; set; }
    }
}
