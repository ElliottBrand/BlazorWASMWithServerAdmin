﻿using BlazorWASMWithServerAdmin.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMWithServerAdmin.Server.Data
{
    public class SeedAbout
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var about = new AboutModel()
            {
                Title = "About",
                Details = "Tell everyone a bit about yourself here."
            };

            context.About.Add(about);
            context.SaveChanges();
        }
    }
}
