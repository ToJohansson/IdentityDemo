using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tournamet.Domain.Entities;

namespace Tournament.Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)

        {

            var db = serviceProvider.GetRequiredService<TournamentContext>();

            await db.Database.MigrateAsync();
            if (await db.TournamentDetails.AnyAsync())
            {
                return; // Database has been seeded
            }

            try
            {
                var Tournaments = GenerateTournaments(4);
                db.AddRange(Tournaments);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        private static List<TournamentDetails> GenerateTournaments(int nrOfCompanies)
        {
            var companies = new List<TournamentDetails>();

            for (int i = 1; i <= nrOfCompanies; i++)
            {
                companies.Add(new TournamentDetails
                {
                    Title = $"Tournament {i}",
                    StartDate = DateTime.UtcNow.AddDays(-i * 10),
                    Games = GenerateGames(3)
                });
            }

            return companies;
        }

        private static ICollection<Game> GenerateGames(int nrOfGames)
        {
            var games = new List<Game>();

            for (int i = 1; i <= nrOfGames; i++)
            {
                games.Add(new Game
                {
                    Title = $"Game {i}",
                    Time = DateTime.UtcNow.AddDays(-i),
                });
            }

            return games;
        }

    }
}
