using TravelWithMe.InviteCode.Dtos;

namespace TravelWithMe.InviteCode.Services
{
    public interface IInviteCodeServices
    {
        Task<List<ResultInviteCodeDto>> GetAllCodesAsync();
        Task CreateInviteCodeAsync(CreateInviteCodeDto createInviteCodeDto);
        Task UpdateInviteCodeAsync(UpdateInviteCodeDto updateInviteCodeDto);
        Task DeleteInviteCodeAsync(int inviteCodeId);
        Task<GetByCodeInviteCodeDto> GetByCodeInviteCodeAsync(string code);
    }
}
