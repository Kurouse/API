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

        [HttpPost("InsertUser", Name = "InsertUser")]
        public async Task<ActionResult> InsertUser([FromBody] UserData userData)
        {
            try
            {
                if (string.IsNullOrEmpty(userData.Login) || string.IsNullOrEmpty(userData.Password))
                {
                    return BadRequest("��� ����� ��� ������ ������");
                }
                else
                {
                    User newUser = new User
                    {
                        Login = userData.Login,
                        Password = userData.Password,
                    };
                    bool result = await _supabaseContext.InsertUsers(_supabaseClient, newUser);
                    if (result == true)
                    {
                        return Ok("����������� ������ ��������");
                    }
                    else
                    {
                        return BadRequest("�� ������� �������� ������������ � ��")
                    }
                }
            }

            catch (Exception ex)
            {
                return BadRequest("����������� ������");
            }
        }
    }
}
