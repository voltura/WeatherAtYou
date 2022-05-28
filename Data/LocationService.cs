using Microsoft.Extensions.Caching.Memory;

namespace WeatherAtYou.Data
{
    public class LocationService
    {
        private readonly HttpClient _client;
        private static readonly SemaphoreSlim _lock = new(1, 1);
        private static readonly MemoryCacheEntryOptions _cacheOptions2Min = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(2));
        private readonly IMemoryCache _memoryCache;

        public LocationService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _client = new();
        }

        public async Task<Location?> GetLocationAsync(double longitude, double latitude)
        {
            try
            {
                await _lock.WaitAsync();
                var memkey = $"LocationLong{longitude}Lat{latitude}";
                if (_memoryCache.TryGetValue(memkey, out Location? location)) return location;
                string url = $"https://nominatim.openstreetmap.org/reverse?format=geojson&lat={latitude}&lon={longitude}";
                url = url.Replace(',', '.');
                _client.DefaultRequestHeaders.Add("User-Agent", "Other");
                location = await _client.GetFromJsonAsync<Location>(url);
                _memoryCache.Set(memkey, location, _cacheOptions2Min);
                return location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}