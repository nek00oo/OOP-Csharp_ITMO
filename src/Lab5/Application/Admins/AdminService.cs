using Abstractions.Repositories;
using Application.Users;
using Contracts.Admins;
using Models.Accounts;

namespace Application.Admins;

internal class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly CurrentUserManager _currentAdminManager;

    public AdminService(IAdminRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentAdminManager = currentUserManager;
    }

    public AccessCheckResult Login(string password)
    {
        Task<UserAccount?> admin = _repository.FindAdminByPasswordAsync(password);
        if (admin.Result is null)
            return new AccessCheckResult.IncorrectPassword();

        _currentAdminManager.UserAccount = admin.Result;
        return new AccessCheckResult.Success();
    }

    public CreateUserAccountResult CreateUserAccount(long accountNumber, string accountPassword)
    {
        Task<bool?> result = _repository.CreateUserAccount(accountNumber, accountPassword);
        if (result.Result is false)
            return new CreateUserAccountResult.UserAlreadyExists();

        return new CreateUserAccountResult.Success();
    }

    public ChangePasswordResult ChangePassword(string newPassword, long currentId)
    {
        _repository.ChangePassword(newPassword, currentId);
        return new ChangePasswordResult.Success();
    }
}