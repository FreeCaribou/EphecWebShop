using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EphecWebProject.Models.FormModel
{
    public class FormModelLogin
    {
        [Required(ErrorMessage = "Email manquant", AllowEmptyStrings = false)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mot de passe manquant", AllowEmptyStrings = false)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }

    public class FormModelCreateAccount
    {
        [Required(ErrorMessage = "Nom d'utilisateur manquant", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prénom manquant", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Prenom { get; set; }
        
        public string Civilite { get; set; }

        [Required(ErrorMessage = "Vous devez créer un mot de passe", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vous devez avoir un e-mail", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adresse manquante", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Code Postal manquant", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Code postal")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Ville manquante", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Téléphone manquant", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Telephone { get; set; }
    }

    public class FormModelAdmin
    {
        [Required(ErrorMessage = "Nom d'utilisateur manquant", AllowEmptyStrings = false)]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mot de passe manquant", AllowEmptyStrings = false)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }

    public class FormModelLivraisonCommande
    {
        [Required(ErrorMessage = "Nom manquant", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Civilité manquante", AllowEmptyStrings = false)]
        public string Civilite { get; set; }

        [Required(ErrorMessage = "Adresse manquante", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Code Postal manquante", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Code Postal")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Ville manquantee", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Ville { get; set; }

        [Display(Name = "Date de livraison souhaité")]
        [Required(ErrorMessage = "Date de livraison souhaité manquantee", AllowEmptyStrings = false)]
        public DateTime DateLivraison { get; set; }
    }

}