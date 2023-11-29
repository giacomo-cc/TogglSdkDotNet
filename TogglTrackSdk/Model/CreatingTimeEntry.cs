namespace TogglTrackSdk.Model;

public class CreatingTimeEntry : DraftTimeEntry
{
    public enum TagActionEnum
    {
        Add,
        Delete
    }

    public new long? UserId { get; set; }
    public string CreatedWith { get; set; }
    public TagActionEnum? TagAction { get; set; }
}
