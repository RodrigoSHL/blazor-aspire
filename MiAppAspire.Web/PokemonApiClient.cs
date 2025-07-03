using MiAppAspire.Web.Models;

namespace MiAppAspire.Web;

public class PokemonApiClient(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<(PokemonDetail[] Pokemon, int TotalCount)> GetPokemonPageAsync(int offset, int limit, CancellationToken cancellationToken = default)
    {
        var list = await _httpClient.GetFromJsonAsync<PokemonListResponse>($"pokemon?offset={offset}&limit={limit}", cancellationToken)
            ?? new PokemonListResponse(0, null, null, Array.Empty<PokemonListItem>());

        var tasks = list.Results.Select(item => _httpClient.GetFromJsonAsync<PokemonDetail>(item.Url, cancellationToken));
        var details = await Task.WhenAll(tasks);
        return (details.Where(d => d != null).ToArray()!, list.Count);
    }
}
