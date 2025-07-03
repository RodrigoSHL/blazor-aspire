using System.Text.Json.Serialization;

namespace MiAppAspire.Web.Models;

public record PokemonListResponse(
    int Count,
    string? Next,
    string? Previous,
    [property: JsonPropertyName("results")] PokemonListItem[] Results);

public record PokemonListItem(string Name, string Url);

public record PokemonDetail(
    string Name,
    PokemonSprites Sprites,
    PokemonTypeEntry[] Types);

public record PokemonSprites(
    [property: JsonPropertyName("front_default")] string? FrontDefault);

public record PokemonTypeEntry(
    int Slot,
    NamedApiResource Type);

public record NamedApiResource(string Name, string Url);
