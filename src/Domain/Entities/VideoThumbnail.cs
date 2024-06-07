namespace AmazonPrimeClone.Domain.Entities;
public class VideoThumbnail : BaseEntity<string>
{
    public string? VideoContentId { get; set; }
    public byte[]? Thumbnail { get; set; }
    public VideoContent VideoContent { get; set; } = null!;
}
