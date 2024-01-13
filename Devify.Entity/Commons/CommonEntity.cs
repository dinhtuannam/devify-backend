namespace Devify.Entity.Commons
{
    public class TrackEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public TrackEntity() {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
    }
}
