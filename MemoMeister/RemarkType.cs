namespace MemoMeister
{
    public class RemarkType
    {
        public string TypeId { get; set; }
        public string Caption { get; set; }
        public bool ShowPopup { get; set; }
        public short CanCreate { get; set; }
        public short CanRead { get; set; }
        public short CanUpdate { get; set; }
        public short CanDelete { get; set; }
        public RemarkContext Context { get; set; }
    }
}
