// Ignore Spelling: Efford

using System.Data;

namespace Board.Entities
{

    public class Epic 
    {
        //Epic
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class Issue
    {
        //Issue
        public decimal Efford { get; set; }
    }

    public class Task
    {
        //Task
        public string Activity { get; set; }
        public decimal RemainingWork { get; set; }
    }

    public class WorkItem
    {
        //Work-item
        public int Id { get; set; }
        public string Area { get; set; }
        public string IterationPath { get; set; }
        public int Priority { get; set; }

        public string Type { get; set; }

        public List<Comment> comments { get; set; } = new List<Comment>();
        public User Author { get; set; }
        public Guid AuthorId { get; set; }

        public List<Tag> Tags { get; set; }

        public WorkItemState State { get; set; }
        public int StateId { get; set; }

    }
}
