using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CinemaApp.Models;

public partial class CinemaDBContext : DbContext
{
    public CinemaDBContext()
    {
    }

    public CinemaDBContext(DbContextOptions<CinemaDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Screening> Screenings { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
                .UseLazyLoadingProxies()
    //.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=cinema;Database=CinemaDB;Multiplexing=false");

    .UseNpgsql("Server=dumbo.db.elephantsql.com;Port=5432;User Id=zoklcmtd;Password=T1Oopp1SSefey0-vJlmLCgkiduQARiRU;Database=zoklcmtd;Multiplexing=false");

    //.UseNpgsql("Server=cinemadb.caf3r9ug2dls.eu-north-1.rds.amazonaws.com;Port=5432;User Id=cinema;Password=altxnnnasd;Database=init_cinema_db;Multiplexing=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("accounts_pkey");

            entity.ToTable("accounts");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Ticketsid).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.HasIndex(e => e.Username, "fki_tickets_user_fkey");

            entity.Property(e => e.Ticketsid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ticketsid");
            entity.Property(e => e.Screeningday)
                .HasMaxLength(15)
                .HasColumnName("screeningday");
            entity.Property(e => e.Screeningtime)
                .HasMaxLength(10)
                .HasColumnName("screeningtime");
            entity.Property(e => e.Seatcolumn).HasColumnName("seatcolumn");
            entity.Property(e => e.Seatrow).HasColumnName("seatrow");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_user_fkey");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("languages_pkey");

            entity.ToTable("languages");

            entity.Property(e => e.LanguageId).HasColumnName("languageid");
            entity.Property(e => e.Language1)
                .HasMaxLength(30)
                .HasColumnName("language");
            entity.Property(e => e.MovieId).HasColumnName("movieid");

            entity.HasOne(d => d.Movie).WithMany(p => p.Languages)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("languages_movieid_fkey");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("movies_pkey");

            entity.ToTable("movies");

            entity.Property(e => e.MovieId).HasColumnName("movieid");
            entity.Property(e => e.AgeLimit).HasColumnName("agelimit");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.MovieLength)
                .HasMaxLength(10)
                .HasColumnName("movieLength");
            entity.Property(e => e.Genre)
                .HasMaxLength(30)
                .HasColumnName("genre");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Screening>(entity =>
        {
            entity.HasKey(e => e.ScreeningId).HasName("screenings_pkey");

            entity.ToTable("screenings");

            entity.Property(e => e.ScreeningId).HasColumnName("screeningid");
            entity.Property(e => e.LanguageId)
                .ValueGeneratedOnAdd()
                .HasColumnName("languageid");
            entity.Property(e => e.MovieId).HasColumnName("movieid");
            entity.Property(e => e.ScreeningTime)
                .HasMaxLength(10)
                .HasColumnName("screeningtime");
            entity.Property(e => e.ScreeningDay)
                .HasMaxLength(10)
                .HasColumnName("screeningday");
            entity.Property(e => e.SeatsId)
                .ValueGeneratedOnAdd()
                .HasColumnName("seatsid");

            entity.HasOne(d => d.Language).WithMany(p => p.Screenings)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("screenings_languageid_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.Screenings)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("screenings_movieid_fkey");

            entity.HasOne(d => d.Seats).WithMany(p => p.Screenings)
                .HasForeignKey(d => d.SeatsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("screenings_seatsid_fkey");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatsId).HasName("seats_pkey");

            entity.ToTable("seats");

            entity.Property(e => e.SeatsId).HasColumnName("seatsid");
            entity.Property(e => e.AvailableSeats).HasColumnName("availableseats");
        });
    }
}