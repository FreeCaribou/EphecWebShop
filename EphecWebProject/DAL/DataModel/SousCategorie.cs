namespace EphecWebProject.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SousCategorie")]
    public partial class SousCategorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SousCategorie()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        public int SCAT_Id { get; set; }

        public int SCAT_CAT_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SCAT_Libelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        public virtual Categorie Categorie { get; set; }
    }
}
