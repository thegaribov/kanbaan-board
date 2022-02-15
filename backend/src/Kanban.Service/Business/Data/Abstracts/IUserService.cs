using Kanban.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Abstracts
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetUserAsync(ClaimsPrincipal User);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> CreateAsync(User user, string passsword);
        Task<IdentityResult> DeleteAsync(User user);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByIdAsync(string userId);
        Task<User> FindByEmailAsync(string email);
        Task<bool> IsInRoleAsync(User user, string role);
        Task<bool> IsAdmin(User user);
        Task<bool> IsAdmin(string userId);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles);
        //Task<List<string>> GetUserRolesId(User user);
        Task<IList<string>> GetRolesAsync(User user);
        Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<bool> IsEmailConfirmedAsync(User user);
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
    }
}
