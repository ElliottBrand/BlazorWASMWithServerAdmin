using BlazorWASMWithServerAdmin.Server.Data;
using BlazorWASMWithServerAdmin.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMWithServerAdmin.Server.Services
{
    public interface IAboutService
    {
        Task<AboutModel> GetAboutAsync();
        Task<bool> UpdateAboutAsync(AboutModel editedAbout);
    }

    public class AboutService : IAboutService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerFactory _loggerFactory;

        public AboutService(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public async Task<AboutModel> GetAboutAsync() =>
            await new Data.Repositories.AboutRepository(_context, _loggerFactory).GetAboutAsync();

        public async Task<bool> UpdateAboutAsync(AboutModel editedAbout) =>
            await new Data.Repositories.AboutRepository(_context, _loggerFactory).UpdateAboutAsync(editedAbout);
    }
}
