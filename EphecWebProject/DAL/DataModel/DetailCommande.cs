namespace EphecWebProject.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailCommande")]
    public partial class DetailCommande
    {
        [Key]
        public int DCOM_Id { get; set; }

        public int DCOM_COM_Id { get; set; }

        public int DCOM_ART_Id { get; set; }

        [Display(Name = "Quantité")]
        public int DCOM_Quantite { get; set; }

        [Display(Name = "Prix unitaire")]
        public decimal DCOM_PrixUnitaire { get; set; }

        public virtual Article Article { get; set; }

        public virtual Commande Commande { get; set; }
    }
}
