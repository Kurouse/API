using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace WebApplication6
{
    [Table("users")]
    public class User : BaseModel
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("login")]
        public string login { get; set; }
    }

    //var model = new User
    //{
    //    Name = "Shire",
    //    Age = 15,
    //    password = "password",
    //    login = "test"
    //};

    //await Supabase.From<User>().Insert(model);
}
