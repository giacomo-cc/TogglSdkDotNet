using System;

namespace TogglTrackSdk.Model;

public class TimeEntry : DraftTimeEntry
{
    //public bool Duronly { get; set; }
    public DateTime At { get; set; }
    public DateTime? ServerDeletedAt { get; set; }
    public long Uid { get; set; }
    public long Wid { get; set; }
}
