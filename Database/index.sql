CREATE INDEX mov_status_idx ON movie(status);
DROP INDEX mov_status_idx;

EXPLAIN ANALYZE SELECT * FROM movie WHERE status = 1;