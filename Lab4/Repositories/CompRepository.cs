using Lab4.DB;
using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab4.Repositories
{
    public class CompRepository : ICompRepository
    {
        private readonly Lab4Context _context;

        public CompRepository(Lab4Context context)
        {
            _context = context;
        }

        public async Task<bool> AddComposition(Composition composition)
        {
            try
            {
                if (_context.CompList.Contains(composition))
                {
                    return false;
                }
                _context.CompList.Add(composition);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving changes: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Composition>> ShowList()
        {
            return await _context.CompList.ToListAsync();
        }

        public async Task<List<Composition>> SearchComposition(string str)
        {
            return await _context.CompList
                .Where(comp => comp.Name.Contains(str) || comp.AuthorName.Contains(str) )
                .ToListAsync();
        }

        public async Task<bool> RemoveComposition(Composition composition)
        {
            if (_context.CompList.Contains(composition))
            {
                _context.CompList.Remove(composition);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}