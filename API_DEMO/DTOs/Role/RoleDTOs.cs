using API_DEMO.DTOs.Order;
using API_DEMO.DTOs.User;

namespace API_DEMO.DTOs.Role
{
    public class RoleDTOs
    {
        public int RoleId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? Created { get; set; }

        public string? Description { get; set; }
        public List<UserDTOs> Users { get; set; }
    }
}
