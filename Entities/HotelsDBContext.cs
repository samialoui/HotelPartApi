using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HotelPartApi
{
    public partial class HotelsDBContext : DbContext
    {
        public HotelsDBContext()
        {
        }

        public HotelsDBContext(DbContextOptions<HotelsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrateur> Administrateur { get; set; }
        public virtual DbSet<Blogeur> Blogeur { get; set; }
        public virtual DbSet<Chambre> Chambre { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Facture> Facture { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Saison> Saison { get; set; }
        public virtual DbSet<ServiceHot> ServiceHot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EV8IHV1;Database=HotelsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrateur>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("administrateur_PK");

                entity.ToTable("administrateur");

                entity.Property(e => e.AdminId).HasColumnName("adminId");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CodePostal)
                    .IsRequired()
                    .HasColumnName("codePostal")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NumTele)
                    .IsRequired()
                    .HasColumnName("numTele")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Quartier)
                    .IsRequired()
                    .HasColumnName("quartier")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasColumnName("ville")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Blogeur>(entity =>
            {
                entity.HasKey(e => e.BlogId)
                    .HasName("blogeur_PK");

                entity.ToTable("blogeur");

                entity.Property(e => e.BlogId).HasColumnName("blogId");

                entity.Property(e => e.Descript)
                    .IsRequired()
                    .HasColumnName("descript")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pays)
                    .IsRequired()
                    .HasColumnName("pays")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chambre>(entity =>
            {
                entity.ToTable("chambre");

                entity.Property(e => e.ChambreId).HasColumnName("chambreId");

                entity.Property(e => e.ChambreNum).HasColumnName("chambreNum");

                entity.Property(e => e.Descript)
                    .IsRequired()
                    .HasColumnName("descript")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Disponibilité).HasColumnName("disponibilité");

                entity.Property(e => e.NbLit).HasColumnName("nbLit");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PrixNuit).HasColumnName("prixNuit");

                entity.Property(e => e.Saison).HasColumnName("saison");

                entity.Property(e => e.TypeChamb)
                    .IsRequired()
                    .HasColumnName("typeChamb")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.SaisonNavigation)
                    .WithMany(p => p.Chambre)
                    .HasForeignKey(d => d.Saison)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkChambreSaison");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CodePostal)
                    .IsRequired()
                    .HasColumnName("codePostal")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NumTele)
                    .IsRequired()
                    .HasColumnName("numTele")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Quartier)
                    .IsRequired()
                    .HasColumnName("quartier")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasColumnName("ville")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Facture>(entity =>
            {
                entity.HasKey(e => e.FactId)
                    .HasName("facture_PK");

                entity.ToTable("facture");

                entity.Property(e => e.FactId).HasColumnName("factId");

                entity.Property(e => e.DateFact)
                    .IsRequired()
                    .HasColumnName("dateFact")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Facture)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKFactureService");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("hotel");

                entity.Property(e => e.HotelId)
                    .HasColumnName("hotelId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnName("adresse")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NumTele)
                    .IsRequired()
                    .HasColumnName("numTele")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasColumnName("ville")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.TypeP)
                    .IsRequired()
                    .HasColumnName("typeP")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChambreId).HasColumnName("chambreId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Confirmation).HasColumnName("confirmation");

                entity.Property(e => e.Coupon)
                    .IsRequired()
                    .HasColumnName("coupon")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateArr)
                    .IsRequired()
                    .HasColumnName("dateArr")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateDep)
                    .IsRequired()
                    .HasColumnName("date_dep")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DemandSpecial)
                    .IsRequired()
                    .HasColumnName("demandSpecial")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FactId).HasColumnName("factId");

                entity.Property(e => e.NbPers).HasColumnName("nbPers");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.Prix).HasColumnName("prix");

                entity.HasOne(d => d.Chambre)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.ChambreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReservationChambre");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReservationClient");

                entity.HasOne(d => d.Fact)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.FactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReservationFacture");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKReservationPayment");
            });

            modelBuilder.Entity<Saison>(entity =>
            {
                entity.HasKey(e => e.IdSaison)
                    .HasName("saison_PK");

                entity.ToTable("saison");

                entity.Property(e => e.IdSaison).HasColumnName("idSaison");

                entity.Property(e => e.DateS)
                    .IsRequired()
                    .HasColumnName("dateS")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NomS)
                    .IsRequired()
                    .HasColumnName("nomS")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceHot>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("service_PK");

                entity.ToTable("serviceHot");

                entity.Property(e => e.ServiceId).HasColumnName("serviceId");

                entity.Property(e => e.Descript)
                    .IsRequired()
                    .HasColumnName("descript")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NomS)
                    .IsRequired()
                    .HasColumnName("nomS")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("photo")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Prix).HasColumnName("prix");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
