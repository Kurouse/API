using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6
{
    public class User : BaseModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("age")]

        public int Age { get; set; }
    }
}
