namespace codesome.Data.Models
{
    public class Base
    {
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
        public string DeletedBy { get; set; } = "";

    }
}
