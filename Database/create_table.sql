CREATE TABLE country(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL
); --

CREATE TABLE limit_age(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL
); --

CREATE TABLE format(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL
); --

CREATE TABLE language(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) NOT NULL,
	name_en VARCHAR(255) NOT NULL
); --

CREATE TABLE genre(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL
); --

CREATE TABLE movie(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	country_id UUID NOT NULL,
	limit_age_id UUID NOT NULL,
	format_id UUID NOT NULL,
	language_id UUID NOT NULL,
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL,
	duration INT NOT NULL,
	director VARCHAR(255) NOT NULL,
	actor VARCHAR(255) NOT NULL,
	released_date TIMESTAMP WITHOUT TIME ZONE NOT NULL,
	end_date TIMESTAMP WITHOUT TIME ZONE,
	brief_vn TEXT,
	brief_en TEXT,
	status INT NOT NULL CONSTRAINT status_value CHECK (status IN (0, 1)),
	image_url VARCHAR(255) NOT NULL,
	poster_url VARCHAR(255),
	trailer_url VARCHAR(255),

	CONSTRAINT cnt_ref FOREIGN KEY (country_id) REFERENCES country(id) ON DELETE CASCADE,
	CONSTRAINT lma_ref FOREIGN KEY (limit_age_id) REFERENCES limit_age(id) ON DELETE CASCADE,
	CONSTRAINT fmt_ref FOREIGN KEY (format_id) REFERENCES format(id) ON DELETE CASCADE,
	CONSTRAINT lang_ref FOREIGN KEY (language_id) REFERENCES language(id) ON DELETE CASCADE
); --

CREATE TABLE movies_and_genres(
	movie_id UUID NOT NULL,
	genre_id UUID NOT NULL,
	
	CONSTRAINT db_pk PRIMARY KEY (movie_id, genre_id),
	CONSTRAINT mv_ref FOREIGN KEY (movie_id) REFERENCES movie(id) ON DELETE CASCADE,
	CONSTRAINT gen_ref FOREIGN KEY (genre_id) REFERENCES genre(id) ON DELETE CASCADE
); --

CREATE TABLE area(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL
); --

CREATE TABLE cinema(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	area_id UUID NOT NULL,
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL,
	address VARCHAR(255) UNIQUE NOT NULL,
	num_rooms INT NOT NULL DEFAULT 1,
	
	CONSTRAINT area_ref FOREIGN KEY (area_id) REFERENCES area(id) ON DELETE CASCADE
); --

CREATE TABLE room(
	id SERIAL PRIMARY KEY,
	cinema_id UUID NOT NULL,
	room_type VARCHAR(255),
	num_seats INT NOT NULL,
	
	CONSTRAINT cinema_ref FOREIGN KEY (cinema_id) REFERENCES cinema(id) ON DELETE CASCADE
); --

CREATE TABLE seat_type(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL
); -- 

CREATE TABLE seat(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	room_id INT NOT NULL,
	seat_type_id UUID NOT NULL,
	seat_pos VARCHAR(255),
	CONSTRAINT room_ref FOREIGN KEY (room_id) REFERENCES room(id) ON DELETE CASCADE,
	CONSTRAINT sttp_ref FOREIGN KEY (seat_type_id) REFERENCES seat_type(id) ON DELETE CASCADE
); --

CREATE TABLE showtime(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	movie_id UUID NOT NULL,
	room_id INT NOT NULL,
	date_show DATE NOT NULL,
	start_time TIME NOT NULL,

	CONSTRAINT mov_ref FOREIGN KEY (movie_id) REFERENCES movie(id) ON DELETE CASCADE,
	CONSTRAINT room_ref FOREIGN KEY (room_id) REFERENCES room(id) ON DELETE CASCADE
);

