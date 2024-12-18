namespace synctakerAPI.Core
{
    public class UserCreateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AdminRights { get; set; }
    }
}