using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab4.Repositories
{
    public interface ICompRepository
    {
        Task<bool> AddComposition(Composition composition);

        Task<List<Composition>> ShowList();

        Task<List<Composition>> SearchComposition(string str);

        Task<bool> RemoveComposition(Composition composition);

    }
}