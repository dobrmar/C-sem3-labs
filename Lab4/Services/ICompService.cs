using Lab4.Models;
using System;
using System.Threading.Tasks;

namespace Lab4.Services
{
    public interface ICompService
    {
        Task<bool> AddComposition(Composition composition);

        Task<List<Composition>> ShowList();

        Task<List<Composition>> SearchComposition(string str);

        Task<bool> RemoveComposition(Composition comp);
    }
}