namespace HelloLists.Model.Sync
{
    /// <summary>
    /// Wrapper around List db model
    /// </summary>
    public class ListItemUpdate : AbstractUpdate
    {
        public ListItem Item { get; set; }
    }
}
