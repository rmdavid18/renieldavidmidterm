using System.ComponentModel.DataAnnotations.Schema;

namespace renieldavid.webdev.Infrastructure.Domain.Models
{
    public class video
    {
        public Guid? VideoId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfPublish { get; set; }
        public Type? Type { get; set; }
        public Guid? Id { get; set; }

        [ForeignKey("Id")]
        public StreamingAndService? StreamingAndService { get; set; }

    }
    public enum Type
    {
        Series =1,
        Movie=2
    }
}
