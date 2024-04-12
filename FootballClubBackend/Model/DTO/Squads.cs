namespace FootballClubBackend.Model.DTO
{
    public class Squads
    {
        public ICollection<PlayerForSquad>? Squad {  get; set; }
        public ICollection<PlayerForSquad>? OpponentSquad { get; set; }
        public ICollection<PlayerForSquad>? Subs{ get; set; }
        public ICollection<PlayerForSquad>? OpponentSubs { get; set; }

        public Squads() { }

        public Squads(ICollection<Player>? squad, ICollection<Player>? eligible, ICollection<PlayerForSquad>? opponentSquad, ICollection<Player>? subs, ICollection<PlayerForSquad>? opponentSubs)
        {
            Squad = new List<PlayerForSquad>();
            if(squad != null)
                foreach (Player p in BubbleSort(squad.ToList()))
                {
                    Squad.Add(new PlayerForSquad(p));
                }
            EligiblePlayers = new List<PlayerForSquad>();
            if(eligible != null)
                foreach (Player p in BubbleSort(eligible.ToList()))
                {
                    EligiblePlayers.Add(new PlayerForSquad(p));
                }
            Subs = new List<PlayerForSquad>();
            if (subs != null)
                foreach (Player p in BubbleSort(subs.ToList()))
                {
                    Subs.Add(new PlayerForSquad(p));
                }
            OpponentSquad = opponentSquad;
            OpponentSubs = opponentSubs;
        }

        public void UpdateEligiblePlayers(ICollection<Player>? eligible)
        {
            EligiblePlayers = new List<PlayerForSquad>();
            foreach (Player p in eligible)
            {
                EligiblePlayers.Add(new PlayerForSquad(p));
            }
        }

        public List<Player> BubbleSort(List<Player> list)
        {
            int n = list.Count;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (list[j + 1].Position<=list[j].Position)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
            return list;
        }
    }

    public class PlayerForSquad
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SquadNumber { get; set; }

        public PlayerForSquad(Player player)
        {
            Id = player.Id.ToString();
            Name = player.Name;
            Surname = player.Surname;
            SquadNumber = player.SquadNumber;
        }

        public PlayerForSquad()
        {
        }
    }
}
