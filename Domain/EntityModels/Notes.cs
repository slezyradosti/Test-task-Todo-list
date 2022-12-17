using Domain.BaseRepository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModels
{
    public class Notes : BaseRepo
    {
        [Required]
        [StringLength(150)]
        public string Note { get; set; }
        [Display(Name = "Is checked")]
        public bool isChecked { get; set; } = false;
        public DateTime Date { get; set; } = DateTime.Now;
		public Guid TypeId { get; set; }

		[ForeignKey(nameof(TypeId))]
		public Type Type { get; set; }
	}
}
