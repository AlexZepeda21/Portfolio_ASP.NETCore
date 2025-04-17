namespace Portfolio.Models
{
    public class Image
    {
        public int IdImage { get; set; }
        public int? ProjectId { get; set; }
        public byte[]? ImageBin { get; set; }
        public Project Project { get; set; }
    }
}
