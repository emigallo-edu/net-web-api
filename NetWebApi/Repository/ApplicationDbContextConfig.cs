using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository
{
    internal static class ApplicationDbContextConfig
    {
        internal static void ConfigClub(this ModelBuilder mb)
        {
            var entity = mb.Entity<Club>();

            entity.ToTable("Clubs", "dbo")
                .HasKey(x => x.Id);
        }

        internal static void ConfigPlayer(this ModelBuilder mb)
        {
            var entity = mb.Entity<Player>();

            entity.ToTable("Players", "dbo")
                .HasKey(x => x.Id);

            entity.HasOne(x => x.Club)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.ClubId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        internal static void ConfigMatch(this ModelBuilder mb)
        {
            var entity = mb.Entity<Match>();

            entity.ToTable("Matchs", "dbo")
                .HasKey(x => x.Id);

            entity.HasOne(x => x.LocalClub)
                .WithMany()
                .HasForeignKey(x => x.LocalClubId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.VisitingClub)
                .WithMany()
                .HasForeignKey(x => x.VisitingClubId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        internal static void ConfigMatchResult(this ModelBuilder mb)
        {
            var entity = mb.Entity<MatchResult>();

            entity.ToTable("MatchsResults", "dbo")
                .HasKey(x => x.Matchid);

            entity.HasOne(x => x.Match)
              .WithMany()
              .HasForeignKey(x => x.Matchid)
              .OnDelete(DeleteBehavior.Restrict);
        }

        internal static void ConfigStadium(this ModelBuilder mb)
        {
            var entity = mb.Entity<Stadium>();

            entity.ToTable("Stadiums", "dbo")
                .HasKey(x => x.Name);

            entity.HasOne(x => x.Club)
                .WithOne(x => x.Stadium)
                .HasForeignKey<Club>(x => x.StadiumName)
                .OnDelete(DeleteBehavior.Restrict);
        }

        internal static void ConfigTournament(this ModelBuilder mb)
        {
            var entity = mb.Entity<Tournament>();

            entity.ToTable("Tournaments", "dbo")
                .HasKey(x => x.Id);

            entity.HasMany(x => x.Standings)
              .WithOne()
              .HasForeignKey(x => x.Id)
              .OnDelete(DeleteBehavior.Restrict);
        }

        internal static void ConfigStanding(this ModelBuilder mb)
        {
            var entity = mb.Entity<Standing>();

            entity.ToTable("Standings", "dbo")
                .HasKey(x => x.Id);

            entity.HasOne(x => x.Club)
                .WithOne()
                .HasForeignKey<Standing>(x => x.ClubId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        //internal static void ConfigureStandingClub(this ModelBuilder mb)
        //{
        //    var entity = mb.Entity<StandingClub>();

        //    entity.ToTable("StandingClubs", "dbo")
        //        .HasKey(x => new { x.Id, x.ClubId });

        //    entity.HasOne(x => x.Club)
        //        .WithOne()
        //        .HasForeignKey<StandingClub>(x => x.ClubId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    entity.HasOne(x => x.Standing)
        //        .WithMany()
        //        .HasForeignKey(x => x.Id)
        //        .OnDelete(DeleteBehavior.Restrict);
        //}
    }
}