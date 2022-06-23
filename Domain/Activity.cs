namespace Domain
{
    public record Activity(Guid Id, string Title, DateTime Date, string Description, string Category, string City, string Venue);

}