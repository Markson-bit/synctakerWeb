namespace synctakerAPI.Core
{
    public interface IUserService
    {
        Task<int?> CreateUserAsync(UserCreateRequest request);

        User? GetUser(string email);

        Task<bool> DeleteUserAsync(int userId);

        List<User> GetUsers();
    }
}