using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KolekcjaPlyt_Web.Models;

public partial class KolekcjaPlytContext : DbContext
{
    public KolekcjaPlytContext()
    {
    }

    public KolekcjaPlytContext(DbContextOptions<KolekcjaPlytContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Czlonek> Czloneks { get; set; }

    public virtual DbSet<Nabycie> Nabycies { get; set; }

    public virtual DbSet<Plytum> Plyta { get; set; }

    public virtual DbSet<Utwor> Utwors { get; set; }

    public virtual DbSet<Wykonawca> Wykonawcas { get; set; }

    public virtual DbSet<Wypozyczajacy> Wypozyczajacies { get; set; }

    public virtual DbSet<Wypozyczenie> Wypozyczenies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-SD34DFM;Initial Catalog=KolekcjaPlyt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Czlonek>(entity =>
        {
            entity.HasKey(e => e.IdCzlonek).HasName("PK__Czlonek__F58F4A4DF3387811");

            entity.ToTable("Czlonek");

            entity.Property(e => e.Czlonek1)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Czlonek");
            entity.Property(e => e.Rola)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.IdWykonawcaNavigation).WithMany(p => p.Czloneks)
                .HasForeignKey(d => d.IdWykonawca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Czlonek__IdWykon__4E88ABD4");
        });

        modelBuilder.Entity<Nabycie>(entity =>
        {
            entity.HasKey(e => e.IdNabycie).HasName("PK__Nabycie__217E89B718BFFEA7");

            entity.ToTable("Nabycie");

            entity.Property(e => e.Cena).HasColumnType("money");
            entity.Property(e => e.DataNabycia).HasColumnType("date");
        });

        modelBuilder.Entity<Plytum>(entity =>
        {
            entity.HasKey(e => e.IdPlyta).HasName("PK__Plyta__DD5AC4A91FC8731B");

            entity.HasIndex(e => e.IdNabycie, "UQ__Plyta__217E89B6EAFD0AB8").IsUnique();

            entity.Property(e => e.Komentarz)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nazwa)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.RodzajPlyty)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StatusPosiadania)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNabycieNavigation).WithOne(p => p.Plytum)
                .HasForeignKey<Plytum>(d => d.IdNabycie)
                .HasConstraintName("FK__Plyta__IdNabycie__49C3F6B7");
        });

        modelBuilder.Entity<Utwor>(entity =>
        {
            entity.HasKey(e => e.IdUtwor).HasName("PK__Utwor__F7E49E72C71B0343");

            entity.ToTable("Utwor");

            entity.Property(e => e.GatunekMuzyczny)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Komentarz)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tytul)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPlytaNavigation).WithMany(p => p.Utwors)
                .HasForeignKey(d => d.IdPlyta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Utwor__IdPlyta__4CA06362");

            entity.HasOne(d => d.IdWykonawcaNavigation).WithMany(p => p.Utwors)
                .HasForeignKey(d => d.IdWykonawca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Utwor__IdWykonaw__4D94879B");
        });

        modelBuilder.Entity<Wykonawca>(entity =>
        {
            entity.HasKey(e => e.IdWykonawca).HasName("PK__Wykonawc__81CE0D3DF612D6C6");

            entity.ToTable("Wykonawca");

            entity.HasIndex(e => e.Wykonawca1, "UQ__Wykonawc__5E99EA05BC897C17").IsUnique();

            entity.Property(e => e.Wykonawca1)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("Wykonawca");
        });

        modelBuilder.Entity<Wypozyczajacy>(entity =>
        {
            entity.HasKey(e => e.IdWypozyczajacy).HasName("PK__Wypozycz__141603C83350901A");

            entity.ToTable("Wypozyczajacy");

            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Imie)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.KodPocztowy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Miasto)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NrTelefonu)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.NumerMieszkania)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ulica)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Wypozyczenie>(entity =>
        {
            entity.HasKey(e => e.IdWypozyczenie).HasName("PK__Wypozycz__17EC2FBFA39B60F3");

            entity.ToTable("Wypozyczenie");

            entity.Property(e => e.DataOddania).HasColumnType("date");
            entity.Property(e => e.DataWypozyczenia).HasColumnType("date");

            entity.HasOne(d => d.IdPlytaNavigation).WithMany(p => p.Wypozyczenies)
                .HasForeignKey(d => d.IdPlyta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wypozycze__IdPly__4AB81AF0");

            entity.HasOne(d => d.IdWypozyczajacyNavigation).WithMany(p => p.Wypozyczenies)
                .HasForeignKey(d => d.IdWypozyczajacy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wypozycze__IdWyp__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
