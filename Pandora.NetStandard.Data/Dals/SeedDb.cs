using System;
using System.Linq;
using System.Threading.Tasks;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;

namespace Pandora.NetStandard.Data.Dals
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly Random _random;

        public SeedDb(ApplicationDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Grades.Any())
            {
                _context.Grades.Add(new Grade { Id = 1, Name = "1ro" });
                _context.Grades.Add(new Grade { Id = 2, Name = "2do" });
                _context.Grades.Add(new Grade { Id = 3, Name = "3ro" });

                await _context.SaveChangesAsync();
            }

            if (!_context.Classes.Any())
            {
                _context.Classes.Add(new Class { Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, Grade = _context.Grades.FirstOrDefault(g => g.Id == 1) });
                _context.Classes.Add(new Class { Name = "2da", Shift = ShiftTimeEnum.AFTERNOON, Grade = _context.Grades.FirstOrDefault(g => g.Id == 1) });
                _context.Classes.Add(new Class { Name = "3ra", Shift = ShiftTimeEnum.NIGHT, Grade = _context.Grades.FirstOrDefault(g => g.Id == 1) });
                _context.Classes.Add(new Class { Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, Grade = _context.Grades.FirstOrDefault(g => g.Id == 2) });
                _context.Classes.Add(new Class { Name = "2da", Shift = ShiftTimeEnum.AFTERNOON, Grade = _context.Grades.FirstOrDefault(g => g.Id == 2) });
                _context.Classes.Add(new Class { Name = "1ra", Shift = ShiftTimeEnum.NIGHT, Grade = _context.Grades.FirstOrDefault(g => g.Id == 3) });

                await _context.SaveChangesAsync();
            }
        }
    }
}
