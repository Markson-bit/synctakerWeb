using System.ComponentModel.DataAnnotations;

namespace synctakerAPI.Core
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AdminRights { get; set; }
    }
}