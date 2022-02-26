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
                        Name = "mongi-01",
                        ReleaseDate = DateTime.Parse("1972-2-12"),
                        Color = "Black",
                        Switch = "Cherry",
                        Type = "Click",
                        Rating = "A",
                        Price = 98.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-12",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Color = "Orange",
                        Switch = "Kaihua",
                        Type = "Click",
                        Rating = "A",
                        Price = 21.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-23",
                        ReleaseDate = DateTime.Parse("2001-6-03"),
                        Color = "white",
                        Switch = "Kaihua",
                        Type = "Linear",
                        Rating = "B",
                        Price = 33.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-46",
                        ReleaseDate = DateTime.Parse("2006-2-12"),
                        Color = "Blue",
                        Switch = "Kaihua",
                        Type = "Tactile",
                        Rating = "S",
                        Price = 29.99M
                    },

                    new Keyboard
                    {
                        Name = "mongi-77",
                        ReleaseDate = DateTime.Parse("2011-2-12"),
                        Color = "Red",
                        Switch = "Panda",
                        Type = "Tactile",
                        Rating = "D",
                        Price = 7.99M
                    },

                    new Keyboard
                    {
                        Name = "JJ.98K",
                        ReleaseDate = DateTime.Parse("2021-2-12"),
                        Color = "RED",
                        Switch = "Damos",
                        Type = "Soft Click",
                        Rating = "C",
                        Price = 47.99M
                    }

                );
                context.SaveChanges();
            }
        }
    }
}