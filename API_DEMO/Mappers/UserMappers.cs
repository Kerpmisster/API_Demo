using API_DEMO.DTOs.User;
using API_DEMO.Models;

namespace API_DEMO.Mappers
{
    public static class UserMappers
    {
        public static UserDTOs ToUserDTOs(this User userModel)
        {
            return new UserDTOs
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password,
                Created = userModel.Created,
                Status = userModel.Status,
                RoleId = userModel.RoleId,
                AvatarImg = userModel.AvatarImg,
                Orders = userModel.Orders.Select(o=>o.ToOrderFromDTOs()).ToList()
            };
        }

        public static User ToUserCreateFromDTOs(this CreateUserDTOs createUserDTOs, int rolesId)
        {
            return new User
            {
                Name = createUserDTOs.Name,
                Email = createUserDTOs.Email,
                Password = createUserDTOs.Password,
                RoleId = rolesId
            };
        }

        public static User ToUserUpdateFromDTOs(this UpdateUserDTOs updateUserDTOs) 
        {
            return new User
            {
                Name = updateUserDTOs.Name,
                Email = updateUserDTOs.Email,
                Password = updateUserDTOs.Password
            };
        }
    }
}
