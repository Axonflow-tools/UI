namespace UI.Data.Models;

// public class Project
// {
//     public int Id { get; set; }
//     public string? Name { get; set; }
//     public string? Location { get; set; }
//     
//     public Project(string name, string location)
//     {
//         Name = name;
//         Location = location;
//     }
// }

public record Project
{
    public int Id { get; init; }          // Required for EF Core primary key
    public string Name { get; init; }     // Immutable after creation
    public string Location { get; init; }
}