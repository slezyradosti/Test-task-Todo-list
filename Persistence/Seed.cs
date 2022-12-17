using Domain;
using Domain.EntityModels;
using Type = Domain.EntityModels.Type;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {            
            if (context.Types.Count() < 2)
			{
				var types = new List<Type>
				{
					new Type
					{
						TypeName = "Default",
					},
					new Type
					{
						TypeName = "Archived",
					},
				};

				await context.Types.AddRangeAsync(types);
				await context.SaveChangesAsync();
			}

			Guid defaultID = context.Types.First(t => t.TypeName == "Default").Id;
			Guid archivedID = context.Types.First(t => t.TypeName == "Archived").Id;

			if (context.Notes.Any()) return;

			var notes = new List<Notes>
			{
				new Notes
				{
					Note = "Praise da Lord",
					isChecked = true,
					Date = DateTime.Now.AddMonths(1),
					TypeId = defaultID,
				},
				new Notes
				{
					Note = "Break da law",
					isChecked = false,
					Date = DateTime.Now.AddDays(1),
					TypeId = defaultID,
				},
				new Notes
				{
					Note = "Take whats mine",
					isChecked = false,
					Date = DateTime.Now.AddDays(3),
					TypeId = defaultID,
				},
				new Notes
				{
					Note = "Take some more",
					isChecked = false,
					Date = DateTime.Now.AddDays(3),
					TypeId = defaultID,
				},
				new Notes
				{
					Note = "Note 5",
					isChecked = true,
					Date = DateTime.Now.AddDays(2),
					TypeId = defaultID,
				},
				new Notes
				{
					Note = "Note 6",
					isChecked = true,
					Date = DateTime.Now.AddDays(80),
					TypeId = archivedID,
				},
				new Notes
				{
					Note = "Note 7",
					isChecked = true,
					Date = DateTime.Now.AddDays(1),
					TypeId = archivedID,
				},
				new Notes
				{
					Note = "Note 8",
					isChecked = false,
					Date = DateTime.Now.AddDays(33),
					TypeId = archivedID,
				},
				new Notes
				{
					Note = "Note 9",
					isChecked = false,
					Date = DateTime.Now.AddDays(13),
					TypeId = archivedID,
				},
                new Notes
                {
                    Note = "Note 10",
                    isChecked = false,
                    Date = DateTime.Now.AddDays(8),
                    TypeId = defaultID,
                },
                new Notes
                {
                    Note = "Note 11",
                    isChecked = false,
                    Date = DateTime.Now.AddDays(66),
                    TypeId = defaultID,
                },
                new Notes
                {
                    Note = "Note 12",
                    isChecked = false,
                    Date = DateTime.Now.AddDays(6),
                    TypeId = defaultID,
                },
                new Notes
                {
                    Note = "Note 13",
                    isChecked = false,
                    Date = DateTime.Now.AddDays(33),
                    TypeId = archivedID,
                },
            };

			await context.Notes.AddRangeAsync(notes);
			await context.SaveChangesAsync();
		}
    }
}