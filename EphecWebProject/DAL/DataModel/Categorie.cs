namespace EphecWebProject.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categorie")]
    public partial class Categorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categorie()
        {
            SousCategories = new HashSet<SousCategorie>();
        }

        public static explicit operator Categorie(List<Categorie> v)
        {
            throw new NotImplementedException();
        }

        [Key]
        public int CAT_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CAT_Libelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SousCategorie> SousCategories { get; set; }
    }
}
