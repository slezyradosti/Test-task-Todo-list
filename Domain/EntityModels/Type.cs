using Domain.BaseRepository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModels
{
	public class Type : BaseRepo
	{
		[Required]
		[StringLength(60)]
		public string TypeName { get; set; }
		public List<Notes> NotesList { get; set; } = new List<Notes>();
	}
}
