namespace codesome.Data.Models
{
    public class Base
    {
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int CreatedBy { get; set; } = 0;
        public int UpdatedBy { get; set; } = 0;
        public int DeletedBy { get; set; } = 0;

    }
}
