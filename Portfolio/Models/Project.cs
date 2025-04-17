namespace Portfolio.Models
{
    public class Project
    {
        public int IdProject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? ImageProject { get; set; }
        public int? ProjectCategoryId { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        public List<Image> Images { get; set; }
        public List<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}
