namespace EntityFrameworkCore.Domain;

public class Coach
{
    public int Id { get; set; } // sometimes called CoachId, but Id is more common for primary keys

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }
}
