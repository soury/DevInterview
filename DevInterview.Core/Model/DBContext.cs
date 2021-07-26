using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alimentazione> Alimentazione { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<TipoVeicolo> TipoVeicolo { get; set; }
        public virtual DbSet<Uso> Uso { get; set; }
        public virtual DbSet<Veicolo> Veicolo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Initial Catalog=texa_test;Data Source=DESKTOP-BDSRIF9\\SQLEXPRESS;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Alimentazione>(entity =>
            {
                entity.ToTable("alimentazione");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marca");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.ToTable("provincia");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Decrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("decrizione");
            });

            modelBuilder.Entity<TipoVeicolo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tipo_veicolo");

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("tipo")
                    .IsFixedLength(true);

                entity.Property(e => e.Descrizione)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<Uso>(entity =>
            {
                entity.ToTable("uso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(100)
                    .HasColumnName("descrizione");
            });

            modelBuilder.Entity<Veicolo>(entity =>
            {
                entity.ToTable("veicolo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cilindrata)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cilindrata");

                entity.Property(e => e.ClasseEuro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("classe_euro");

                entity.Property(e => e.DataImmatricolazione)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("data_immatricolazione");

                entity.Property(e => e.Destinazione)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("destinazione");

                entity.Property(e => e.IdAlimentazione).HasColumnName("id_alimentazione");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");

                entity.Property(e => e.IdUso).HasColumnName("id_uso");

                entity.Property(e => e.Kw)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("kw");

                entity.Property(e => e.EmissioniCo2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("emissioni_co2");

                entity.Property(e => e.MassaComplessiva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("massa_complessiva");

                entity.Property(e => e.TipoVeicolo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("tipo_veicolo")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAlimentazioneNavigation)
                    .WithMany(p => p.Veicolo)
                    .HasForeignKey(d => d.IdAlimentazione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alimentazione");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Veicolo)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_marca");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Veicolo)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_provincia");

                entity.HasOne(d => d.IdUsoNavigation)
                    .WithMany(p => p.Veicolo)
                    .HasForeignKey(d => d.IdUso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_uso");

                entity.HasOne(d => d.TipoVeicoloNavigation)
                    .WithMany(p => p.Veicolo)
                    .HasForeignKey(d => d.TipoVeicolo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tipo_veicolo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
