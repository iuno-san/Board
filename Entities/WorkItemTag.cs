namespace Board.Entities
{
    public class WorkItemTag
    {
        public WorkItem workItem { get; set; }
        public int workItemId { get; set; }

        public Tag Tag { get; set;}
        public int TagId { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
