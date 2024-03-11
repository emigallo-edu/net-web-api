using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    internal static class InsertDataInTables
    {
        public static void Insert(MigrationBuilder mb)
        {
            int tournamentId = 980;
            int standingId = 4839;
            int minClubId = 5;
            int maxClubId = 10;

            //InsertTournament(mb, tournamentId);


            for (int clubId = minClubId; clubId <= maxClubId; clubId++)
            {
                InsertClub(mb, clubId);
                //InsertStanding(mb, standingId, clubId);
                InsertPlayes(mb, clubId);
                InsertStadiums(mb, clubId);
            }
        }

        private static void InsertClub(MigrationBuilder mb, int clubId)
        {
            string query = "SET IDENTITY_INSERT Clubs ON;";
            query += $"INSERT INTO Clubs (Id, Name, Birthday, City, Email, NumberOfPartners, Phone, Address)" +
               $"VALUES ({clubId}, '{GetFakedName()}', GETDATE(), '{Faker.Address.City()}', 'club1@mail.com', {new Random().Next(1, 15849)}, '{Faker.Phone.Number()}', '{Faker.Address.StreetAddress()}')";
            query += "SET IDENTITY_INSERT Clubs OFF;";

            mb.Sql(query);
        }

        private static void InsertPlayes(MigrationBuilder mb, int clubId)
        {
            for (int i = 1; i <= 23; i++)
            {
                string query = $"INSERT INTO Players (Name, Birthday, ClubId)" +
                    $"VALUES ('{GetFakedName()}', GETDATE(), {clubId})";
                mb.Sql(query);
            }
        }

        private static void InsertStadiums(MigrationBuilder mb, int clubId)
        {
            string query = $"INSERT INTO Stadiums (Name, Capacity, ClubId)" +
                $"VALUES('{GetFakedName()}', {new Random().Next(1, 5849)}, {clubId})";
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

        private static void InsertStanding(MigrationBuilder mb, int standingId, int clubId)
        {
            string query = "INSERT INTO Standings (Id, ClubId,  Win, Draw, Loss, Scoring)" +
                $"VALUES ({standingId}, {clubId}, 0, 0, 0, 0)";

            mb.Sql(query);
        }

        private static void InsertMatchs(MigrationBuilder mb, int tournamentId, int localClubId, int visitingClubId)
        {
            string query = $"INSERT INTO Matchs (Date, LocalClubId, VisitingClubId, TournamentId)" +
                   $"VALUES (GETDATE(), 1, 2, {tournamentId})";
            mb.Sql(query);
        }

        private static string GetFakedName()
        {
            return Faker.Company.Name().Replace("'", "");
        }
    }
}