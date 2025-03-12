using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace WebApplication6
{
    public class SupaBaseContent
    {
        public SupaBaseContent()
        {
        }

       public async Task<List<User>> GetUsers(Supabase.Client _supabaseClient ) 
        {
            var result = await _supabaseClient.From<User>().Get();
            return result.Models;
        }
    }
}
