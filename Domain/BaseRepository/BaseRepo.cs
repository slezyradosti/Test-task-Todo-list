using System.ComponentModel.DataAnnotations;

namespace Domain.BaseRepository
{
    public class BaseRepo
    {
        [Key]
        public Guid Id { get; set; }
        [Timestamp]
        public byte[]? Timestamp { get; set; }  
    }
}

