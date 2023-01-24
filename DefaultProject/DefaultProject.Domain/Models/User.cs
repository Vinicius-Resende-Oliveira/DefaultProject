using DefaultProject.Domain.Enums;

namespace DefaultProject.Domain.Models
{
    public class User : AuditableEntity
    {
        public Account account { get; set; }
        public Profile Profile { get; set; }
        public UserType Type { get; set; }
    }
}
