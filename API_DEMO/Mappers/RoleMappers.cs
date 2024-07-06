using API_DEMO.DTOs.Role;
using API_DEMO.Models;

namespace API_DEMO.Mappers
{
    public static class RoleMappers
    {
        public static RoleDTOs ToRoleFromDTOs(this Role roleModel)
        {
            return new RoleDTOs
            {
                RoleId = roleModel.RoleId,
                Name = roleModel.Name,
                Created = roleModel.Created,
                Description = roleModel.Description,
                Users = roleModel.Users.Select(c=>c.ToUserDTOs()).ToList()
            };
        }

        public static Role ToRoleCreateFromDTOs(this CreateRoleDTOs rolesDTOs) 
        {
            return new Role
            { 
                Name = rolesDTOs.Name,
                Description = rolesDTOs.Description,
            };
        }

        public static Role ToRoleUpdateFromDTOs(this UpdateRoleDTOs rolesDTOs) 
        {
            return new Role 
            {
                Name = rolesDTOs.Name,
                Description = rolesDTOs.Description
            };
        }
    }
}
