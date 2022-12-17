namespace RentACarPlatform.Core.Contracts
{
    /// <summary>
    /// Agent Service with all methods
    /// </summary>
    public interface IAgentService
    {
        Task<bool> ExistById(string userId);

        Task<bool> UserWithPhoneNumberExist(string phoneNumber);

        Task<bool> UserHasRents(string userId);

        Task Create(string userId, string phoneNumber);

        Task<int> GetAgentId(string userId);
    }
}
