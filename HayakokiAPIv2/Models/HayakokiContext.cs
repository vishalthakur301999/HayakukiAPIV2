using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HayakokiAPIv2.Models
{
    public partial class HayakokiContext : DbContext
    {
        public HayakokiContext()
        {
        }

        public HayakokiContext(DbContextOptions<HayakokiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TravelBlog> TravelBlogs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.AirportCode)
                    .HasName("airports_pk")
                    .IsClustered(false);

                entity.ToTable("airports");

                entity.Property(e => e.AirportCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AirportName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightNumber)
                    .HasName("Flights_pk")
                    .IsClustered(false);

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AircraftType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("aircraftType");

                entity.Property(e => e.Airline)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalTime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeptTime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DestCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SourceCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.DestCodeNavigation)
                    .WithMany(p => p.FlightDestCodeNavigations)
                    .HasForeignKey(d => d.DestCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Flights_fk1");

                entity.HasOne(d => d.SourceCodeNavigation)
                    .WithMany(p => p.FlightSourceCodeNavigations)
                    .HasForeignKey(d => d.SourceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Flights_fk0");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.SessionId)
                    .HasColumnName("SessionID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Session_fk0");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId)
                    .HasColumnName("TicketID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingTimestamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("flightNumber");

                entity.Property(e => e.PassengerAge).HasColumnName("passengerAge");

                entity.Property(e => e.PassengerGender)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("passengerGender");

                entity.Property(e => e.PassengerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("passengerName");

                entity.Property(e => e.SeatNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("seatNumber");

                entity.Property(e => e.TravelDate).HasColumnName("travelDate");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.FlightNumberNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.FlightNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tickets_fk1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tickets_fk0");
            });

            modelBuilder.Entity<TravelBlog>(entity =>
            {
                entity.HasKey(e => e.Blogid)
                    .HasName("TravelBlogs_pk")
                    .IsClustered(false);

                entity.Property(e => e.Blogid)
                    .HasColumnName("blogid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Articlecontents)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("articlecontents");

                entity.Property(e => e.Articletitle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("articletitle");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("author");

                entity.Property(e => e.Imgurl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imgurl");

                entity.Property(e => e.Posteddate)
                    .HasColumnName("posteddate")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserName, "UQ__User__66DCF95C8EAFD92C")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User__AB6E61649BF0AAD7")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('user')");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
