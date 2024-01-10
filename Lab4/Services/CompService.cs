using Lab4.Models;
using Lab4.Repositories;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab4.Services
{
    public class CompService : ICompService
    {
        private readonly ICompRepository _compRepository;

        public CompService(ICompRepository compRepository)
        {
            _compRepository = compRepository;
        }

        public async Task<bool> AddComposition(Composition composition)
        {
            return await _compRepository.AddComposition(composition);
        }

        public async Task<bool> RemoveComposition(Composition comp)
        {
            return await _compRepository.RemoveComposition(comp);
        }

        public async Task<List<Composition>> SearchComposition(string str)
        {
            return await _compRepository.SearchComposition(str);
        }

        public async Task<List<Composition>> ShowList()
        {
            return await _compRepository.ShowList();
        }
    }
}