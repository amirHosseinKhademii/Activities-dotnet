namespace Domain
{

    public record Activity
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public DateTime Date { get; init; }
        public string Description { get; init; }
        public string Category { get; init; }
        public string City { get; init; }
        public string Venue { get; init; }
    }
}