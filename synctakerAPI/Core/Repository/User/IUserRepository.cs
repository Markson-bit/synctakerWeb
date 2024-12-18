namespace synctakerAPI.Core
{
    public interface IUserRepository
    {
        Task<int?> AddUserAsync(UserCreateRequest request);

        User? GetUser(string email);

        List<User> GetUsers();

        Task<bool> DeleteUserAsync(int userId);
    }
}