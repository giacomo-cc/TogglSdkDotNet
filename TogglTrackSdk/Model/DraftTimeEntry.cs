using System;

namespace TogglTrackSdk.Model;

public class DraftTimeEntry
{
    public bool Billable { get; set; }
    public string Description { get; set; }
    public long? Duration { get; set; }
    public long? ProjectId { get; set; }
    public DateTime Start { get; set; }
    public DateTime? Stop { get; set; }
    public long[] TagIds { get; set; }
    public string[] Tags { get; set; }
    public int? TaskId { get; set; }
    public long UserId { get; set; }
    public long WorkspaceId { get; set; }

}
