﻿namespace AmazonPrimeClone.Domain.Entities;
public class ReportedVideo : BaseEntity<string>
{
    public string? UserId { get; set; }
    public string? VideoContentId { get; set; }
    public UserProfile User { get; set; } = null!;
    public VideoContent VideoContent { get; set; } = null!;
}
