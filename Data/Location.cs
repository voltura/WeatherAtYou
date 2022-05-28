using System.Text.Json.Serialization;

namespace WeatherAtYou.Data
{
    public record Address(
        [property: JsonPropertyName("house_number")] string HouseNumber,
        [property: JsonPropertyName("road")] string Road,
        [property: JsonPropertyName("suburb")] string Suburb,
        [property: JsonPropertyName("city_district")] string CityDistrict,
        [property: JsonPropertyName("city")] string City,
        [property: JsonPropertyName("county")] string County,
        [property: JsonPropertyName("postcode")] string Postcode,
        [property: JsonPropertyName("country")] string Country,
        [property: JsonPropertyName("country_code")] string CountryCode
    );

    public record Feature(
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("properties")] Properties Properties,
        [property: JsonPropertyName("bbox")] IReadOnlyList<double> Bbox//,
  //      [property: JsonPropertyName("geometry")] Geometry Geometry
    );

    public record Properties(
        [property: JsonPropertyName("place_id")] int PlaceId,
        [property: JsonPropertyName("osm_type")] string OsmType,
        [property: JsonPropertyName("osm_id")] int OsmId,
        [property: JsonPropertyName("place_rank")] int PlaceRank,
        [property: JsonPropertyName("category")] string Category,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("importance")] object Importance,
        [property: JsonPropertyName("addresstype")] string Addresstype,
        [property: JsonPropertyName("name")] object Name,
        [property: JsonPropertyName("display_name")] string DisplayName,
        [property: JsonPropertyName("address")] Address Address
    );

    public record Location(
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("licence")] string Licence,
        [property: JsonPropertyName("features")] IReadOnlyList<Feature> Features
    );
}