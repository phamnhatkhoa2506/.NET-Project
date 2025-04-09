using Admin.Models;
using System.Net.Http.Json;

namespace Admin.States;

public class BasePageState<T> where T: class
{ 
    private readonly HttpClient _http;

    public T[]? entities {get; set;}

    public BasePageState(HttpClient http)
    {
        this._http = http;
    }

    public async Task LoadDataAsync(string baseUrl)
    {
        if (entities is not null)
        {
            return;
        }

        this.entities = await this._http.GetFromJsonAsync<T[]?>(baseUrl);
    }

    public void Clear() => this.entities = null;
}