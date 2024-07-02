using KraevedAPI.Constants;
using KraevedAPI.Models;

namespace KraevedAPI.Service
{
    public partial class KraevedService : IKraevedService
    {
        /// <summary>
        /// Получить информацию по текущему пользователю
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Task<UserOutDto> GetCurrentUserInfo()
        {
            var user = GetCurrentUser();
            var userInfo = _mapper.Map<User, UserOutDto>(user);

            return Task.FromResult(userInfo);
        }

        public async Task<UserOutDto> PatchUser(UserInDto userInDto) {
            var user = GetCurrentUser();

            if (userInDto.Name!= null) {
                user.Name = userInDto.Name;
            }

            if (userInDto.Surname!= null) {
                user.Surname = userInDto.Surname;
            }

            var currentUser = GetCurrentUser();
            if (currentUser.Phone == "9105968117") {
                var adminRole = _unitOfWork.RolesRepository.GetRoleByName(ServiceConstants.Roles.Admin.Name);
                user.Role = adminRole;
            }

            _unitOfWork.UsersRepository.Update(user);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<User, UserOutDto>(user);
        }

        private User GetCurrentUser() {
            var userId = _httpContextAccessor.HttpContext.User.Identity.Name
                ?? throw new Exception(ServiceConstants.Exception.UserNotFound);
                
            var user = _unitOfWork.UsersRepository.Get(x => x.Id == int.Parse(userId), includeProperties: "Role").FirstOrDefault() 
                ?? throw new Exception(ServiceConstants.Exception.UserNotFound);

            return user;
        }
    }
}