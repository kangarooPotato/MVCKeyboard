using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcKeyboard.Data;
using System;
using System.Linq;

namespace MvcKeyboard.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcKeyboardContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcKeyboardContext>>()))
            {
                // Look for any Keyboards.
                if (context.Keyboard.Any())
                {
                    return;   // DB has been seeded
                }

                context.Keyboard.AddRange(
                    new Keyboard
                    {
                        Name = "mongi-91",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Color = "key color",
                        Switch = "switch name",
                        Type = "key type",
                        Price = 7.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-92",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Color = "key color",
                        Switch = "switch name",
                        Type = "key type",
                        Price = 7.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-93",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Color = "key color",
                        Switch = "switch name",
                        Type = "key type",
                        Price = 7.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-94",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Color = "key color",
                        Switch = "switch name",
                        Type = "key type",
                        Price = 7.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-95",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Color = "key color",
                        Switch = "switch name",
                        Type = "key type",
                        Price = 7.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-96",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Color = "key color",
                        Switch = "switch name",
                        Type = "key type",
                        Price = 7.99M
                    }

                );
                context.SaveChanges();
            }
        }
    }
}