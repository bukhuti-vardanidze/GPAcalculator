using GPA_Calculator.DB;
using GPA_Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.Repositories
{
    public interface IStatisticRepository
    {
        Task<List<Subject>> GetTop3Subject();
        Task<List<Subject>> GetLast3Subject();
    }
    public class StatisticRepository : IStatisticRepository
    {
        private readonly DataContext _context;

        public StatisticRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetTop3Subject()
        {
            var subject = _context.Grades.GroupBy(x => x.SubjectId)
                         .Select(x => new
                         {
                             SubjectName = x.Key,
                             AverageScore = x.Average(x => x.Score)
                         })
                         .OrderByDescending(x => x.AverageScore).Take(3);
             var top3 = new List<Subject>();

            foreach (var items in subject)
            {
                top3.Add(await _context.Subjects.FirstOrDefaultAsync(x => x.Id == items.SubjectName));
            }

            return top3.ToList();

        }

        public async Task<List<Subject>> GetLast3Subject()
        {
            var subject = _context.Grades.GroupBy(x => x.SubjectId)
                         .Select(x => new
                         {
                             SubjectName = x.Key,
                             AverageScore = x.Average(x => x.Score)
                         })
                         .OrderBy(x => x.AverageScore).Take(3);
            var top3 = new List<Subject>();

            foreach (var items in subject)
            {
                top3.Add(await _context.Subjects.FirstOrDefaultAsync(x => x.Id == items.SubjectName));
            }

            return top3.ToList();

        }
    }


}
