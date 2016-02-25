namespace HelloLists.Model.Sync
{
    /// <summary>
    /// Wrapper around Task db model
    /// </summary>
    public class TaskItemUpdate : AbstractUpdate
    {
        public TaskItem Item
        {
            get;
            set;
        }
    }
}
