using System.Reflection;
using System.Runtime.InteropServices;

namespace FootballClubBackend.Model.Statistics
{
    public class MatchStatistics
    {
        public GeneralMatchStatistics GeneralMatchStatistics { get; set; }
        public AttackingMatchStatistics AttackingMatchStatistics { get; set; }
        public PassingMatchStatistics PassingMatchStatistics { get; set; }
        public DefendingMatchStatistics DefendingMatchStatistics { get; set; }
    }

    public class GeneralMatchStatistics
    {
        public float Possession { get; set; }
        public float DuelSuccessRate { get; set; }
        public float AerialDuelSuccessRate { get; set; }
        public int Interceptions { get; set; }
        public int Offsides { get; set; }
        public int Corners { get; set; }
        public int Passes { get; set; }
    }

    public class AttackingMatchStatistics
    {
        public int Goals { get; set; }
        public int Shots { get; set; }
        public int ShotsOnTarget { get; set; }
        public int BlockedShots { get; set; }
        public int ShotsOutsideTheBox { get; set; }
        public int ShotsInsideTheBox { get; set; }
        public float ShootingAccuracy { get; set; }
    }

    public class PassingMatchStatistics
    {
        public int LongPasses { get; set; }
        public float PassingAccuracy { get; set; }
        public float PassingAccuracyInOpponentsHalf { get; set; }
        public int Crosses { get; set; }
        public float CrossingAccuracy { get; set; }
    }

    public class DefendingMatchStatistics
    {
        public int Tackles { get; set; }
        public float TackleSuccessRate { get; set; }
        public int Clearances { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int Fouls { get; set; }
    }
}
