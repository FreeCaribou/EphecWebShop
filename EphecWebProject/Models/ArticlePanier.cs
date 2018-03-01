using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EphecWebProject.Models
{
    public class ArticlePanier
    {
        public int IdArticle { get; set; }

        [Display(Name = "Article")]
        public string LibelleArticle { get; set; }

        [Display(Name = "Quantité")]
        public int QuantiteArticle { get; set; }

        [Display(Name = "Prix unitaire")]
        public decimal PrixUnitaire { get; set; }

    }
}