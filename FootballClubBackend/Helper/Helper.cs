using FootballClubBackend.Repository;
using FootballClubBackend.Service;

namespace FootballClubBackend.Helper
{
    public class Helper
    {
        public Helper(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<PlayerService>();
            builder.Services.AddScoped<PlayerRepository>();
            builder.Services.AddScoped<PlayerStatisticRepository>();

            builder.Services.AddScoped<MatchService>();
            builder.Services.AddScoped<MatchRepository>();
        }
    }
}
