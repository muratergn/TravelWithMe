namespace TravelWithMe.Event.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string EventCollectionName { get; set; }
        public string EventDetailCollectionName { get; set; }
        public string EventImageCollectionName { get; set; }
        public string ParticipantCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
