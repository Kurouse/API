using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SupaBase.Client _supabaseClient;
        private readonly SupaBaseContent _supabaseContext;

        private WeatherForecastController(SupaBase.Client supabaseClient, SupaBaseContent supabaseContext)
        {
            _supabaseClient = supabaseClient;
            _supabaseContext = supabaseContext;
        }

        [HttpGet("GetAllUsers", Name = "GetAllUsers")]

        public async Task<string> GetAllUsers()
        {
            try
            {
                var result = await _supabaseClient.GetAllUsers();
                return JsonContent.SerializeObject(result, Formatting.Intented);
            }
            catch(Exception ex)
            {
                return "";
            }
        }
    }
}
