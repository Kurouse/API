using Supabase;
using Supabase.Postgrest;

namespace WebApplication6
{
    public class SupaBaseContext
    {
        public SupaBaseContext()
        {

        }

        public async Task<List<User>> GetUsers(Supabase.Client _supabaseClient)
        {
            try
            {
                var result = await _supabaseClient.From<User>().Get();
                return result.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении пользователей: {ex.Message}");
                return new List<User>();
            }
        }

        internal async Task<bool> InsertUsers(Supabase.Client _supabaseClient, User newUser)
        {
            try
            {
                var response = await _supabaseClient.From<User>().Insert(newUser);

                if (response.ResponseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Ошибка при вставке пользователя: {response.ResponseMessage.ReasonPhrase}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при вставке пользователя: {ex.Message}");
                return false;
            }
        }
    }
}