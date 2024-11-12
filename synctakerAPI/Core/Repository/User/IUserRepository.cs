namespace synctakerAPI.Core
{
    public interface IUserRepository
    {
        User? GetUser(string email);
    }
}