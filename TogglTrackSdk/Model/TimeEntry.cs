using System;

namespace TogglTrackSdk.Model;

public class TimeEntry
{
    public long Id { get; set; }
    public long WorkspaceId { get; set; }
    public long? ProjectId { get; set; }
    public int? TaskId { get; set; }
    public bool Billable { get; set; }
    public DateTime Start { get; set; }
    public DateTime? Stop { get; set; }
    public long Duration { get; set; }
    public string? Description { get; set; }
    public string[] Tags { get; set; }
    public long[] TagIds { get; set; }
    //public bool Duronly { get; set; }
    public DateTime At { get; set; }
    public DateTime? ServerDeletedAt { get; set; }
    public long UserId { get; set; }
    public long Uid { get; set; }
    public long Wid { get; set; }
}
