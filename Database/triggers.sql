--- Kiểm tra ngày thêm phim 
CREATE OR REPLACE FUNCTION check_movie_dates()
RETURNS TRIGGER AS $$
BEGIN 
	IF NEW.released_date <= NOW() THEN 
		RAISE EXCEPTION 'Error: released_date must be in the future';
	END IF;

	IF NEW.end_date <= NEW.released_date THEN
		RAISE EXCEPTION 'Error: end_date must be after released_date';
	END IF;

	RETURN NEW;
END;
$$ LANGUAGE plpgsql;
---
CREATE TRIGGER check_dates_trigger
BEFORE INSERT ON movie
FOR EACH ROW
EXECUTE FUNCTION check_movie_dates();

-- Tạo hàm kiểm tra số lượng phòng và tạo trigger gọi hàm trên trước khi INSERT vào room
CREATE OR REPLACE FUNCTION check_room_limit()
RETURNS TRIGGER AS $$
DECLARE
    max_rooms INT;
    current_rooms INT;
BEGIN
    -- Lấy số lượng phòng tối đa của rạp
    SELECT num_rooms INTO max_rooms FROM cinema WHERE id = NEW.cinema_id;
    
    -- Đếm số phòng hiện tại của rạp
    SELECT COUNT(*) INTO current_rooms FROM room WHERE cinema_id = NEW.cinema_id;
    
    -- Kiểm tra nếu thêm phòng mới vượt quá giới hạn
    IF current_rooms >= max_rooms THEN
        RAISE EXCEPTION 'Số lượng phòng của rạp đã đạt giới hạn';
    END IF;
    
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;
--
CREATE TRIGGER trigger_check_room_limit
BEFORE INSERT ON room
FOR EACH ROW
EXECUTE FUNCTION check_room_limit();

-- Kiểm tra lịch chiếu thêm vào có bị overlap hay trong quá khứ không
CREATE OR REPLACE FUNCTION check_showtime_conflict()
RETURNS TRIGGER AS $$
DECLARE
    movie_duration INTERVAL;
    new_start TIMESTAMP;
    new_end TIMESTAMP;
    existing_start TIMESTAMP;
    existing_end TIMESTAMP;
BEGIN
    -- Lấy thời lượng phim
    SELECT INTERVAL '1 minute' * duration INTO movie_duration
    FROM movie
    WHERE id = NEW.movie_id;

    -- Tính thời gian bắt đầu và kết thúc của suất chiếu mới
    new_start := NEW.date_show + NEW.start_time;
    new_end := new_start + movie_duration;

    -- Kiểm tra nếu thời gian chiếu trong quá khứ
    IF new_start < NOW() THEN
        RAISE EXCEPTION 'Showtime cannot be in the past';
    END IF;

    -- Kiểm tra chồng chéo thời gian với các suất chiếu khác trong cùng phòng
    FOR existing_start, existing_end IN
        SELECT (s.date_show + s.start_time) AS start_time,
               (s.date_show + s.start_time + INTERVAL '1 minute' * m.duration) AS end_time
        FROM showtime s
        JOIN movie m ON s.movie_id = m.id
        WHERE s.room_id = NEW.room_id
    LOOP
        IF (new_start < existing_end AND new_end > existing_start) THEN
            RAISE EXCEPTION 'Showtime overlaps with another show in the same room';
        END IF;
    END LOOP;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;
---
CREATE TRIGGER trigger_check_showtime
BEFORE INSERT ON showtime
FOR EACH ROW
EXECUTE FUNCTION check_showtime_conflict();

CREATE INDEX cnt_namevn_idx ON country(name_vn); 
DROP INDEX cnt_namevn_idx;


