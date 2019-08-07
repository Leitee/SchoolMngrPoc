using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;

namespace Pandora.NetCore.UnitTest
{
    public class TestDbContext : ApplicationDbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(nameof(TestDbContext));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Add custome data entity for test purpose
            builder.Entity<Grade>().HasData(
                new Grade { Id = 1, Name = "1er" },
                new Grade { Id = 2, Name = "2do" },
                new Grade { Id = 3, Name = "3ro" },
                new Grade { Id = 4, Name = "4to" },
                new Grade { Id = 5, Name = "5to" }
                );

            builder.Entity<Class>().HasData(
                new Class { Id = 1, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 1 },
                new Class { Id = 2, Name = "2da", Shift = ShiftTimeEnum.AFTERNOON, GradeId = 1 },
                new Class { Id = 3, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 2 },
                new Class { Id = 4, Name = "2da", Shift = ShiftTimeEnum.NIGHT, GradeId = 2 },
                new Class { Id = 5, Name = "1ra", Shift = ShiftTimeEnum.AFTERNOON, GradeId = 3 },
                new Class { Id = 6, Name = "2da", Shift = ShiftTimeEnum.NIGHT, GradeId = 3 },
                new Class { Id = 7, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 4 },
                new Class { Id = 8, Name = "1ra", Shift = ShiftTimeEnum.TOMORROW, GradeId = 5 }
                );

            builder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Matemáticas" },
                new Subject { Id = 2, Name = "Fisica" },
                new Subject { Id = 3, Name = "Redes" },
                new Subject { Id = 4, Name = "Algoritmos" },
                new Subject { Id = 5, Name = "Programación", SubjectId = 4 }
                );

            builder.Entity<Teacher>().HasData(
                new Teacher { Id = 32165498, ApplicationUserId = 11 }
                );

            builder.Entity<Student>().HasData(
                new Student { Id = 11111111, ApplicationUserId = 101 },
                new Student { Id = 22222222, ApplicationUserId = 102 },
                new Student { Id = 33333333, ApplicationUserId = 103 }
                );
        }
    }
}
