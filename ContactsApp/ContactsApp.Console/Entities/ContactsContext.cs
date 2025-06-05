using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContactsApp.Console.Entities;

public partial class ContactsContext : DbContext
{
    private string? connectionString;

    public ContactsContext() : base()
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json", false);
        var app = builder.Build();
        connectionString = app.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
    public ContactsContext(DbContextOptions<ContactsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adresses { get; set; }

    public virtual DbSet<Kontakt> Kontakts { get; set; }

    public virtual DbSet<Kontaktmetod> Kontaktmetods { get; set; }

    public virtual DbSet<Kontakttyp> Kontakttyps { get; set; }

    public virtual DbSet<Ort> Orts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Finnish_Swedish_CI_AI");

        modelBuilder.Entity<Adress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adress__3214EC278B38E0AB");

            entity.ToTable("Adress");

            entity.HasIndex(e => new { e.Gata, e.Gatunummer, e.Postnummer }, "UQ__Adress__984739F839F44DCC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Gata).HasMaxLength(30);
            entity.Property(e => e.OrtId).HasColumnName("OrtID");
            entity.Property(e => e.Postnummer).HasMaxLength(6);

            entity.HasOne(d => d.Ort).WithMany(p => p.Adresses)
                .HasForeignKey(d => d.OrtId)
                .HasConstraintName("FK__Adress__OrtID__6383C8BA");
        });

        modelBuilder.Entity<Kontakt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kontakt__3214EC27A1A9291B");

            entity.ToTable("Kontakt");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdressId).HasColumnName("AdressID");
            entity.Property(e => e.Efternamn).HasMaxLength(30);
            entity.Property(e => e.Förnamn).HasMaxLength(30);

            entity.HasOne(d => d.Adress).WithMany(p => p.Kontakts)
                .HasForeignKey(d => d.AdressId)
                .HasConstraintName("FK__Kontakt__AdressI__66603565");
        });

        modelBuilder.Entity<Kontaktmetod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kontaktm__3214EC27EB274A85");

            entity.ToTable("Kontaktmetod");

            entity.HasIndex(e => e.Kontaktdata, "UQ__Kontaktm__F6CACBD79A3CCA1F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KontaktId).HasColumnName("KontaktID");
            entity.Property(e => e.Kontaktdata).HasMaxLength(30);
            entity.Property(e => e.KontakttypId).HasColumnName("KontakttypID");

            entity.HasOne(d => d.Kontakt).WithMany(p => p.Kontaktmetods)
                .HasForeignKey(d => d.KontaktId)
                .HasConstraintName("FK__Kontaktme__Konta__6B24EA82");

            entity.HasOne(d => d.Kontakttyp).WithMany(p => p.Kontaktmetods)
                .HasForeignKey(d => d.KontakttypId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Kontaktme__Konta__6A30C649");
        });

        modelBuilder.Entity<Kontakttyp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kontaktt__3214EC27E4CCE987");

            entity.ToTable("Kontakttyp");

            entity.HasIndex(e => e.Kontakttyp1, "UQ__Kontaktt__80D53880347C2A9A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Kontakttyp1)
                .HasMaxLength(30)
                .HasColumnName("Kontakttyp");
        });

        modelBuilder.Entity<Ort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ort__3214EC277B6D495B");

            entity.ToTable("Ort");

            entity.HasIndex(e => e.Ortsnamn, "UQ__Ort__614189570A405F55").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Beskrivning).HasMaxLength(60);
            entity.Property(e => e.Ortsnamn).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
