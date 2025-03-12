using System.ComponentModel.DataAnnotations.Schema;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace WebApplication6
{
    [Table("users")]
    class User : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }

    var model = new User
    {
        Name = "John",
        Age = 19,
        Login = "12345",
        Password = "54321"
    };
    await
    supabase.From<User>().Insert(model);
}