CREATE TABLE ticket_type(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE ticket(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	ticket_type_id UUID NOT NULL,
	price DECIMAL(10, 2) NOT NULL,

	CONSTRAINT tictype_ref FOREIGN KEY (ticket_type_id) REFERENCES ticket_type(id) ON DELETE CASCADE
);

CREATE TABLE ticket_booked(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	total_price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE ticket_ticketbooked(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	ticket_id UUID NOT NULL,
	ticket_booked_id UUID NOT NULL,
	quantity INT NOT NULL,
	total_price DECIMAL(10, 2) NOT NULL,

	CONSTRAINT tic_ref FOREIGN KEY (ticket_id) REFERENCES ticket(id) ON DELETE CASCADE,
	CONSTRAINT ticbk_ref FOREIGN KEY (ticket_booked_id) REFERENCES ticket_booked(id) ON DELETE CASCADE
);

CREATE TABLE concession_type(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE concession(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	concession_type_id UUID NOT NULL,
	name_vn VARCHAR(255) UNIQUE NOT NULL,
	name_en VARCHAR(255) UNIQUE NOT NULL,
	price DECIMAL(10, 2) NOT NULL,
	img_url VARCHAR(255) NOT NULL,
	quantity INT NOT NULL DEFAULT 10000,

	CONSTRAINT con_type_ref FOREIGN KEY (concession_type_id) REFERENCES concession_type(id)
);

CREATE TABLE concession_booked(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	total_price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE concession_concessionbooked(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	concession_id UUID NOT NULL,
	concession_booked_id UUID NOT NULL,
	quantity INT NOT NULL DEFAULT 0,
	total_price DECIMAL(10, 2) NOT NULL,

	CONSTRAINT con_ref FOREIGN KEY (concession_id) REFERENCES concession(id),
	CONSTRAINT con_type_ref FOREIGN KEY (concession_booked_id) REFERENCES concession_booked(id)
);

CREATE TABLE users(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	username VARCHAR(255),
	password VARCHAR(255),
	email VARCHAR(255) UNIQUE, 
	first_name VARCHAR(255) NOT NULL,
	last_name VARCHAR(255) NOT NULL,
	phone_number VARCHAR(255) NOT NULL,
	created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT now()::TIMESTAMP WITHOUT TIME ZONE,
	avt_url VARCHAR(255)
);

CREATE TABLE membership(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	user_id UUID UNIQUE NOT NULL,
	point INT NOT NULL DEFAULT 0,

	CONSTRAINT usr_ref FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE transactions(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	user_id UUID NOT NULL,
	create_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT now()::TIMESTAMP WITHOUT TIME ZONE,
	bank_name VARCHAR(255) NOT NULL,
	account_number VARCHAR(255) NOT NULL,
	total_price DECIMAL(10, 2) NOT NULL,
	
	CONSTRAINT usr_ref FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE booking(
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	showtime_id UUID NOT NULL,
	transaction_id UUID UNIQUE NOT NULL,
	concession_booked_id UUID UNIQUE NOT NULL,
	ticket_booked_id UUID UNIQUE NOT NULL,
	total_price DECIMAL(10, 2),
	create_at TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT now()::TIMESTAMP WITHOUT TIME ZONE,

	CONSTRAINT st_ref FOREIGN KEY (showtime_id) REFERENCES showtime(id),
	CONSTRAINT tran_ref FOREIGN KEY (transaction_id) REFERENCES transactions(id),
	CONSTRAINT conbk_ref FOREIGN KEY (concession_booked_id) REFERENCES concession_booked(id),
	CONSTRAINT tckbk_ref FOREIGN KEY (ticket_booked_id) REFERENCES ticket_booked(id)
);

CREATE TABLE seat_booked(
	booking_id UUID NOT NULL, 
	seat_id UUID NOT NULL,

	-- CONSTRAINT db_pk PRIMARY KEY (booking_id, seat_id),
	CONSTRAINT bk_ref FOREIGN KEY (booking_id) REFERENCES booking(id),
	CONSTRAINT st_ref FOREIGN KEY (seat_id) REFERENCES seat(id)
);

-- SELECT now()::TIMESTAMP WITHOUT TIME ZONE;

-- SELECT gen_random_uuid();
-- SELECT * FROM pg_tables;
-- DELETE FROM pg_tables WHERE schemaname = 'public';














