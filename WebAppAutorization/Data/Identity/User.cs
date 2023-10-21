using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace WebAppAutorization.Data.Identity
{
    [Table("Users", Schema= "data")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
