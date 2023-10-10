using System.Reflection;
using System.Runtime.InteropServices;

namespace FootballClubBackend.Model.Statistics
{
    public class MatchStatistics
    {
        private Guid Id { get; set; }

        private GeneralMatchStatistics GeneralMatchStatistics { get; set; }
        private AttackingMatchStatistics AttackingMatchStatistics { get; set; }
        private PassingMatchStatistics PassingMatchStatistics { get; set; }
        private DefendingMatchStatistics DefendingMatchStatistics { get; set; }
    }

    public class GeneralMatchStatistics
    {
        private Guid Id { get; set; }
        private float Possession { get; set; }
        private float DuelSuccessRate { get; set; }
        private float AerialDuelSuccessRate { get; set; }
        private int Interceptions { get; set; }
        private int Offsides { get; set; }
        private int Corners { get; set; }
        private int Passes { get; set; }
    }

    public class AttackingMatchStatistics
    {
        private Guid Id { get; set; }
        private int Goals { get; set; }
        private int Shots { get; set; }
        private int ShotsOnTarget { get; set; }
        private int BlockedShots { get; set; }
        private int ShotsOutsideTheBox { get; set; }
        private int ShotsInsideTheBox { get; set; }
        private float ShootingAccuracy { get; set; }
    }

    public class PassingMatchStatistics
    {
        private Guid Id { get; set; }
        private int LongPasses { get; set; }
        private float PassingAccuracy { get; set; }
        private float PassingAccuracyInOpponentsHalf { get; set; }
        private int Crosses { get; set; }
        private float CrossingAccuracy { get; set; }
    }

    public class DefendingMatchStatistics
    {
        private Guid Id { get; set; }
        private int Tackles { get; set; }
        private float TackleSuccessRate { get; set; }
        private int Clearances { get; set; }
        private int YellowCards { get; set; }
        private int RedCards { get; set; }
        private int Fouls { get; set; }
    }
}
