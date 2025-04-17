namespace Portfolio.Models
{
    public class ProjectCategory
    {
        public int IdProjectCategory { get; set; }
        public string NameCategory { get; set; }
        public byte[]? ImageCategory { get; set; }

        public string Description { get; set; }
        public List<Project> Projects { get; set; }

    }
}
