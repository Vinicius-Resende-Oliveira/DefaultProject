namespace DefaultProject.Domain.Models
{
    public class AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifyAt { get; set; }
    }
}
