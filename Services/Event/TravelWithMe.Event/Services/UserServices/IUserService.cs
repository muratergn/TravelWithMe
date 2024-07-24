using TravelWithMe.Event.Dtos.UserDtos;

namespace TravelWithMe.Event.Services.UserServices
{
    public interface IUserService
    {
        Task<List<ResultUserDto>> GetAllUsersAsync();
        Task<ResultUserDto> GetUserByIdAsync(string id);
        Task<List<ResultUserDto>> GetUsersByEventIdAsync(string eventId);
        Task CreateUserAsync(CreateUserDto createUserDto);
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
        Task DeleteUserAsync(string id);
    }
}
