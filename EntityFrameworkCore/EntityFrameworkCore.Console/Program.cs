using EntityFrameworkCore.Data;

var context = new FotballLeagueDbContext();

var teams = context.Teams.ToList();

foreach (var team in teams)
{
    Console.WriteLine($"Team: {team.Name}, CreatedDate: {team.CreatedDate}");
}
