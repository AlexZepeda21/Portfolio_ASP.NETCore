namespace Portfolio.Models
{
    public class Technology
    {
        public int IdTechnology { get; set; }
        public string NameTechnology { get; set; }
        public byte[] ImageIcon { get; set; }
        public List<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}
