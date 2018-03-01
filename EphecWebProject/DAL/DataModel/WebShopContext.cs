namespace EphecWebProject.Models.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebShopContext : DbContext
    {
        public WebShopContext()
            : base("name=WebShopContext")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<DetailCommande> DetailCommandes { get; set; }
        public virtual DbSet<SousCategorie> SousCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.ART_Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.ART_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.ART_Prix)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.DetailCommandes)
                .WithRequired(e => e.Article)
                .HasForeignKey(e => e.DCOM_ART_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categorie>()
                .Property(e => e.CAT_Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.SousCategories)
                .WithRequired(e => e.Categorie)
                .HasForeignKey(e => e.SCAT_CAT_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_Civilite)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_Password)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_CodePostal)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_Ville)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLI_Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.COM_CLI_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.COM_Statut)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.COM_Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.COM_Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.COM_Civilite)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.COM_Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.COM_CodePostal)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.COM_Ville)
                .IsUnicode(false);

            modelBuilder.Entity<Commande>()
                .HasMany(e => e.DetailCommandes)
                .WithRequired(e => e.Commande)
                .HasForeignKey(e => e.DCOM_COM_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetailCommande>()
                .Property(e => e.DCOM_PrixUnitaire)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SousCategorie>()
                .Property(e => e.SCAT_Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<SousCategorie>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.SousCategorie)
                .HasForeignKey(e => e.ART_SCAT_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
