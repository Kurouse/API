using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication6;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Supabase.Client _supabaseClient;
        private readonly SupaBaseContext _supaBaseContext;

        public WeatherForecastController(Supabase.Client supabaseClient, SupaBaseContext supaBaseContext)
        {
            _supabaseClient = supabaseClient;
            _supaBaseContext = supaBaseContext;
        }

        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _supabaseClient.From<User>().Get();
                return Ok(JsonConvert.SerializeObject(result.Models, Formatting.Indented));
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("InsertUser", Name = "InsertUser")]
        public async Task<IActionResult> InsertUser([FromBody] User userData)
        {
            try
            {
                if (string.IsNullOrEmpty(userData.login) || string.IsNullOrEmpty(userData.password))
                {
                    return BadRequest("Или логин или пароль пустой.");
                }

                User newUser = new User
                {
                    login = userData.login,
                    password = userData.password,
                };

                bool result = await _supaBaseContext.InsertUsers(_supabaseClient, newUser);

                if (result)
                {
                    return Ok("Регистрация прошла успешно.");
                }
                else
                {
                    return BadRequest("Не удалось добавить пользователя в БД.");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Неизвестная ошибка.");
            }
        }
    }
}