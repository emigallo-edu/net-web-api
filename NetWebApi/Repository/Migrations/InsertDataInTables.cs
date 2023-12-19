using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Design;

namespace Repository.Migrations
{
    internal static class InsertDataInTables
    {
        public static void Insert(MigrationBuilder mb)
        {
            int tournamentId = 980;
            int standingId = 4839;
            int minClubId = 5;
            int maxClubId = 6;

            InsertTournament(mb, tournamentId);
            InsertStanding(mb, standingId, tournamentId);

            for (int clubId = minClubId; clubId <= maxClubId; clubId++)
            {
                InsertClub(mb, clubId);
                InsertStandingClubs(mb, clubId, standingId);
                InsertPlayes(mb, clubId);
                InsertStadiums(mb, clubId);

                //if (clubId > minClubId)
                //{
                //    InsertMatchs(mb, tournamentId, clubId, clubId - 1);
                //}
            }
        }

        private static void InsertClub(MigrationBuilder mb, int clubId)
        {
            string query = "SET IDENTITY_INSERT Clubs ON;";
            query += $"INSERT INTO Clubs (Id, Name, Birthday, City, Email, NumberOfPartners, Phone, Address)" +
               $"VALUES ({clubId}, '{Faker.Company.Name()}', GETDATE(), '{Faker.Address.City()}', 'club1@mail.com', {new Random().Next(1, 15849)}, '{Faker.Phone.Number()}', '{Faker.Address.StreetAddress}')";
            query += "SET IDENTITY_INSERT Clubs OFF;";

            mb.Sql(query);
        }

        private static void InsertStandingClubs(MigrationBuilder mb, int clubId, int standingId)
        {
            string query = "INSERT INTO StandingClubs (Id, ClubId, Position, MatchsPlayed, Win, Draw, Loss, Scoring)" +
                $"VALUES ({standingId}, {clubId}, 1, 0, 0, 0, 0, 0)";

            mb.Sql(query);
        }

        private static void InsertPlayes(MigrationBuilder mb, int clubId)
        {
            for (int i = 1; i <= 23; i++)
            {
                string query = $"INSERT INTO Players (Name, Birthday, ClubId)" +
                    $"VALUES ('{Faker.Name.FullName()}', GETDATE(), {clubId})";
                mb.Sql(query);
            }
        }

        private static void InsertStadiums(MigrationBuilder mb, int clubId)
        {
            string query = $"INSERT INTO Stadiums (Name, Capacity, ClubId)" +
                $"VALUES('{Faker.Company.Name()}', {new Random().Next(1, 5849)}, {clubId})";
            mb.Sql(query);
        }

        private static void InsertTournament(MigrationBuilder mb, int tournamentId)
        {
            string query = "SET IDENTITY_INSERT Tournaments ON;";
            query += $"INSERT INTO Tournaments (Id, Start, [End])" +
                   $"VALUES ({tournamentId}, GETDATE(), GETDATE())";
            query += "SET IDENTITY_INSERT Tournaments OFF;";

            mb.Sql(query);
        }

        private static void InsertStanding(MigrationBuilder mb, int standingId, int tournamentId)
        {
            string query = "SET IDENTITY_INSERT Standings ON;";
            query += "INSERT INTO Standings (Id, TournamentId)" +
                $"VALUES ({standingId}, {tournamentId})";
            query += "SET IDENTITY_INSERT Standings OFF;";

            mb.Sql(query);
        }

        private static void InsertMatchs(MigrationBuilder mb, int tournamentId, int localClubId, int visitingClubId)
        {
            string query = $"INSERT INTO Matchs (Date, LocalClubId, VisitingClubId, TournamentId)" +
                   $"VALUES (GETDATE(), 1, 2, {tournamentId})";
            mb.Sql(query);
        }

        public static void Rollback(MigrationBuilder mb)
        {
            mb.Sql(@"DELETE FROM Stadiums
                    DELETE FROM Standings
                    DELETE FROM Players
                    DELETE FROM Matchs
                    DELETE FROM StandingClubs
                    DELETE FROM Clubs
                    DELETE FROM Tournaments");
        }
    }
}