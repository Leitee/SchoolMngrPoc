using System;
using System.Linq;
using System.Threading.Tasks;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;

namespace Pandora.NetStandard.BusinessData.Data
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
                _context.Grades.Add(new Grade { Name = "1ro" });
                _context.Grades.Add(new Grade { Name = "2do" });
                _context.Grades.Add(new Grade { Name = "3ro" });
            }

            if (!_context.Classes.Any())
            {
                _context.Classes.Add(new Class { Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 1 });
                _context.Classes.Add(new Class { Name = "2da", Shift = ShiftTimeEnum.AFTERNOON, GradeId = 1 });
                _context.Classes.Add(new Class { Name = "3ra", Shift = ShiftTimeEnum.NIGHT, GradeId = 1 });
                _context.Classes.Add(new Class { Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 2 });
                _context.Classes.Add(new Class { Name = "2da", Shift = ShiftTimeEnum.AFTERNOON, GradeId = 2 });
                _context.Classes.Add(new Class { Name = "1ra", Shift = ShiftTimeEnum.NIGHT, GradeId = 3 });
            }

            await _context.SaveChangesAsync();
        }
    }
}
