using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcKeyboard.Models;

namespace MvcKeyboard.Data
{
    public class MvcKeyboardContext : DbContext
    {
        public MvcKeyboardContext (DbContextOptions<MvcKeyboardContext> options)
            : base(options)
        {
        }

        public DbSet<MvcKeyboard.Models.Keyboard> Keyboard { get; set; }
    }
}
