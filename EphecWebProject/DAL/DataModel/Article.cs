namespace EphecWebProject.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            DetailCommandes = new HashSet<DetailCommande>();
        }

        [Key]
        [Display(Name = "Numéro de l'article")]
        public int ART_Id { get; set; }

        [Display(Name = "Sous catégorie")]
        public int ART_SCAT_Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nom article")]
        public string ART_Libelle { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ART_Description { get; set; }

        [Display(Name = "Prix")]
        public decimal ART_Prix { get; set; }

        [Display(Name = "Stock")]
        public int ART_Stock { get; set; }

        [Display(Name = "Image")]
        public string ART_UrlImage { get; set; }

        [Display(Name = "Sous categorie")]
        public virtual SousCategorie SousCategorie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCommande> DetailCommandes { get; set; }
    }
}
