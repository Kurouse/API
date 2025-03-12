namespace WebApplication6
{
    public class SupaBaseContent
    {
        public SupaBaseContent()
        {
        }

       public async Task<List<User>> GetUsers(SupaBase.Client _supabaseClient ) 
        {
            var result = await _supabaseClient.From<User>().Get();
            return result.Models;
        }
    }
}
