namespace MovieAPI.Migrations
{
    using Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieAPI.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieAPI.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var movies = new Movie[] {
                new Movie {
                    Title = "The Lord of the Rings"
                },
                new Movie {
                    Title = "The Dark Knight"
                },
                new Movie {
                    Title = "Pulp Fiction"
                },
                new Movie {
                    Title = "Memento"
                }
            };

            var genres = new Genre[] {
                new Genre {
                    Name = "Action"
                },
                new Genre {
                    Name = "Adventure"
                },
                new Genre {
                    Name = "Thriller"
                },
                new Genre {
                    Name = "Drama"
                }
            };

            var people = new Person[] {
                new Person {
                    Name = "Quentin Tarantino",
                    Age = 52
                },
                new Person {
                    Name = "Lawrence Bender",
                    Age = 58
                },
                new Person {
                    Name = "Christopher Nolan",
                    Age = 45
                },
                new Person {
                    Name = "Suzanne Todd",
                    Age = 49
                },
                new Person {
                    Name = "Jennifer Todd",
                    Age = 46
                },
                new Person {
                    Name = "Peter Jackson",
                    Age = 54
                },
                new Person {
                    Name = "Barrie Osborne",
                    Age = 71
                },
                new Person {
                    Name = "Fran Walsh",
                    Age = 56
                },
                new Person {
                    Name = "Emma Thomas",
                    Age = 54
                },
                new Person {
                    Name = "Charles Roven",
                    Age = 66
                }
            };

            context.Movies.AddOrUpdate(
                m => m.Title,
                movies
            );

            context.Genre.AddOrUpdate(
                g => g.Name,
                genres
            );

            context.People.AddOrUpdate(
                p => p.Name,
                people
            );

            context.SaveChanges();

            // Link them
            movies[0].Directors = (from p in new List<string> { "Peter Jackson" }
                                   select people.FirstOrDefault(person => person.Name == p)).ToList();
            movies[0].Producers = (from p in new List<string> { "Peter Jackson", "Barrie Osborne", "Fran Walsh" }
                                   select people.FirstOrDefault(person => person.Name == p)).ToList();
            
            movies[1].Directors = (from p in new List<string> { "Christopher Nolan" }
                                   select people.FirstOrDefault(person => person.Name == p)).ToList();
            movies[1].Producers = (from p in new List<string> { "Emma Thomas", "Charles Roven" }
                                   select people.FirstOrDefault(person => person.Name == p)).ToList();

            movies[2].Directors = (from p in new List<string> { "Quentin Tarantino" }
                                   select people.FirstOrDefault(person => person.Name == p)).ToList();
            movies[2].Producers = (from p in new List<string> { "Lawrence Bender" }
                                   select people.FirstOrDefault(person => person.Name == p)).ToList();

            movies[3].Directors = (from p in new List<string> { "Christopher Nolan" }
                                   select people.FirstOrDefault(person => person.Name == p)).ToList();
            movies[3].Producers = (from p in new List<string> { "Suzanne Todd", "Jennifer Todd" }
                                   select people.FirstOrDefault(person => person.Name == p)).ToList();

            context.SaveChanges();
        }
    }
}
