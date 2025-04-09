using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Concession> Concessions { get; set; }

    public virtual DbSet<ConcessionBooked> ConcessionBookeds { get; set; }

    public virtual DbSet<ConcessionConcessionbooked> ConcessionConcessionbookeds { get; set; }

    public virtual DbSet<ConcessionType> ConcessionTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Format> Formats { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LimitAge> LimitAges { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<SeatBooked> SeatBookeds { get; set; }

    public virtual DbSet<SeatType> SeatTypes { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketBooked> TicketBookeds { get; set; }

    public virtual DbSet<TicketTicketbooked> TicketTicketbookeds { get; set; }

    public virtual DbSet<TicketType> TicketTypes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DatabaseHost");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("area_pkey");

            entity.ToTable("area");

            entity.HasIndex(e => e.NameEn, "area_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "area_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("booking_pkey");

            entity.ToTable("booking");

            entity.HasIndex(e => e.ConcessionBookedId, "booking_concession_booked_id_key").IsUnique();

            entity.HasIndex(e => e.TicketBookedId, "booking_ticket_booked_id_key").IsUnique();

            entity.HasIndex(e => e.TransactionId, "booking_transaction_id_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ConcessionBookedId).HasColumnName("concession_booked_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(now())::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.TicketBookedId).HasColumnName("ticket_booked_id");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.ConcessionBooked).WithOne(p => p.Booking)
                .HasForeignKey<Booking>(d => d.ConcessionBookedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conbk_ref");

            entity.HasOne(d => d.Showtime).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ShowtimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("st_ref");

            entity.HasOne(d => d.TicketBooked).WithOne(p => p.Booking)
                .HasForeignKey<Booking>(d => d.TicketBookedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tckbk_ref");

            entity.HasOne(d => d.Transaction).WithOne(p => p.Booking)
                .HasForeignKey<Booking>(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tran_ref");
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cinema_pkey");

            entity.ToTable("cinema");

            entity.HasIndex(e => e.Address, "cinema_address_key").IsUnique();

            entity.HasIndex(e => e.NameEn, "cinema_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "cinema_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
            entity.Property(e => e.NumRooms)
                .HasDefaultValue(1)
                .HasColumnName("num_rooms");

            entity.HasOne(d => d.Area).WithMany(p => p.Cinemas)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("area_ref");
        });

        modelBuilder.Entity<Concession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("concession_pkey");

            entity.ToTable("concession");

            entity.HasIndex(e => e.NameEn, "concession_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "concession_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ConcessionTypeId).HasColumnName("concession_type_id");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .HasColumnName("img_url");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(10000)
                .HasColumnName("quantity");

            entity.HasOne(d => d.ConcessionType).WithMany(p => p.Concessions)
                .HasForeignKey(d => d.ConcessionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("con_type_ref");
        });

        modelBuilder.Entity<ConcessionBooked>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("concession_booked_pkey");

            entity.ToTable("concession_booked");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");
        });

        modelBuilder.Entity<ConcessionConcessionbooked>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("concession_concessionbooked_pkey");

            entity.ToTable("concession_concessionbooked");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ConcessionBookedId).HasColumnName("concession_booked_id");
            entity.Property(e => e.ConcessionId).HasColumnName("concession_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(0)
                .HasColumnName("quantity");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");

            entity.HasOne(d => d.ConcessionBooked).WithMany(p => p.ConcessionConcessionbookeds)
                .HasForeignKey(d => d.ConcessionBookedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("con_type_ref");

            entity.HasOne(d => d.Concession).WithMany(p => p.ConcessionConcessionbookeds)
                .HasForeignKey(d => d.ConcessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("con_ref");
        });

        modelBuilder.Entity<ConcessionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("concession_type_pkey");

            entity.ToTable("concession_type");

            entity.HasIndex(e => e.NameEn, "concession_type_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "concession_type_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("country_pkey");

            entity.ToTable("country");

            entity.HasIndex(e => e.NameEn, "country_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "country_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<Format>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("format_pkey");

            entity.ToTable("format");

            entity.HasIndex(e => e.NameEn, "format_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "format_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genre_pkey");

            entity.ToTable("genre");

            entity.HasIndex(e => e.NameEn, "genre_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "genre_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("language_pkey");

            entity.ToTable("language");

            entity.HasIndex(e => e.NameEn, "language_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "language_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<LimitAge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("limit_age_pkey");

            entity.ToTable("limit_age");

            entity.HasIndex(e => e.NameEn, "limit_age_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "limit_age_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("membership_pkey");

            entity.ToTable("membership");

            entity.HasIndex(e => e.UserId, "membership_user_id_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Point)
                .HasDefaultValue(0)
                .HasColumnName("point");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Membership)
                .HasForeignKey<Membership>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_ref");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movie_pkey");

            entity.ToTable("movie");

            entity.HasIndex(e => e.NameEn, "movie_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "movie_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Actor)
                .HasMaxLength(255)
                .HasColumnName("actor");
            entity.Property(e => e.BriefEn).HasColumnName("brief_en");
            entity.Property(e => e.BriefVn).HasColumnName("brief_vn");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Director)
                .HasMaxLength(255)
                .HasColumnName("director");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.FormatId).HasColumnName("format_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.LimitAgeId).HasColumnName("limit_age_id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
            entity.Property(e => e.PosterUrl)
                .HasMaxLength(255)
                .HasColumnName("poster_url");
            entity.Property(e => e.ReleasedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("released_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TrailerUrl)
                .HasMaxLength(255)
                .HasColumnName("trailer_url");

            entity.HasOne(d => d.Country).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("cnt_ref");

            entity.HasOne(d => d.Format).WithMany(p => p.Movies)
                .HasForeignKey(d => d.FormatId)
                .HasConstraintName("fmt_ref");

            entity.HasOne(d => d.Language).WithMany(p => p.Movies)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("lang_ref");

            entity.HasOne(d => d.LimitAge).WithMany(p => p.Movies)
                .HasForeignKey(d => d.LimitAgeId)
                .HasConstraintName("lma_ref");

            entity.HasMany(d => d.Genres).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MoviesAndGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("gen_ref"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("mv_ref"),
                    j =>
                    {
                        j.HasKey("MovieId", "GenreId").HasName("db_pk");
                        j.ToTable("movies_and_genres");
                        j.IndexerProperty<Guid>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<Guid>("GenreId").HasColumnName("genre_id");
                    });
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("room_pkey");

            entity.ToTable("room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CinemaId).HasColumnName("cinema_id");
            entity.Property(e => e.NumSeats).HasColumnName("num_seats");
            entity.Property(e => e.RoomType)
                .HasMaxLength(255)
                .HasColumnName("room_type");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("cinema_ref");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_pkey");

            entity.ToTable("seat");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.SeatPos)
                .HasMaxLength(255)
                .HasColumnName("seat_pos");
            entity.Property(e => e.SeatTypeId).HasColumnName("seat_type_id");

            entity.HasOne(d => d.Room).WithMany(p => p.Seats)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("room_ref");

            entity.HasOne(d => d.SeatType).WithMany(p => p.Seats)
                .HasForeignKey(d => d.SeatTypeId)
                .HasConstraintName("sttp_ref");
        });

        modelBuilder.Entity<SeatBooked>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_booked_pkey");

            entity.ToTable("seat_booked");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");

            entity.HasOne(d => d.Booking).WithMany(p => p.SeatBookeds)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bk_ref");

            entity.HasOne(d => d.Seat).WithMany(p => p.SeatBookeds)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("st_ref");
        });

        modelBuilder.Entity<SeatType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_type_pkey");

            entity.ToTable("seat_type");

            entity.HasIndex(e => e.NameEn, "seat_type_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "seat_type_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showtime_pkey");

            entity.ToTable("showtime");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.DateShow).HasColumnName("date_show");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Movie).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("mov_ref");

            entity.HasOne(d => d.Room).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("room_ref");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticket_pkey");

            entity.ToTable("ticket");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");

            entity.HasOne(d => d.TicketType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketTypeId)
                .HasConstraintName("tictype_ref");
        });

        modelBuilder.Entity<TicketBooked>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticket_booked_pkey");

            entity.ToTable("ticket_booked");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");
        });

        modelBuilder.Entity<TicketTicketbooked>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticket_ticketbooked_pkey");

            entity.ToTable("ticket_ticketbooked");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TicketBookedId).HasColumnName("ticket_booked_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");

            entity.HasOne(d => d.TicketBooked).WithMany(p => p.TicketTicketbookeds)
                .HasForeignKey(d => d.TicketBookedId)
                .HasConstraintName("ticbk_ref");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketTicketbookeds)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("tic_ref");
        });

        modelBuilder.Entity<TicketType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticket_type_pkey");

            entity.ToTable("ticket_type");

            entity.HasIndex(e => e.NameEn, "ticket_type_name_en_key").IsUnique();

            entity.HasIndex(e => e.NameVn, "ticket_type_name_vn_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.NameVn)
                .HasMaxLength(255)
                .HasColumnName("name_vn");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(255)
                .HasColumnName("account_number");
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .HasColumnName("bank_name");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(now())::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("total_price");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usr_ref");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.AvtUrl)
                .HasMaxLength(255)
                .HasColumnName("avt_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(now())::timestamp without time zone")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
