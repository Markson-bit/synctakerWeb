namespace synctakerAPI.Core
{
    public interface IUserService
    {
        User? GetUser(string email);
    }
}