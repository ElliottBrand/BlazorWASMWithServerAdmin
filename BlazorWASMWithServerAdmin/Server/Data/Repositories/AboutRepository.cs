using BlazorWASMWithServerAdmin.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMWithServerAdmin.Server.Data.Repositories
{
    public class AboutRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerFactory _loggerFactory;

        public AboutRepository(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public async Task<AboutModel> GetAboutAsync()
        {
            return await _context.About.FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAboutAsync(AboutModel editedAbout)
        {
            var about = await _context.About.FirstOrDefaultAsync();
            if (about != null)
            {
                try
                {
                    about.Title = editedAbout.Title;
                    about.Details = editedAbout.Details;

                    await _context.SaveChangesAsync();
                    return true;
                }
                catch(Exception ex)
                {
                    _loggerFactory.CreateLogger("AboutRepository_UpdateAboutAsync").LogError(ex.Message);
                }
            }
            return false;
        }
    }
}
