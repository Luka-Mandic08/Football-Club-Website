namespace FootballClubBackend.Model;

public class Team
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Badge { get; set; }

    public Team(string name)
    {
        this.Id = new Guid();
        this.Name = name;
    }
}