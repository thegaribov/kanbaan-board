using Kanban.Core.Entities;
using Kanban.DataAccess.UnitOfWork.Abstracts;
using Kanban.Service.Business.Data.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Business.Data.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
        public async Task<User> GetUserAsync(ClaimsPrincipal User)
        {
            return await _unitOfWork.Users.GetUserAsync(User);
        }
        public async Task<IdentityResult> UpdateAsync(User user)
        {
            return await _unitOfWork.Users.UpdateAsync(user);
        }
        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            return await _unitOfWork.Users.CreateAsync(user, password);
        }
        public async Task<IdentityResult> DeleteAsync(User user)
        {
            return await _unitOfWork.Users.DeleteAsync(user);
        }
        public async Task<User> FindByUserNameAsync(string username)
        {
            return await _unitOfWork.Users.FindByUserNameAsync(username);

        }
        public async Task<User> FindByIdAsync(string userId)
        {
            return await _unitOfWork.Users.FindByIdAsync(userId);
        }
        public async Task<User> FindByEmailAsync(string email)
        {
            return await _unitOfWork.Users.FindByEmailAsync(email);
        }
        public async Task<bool> IsInRoleAsync(User user, string role)
        {
            return await _unitOfWork.Users.IsInRoleAsync(user, role);
        }
        public async Task<bool> IsAdmin(User user)
        {
            const string STAFF_ROLE = "Staff";
            return await _unitOfWork.Users.IsInRoleAsync(user, STAFF_ROLE);
        }
        public async Task<bool> IsAdmin(string userId)
        {
            const string STAFF_ROLE = "Staff";
            User user = await FindByIdAsync(userId);

            return await _unitOfWork.Users.IsInRoleAsync(user, STAFF_ROLE);
        }
        public async Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return await _unitOfWork.Users.AddToRoleAsync(user, role);
        }
        public async Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<string> roles)
        {
            return await _unitOfWork.Users.AddToRolesAsync(user, roles);
        }
        //public async Task<List<string>> GetUserRolesId(User user)
        //{
        //    var userRoles = await _unitOfWork.Users.GetRolesAsync(user);
        //    return userRoles.Select(r => _unitOfWork.Roles.FindByNameAsync(r).Result.Id).ToList();
        //}
        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return await _unitOfWork.Users.GetRolesAsync(user);
        }
        public async Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles)
        {
            return await _unitOfWork.Users.RemoveFromRolesAsync(user, roles);
        }
        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _unitOfWork.Users.GenerateEmailConfirmationTokenAsync(user);
        }
        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _unitOfWork.Users.ConfirmEmailAsync(user, token);
        }
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await _unitOfWork.Users.CheckPasswordAsync(user, password);
        }

        public async Task<bool> IsEmailConfirmedAsync(User user)
        {
            return await _unitOfWork.Users.IsEmailConfirmedAsync(user);
        }
        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _unitOfWork.Users.GeneratePasswordResetTokenAsync(user);
        }
        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            return await _unitOfWork.Users.ResetPasswordAsync(user, token, password);
        }
        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _unitOfWork.Users.ChangePasswordAsync(user, currentPassword, newPassword);
        }
        public async Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await _unitOfWork.Users.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        }

        public async Task SignOutAsync()
        {
            await _unitOfWork.Users.SignOutAsync();
        }

    }
}
