using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services;

public class MovieServices
{
    private readonly AppDbContext context;

    public MovieServices(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Movie>> GetAll()
    {        
        return await this.context.Movies
                        .Include(m => m.Country)
                        .Include(m => m.Format)
                        .Include(m => m.Language)
                        .Include(m => m.LimitAge)
                        .Include(m => m.Genres)
                        .ToListAsync();
    }

    public async Task<List<Movie>> GetShowing()
    {
        return await this.context.Movies
                    .Include(m => m.Country)
                    .Include(m => m.Format)
                    .Include(m => m.Language)
                    .Include(m => m.LimitAge)
                    .Include(m => m.Genres)
                    .Where(m => m.Status == 1)
                    .ToListAsync();
    }

    public async Task<List<Movie>> GetUpcoming()
    {
        return await this.context.Movies
                    .Include(m => m.Country)
                    .Include(m => m.Format)
                    .Include(m => m.Language)
                    .Include(m => m.LimitAge)
                    .Include(m => m.Genres)
                    .Where(m => m.Status == 0)
                    .ToListAsync();
    }

    public async Task<Movie?> GetWithID(Guid id)
    {
        return await this.context.Movies
                    .Include(m => m.Country)
                    .Include(m => m.Format)
                    .Include(m => m.Language)
                    .Include(m => m.LimitAge)
                    .Include(m => m.Genres)
                    .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie?> GetMovieDetail(Guid id)
    {
        return await this.context.Movies
                    .Include(m => m.Country)
                    .Include(m => m.Format)
                    .Include(m => m.Language)
                    .Include(m => m.LimitAge)
                    .Include(m => m.Showtimes)
                    .Include(m => m.Genres)
                    .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie?> AddMovie(Movie newMovie)
    {
        var existedMovie = await this.context.Movies.FirstOrDefaultAsync(
            m => m.NameVn == newMovie.NameVn ||
                 m.NameEn == newMovie.NameEn
        );
        if (existedMovie is not null)
            return null;

        newMovie.Id = Guid.NewGuid();

        if (newMovie.Country is null || 
            newMovie.Format is null ||
            newMovie.Language is null || 
            newMovie.LimitAge is null)
            return null;

        newMovie.CountryId = newMovie.Country.Id;
        newMovie.FormatId = newMovie.Format.Id;
        newMovie.LanguageId = newMovie.Language.Id;
        newMovie.LimitAgeId = newMovie.LimitAge.Id;

        newMovie.Country = null;
        newMovie.Format = null;
        newMovie.Language = null;
        newMovie.LimitAge = null;

        if (newMovie.Genres != null && newMovie.Genres.Any())
        {
            var genreIds = newMovie.Genres.Select(g => g.Id).ToList();
            
            var existingGenres = await this.context.Genres
                .Where(g => genreIds.Contains(g.Id))
                .ToListAsync();

            newMovie.Genres = existingGenres;
        }

        try 
        {
            this.context.Movies.Add(newMovie);
            await this.context.SaveChangesAsync();
            return newMovie;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return newMovie;
        }
    }

    public async Task<bool> DeleteMovie(Guid id)
    {
        var movie = await this.context.Movies
            .Include(m => m.Genres) // Nạp Genres vào để xử lý xóa
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie is null)
            return false;

        if (movie.Genres is null) 
            return false;

        try
        {
            // Xóa liên kết trong bảng trung gian
            movie.Genres.Clear();
            await this.context.SaveChangesAsync();

            // Xóa movie
            this.context.Movies.Remove(movie);
            await this.context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}