using AutoMapper;
using Domain.EntityModels;

namespace Application.Core
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Notes, Notes>();
		}
	}
}
