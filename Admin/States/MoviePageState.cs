using Admin.Models;
using Admin.Constants;
using System.Net.Http.Json;

namespace Admin.States;

public class MoviePageState
{
    private readonly HttpClient _http;

    public Movie[]? AllMovies {get; set;}

    public Movie[]? ShowingMovies {get; set;}

    public Movie[]? UpcomingMovies {get; set;}

    public MoviePageState(HttpClient http)
    {
        this._http = http;
    }

    public async Task LoadDataAsync()
    {
        try
        {
            if (this.AllMovies is null)
            {
                this.AllMovies = await this._http.GetFromJsonAsync<Movie[]?>(
                    $"{APIConstants.BaseUrl}{APIConstants.MovieAPIRoot}"
                );
            }

            if (this.ShowingMovies is null)
            {
                this.ShowingMovies = await this._http.GetFromJsonAsync<Movie[]?>(
                    $"{APIConstants.BaseUrl}{APIConstants.MovieShowingAPIRoot}"
                );
            }

            if (this.UpcomingMovies is null)
            {
                this.UpcomingMovies = await this._http.GetFromJsonAsync<Movie[]?>(
                    $"{APIConstants.BaseUrl}{APIConstants.MovieUpcomingAPIRoot}"
                );
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    public void Clear() 
    {
        this.AllMovies = null;
        this.ShowingMovies = null;
        this.UpcomingMovies = null;
    }
}