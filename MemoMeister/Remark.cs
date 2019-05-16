using System;

namespace MemoMeister
{
    public class Remark
    {
        public int MemoKey { get; internal set; }
        public DateTime DateStamp { get; internal set; }
        public string UserId { get; internal set; }
        public string MemoText { get; internal set; }
        private short entityType;
        public short EntityType
        {
            get
            {
                return entityType == 0 ? (short)RemarkType.Context.EntityKey : entityType;
            }

            internal set
            {
                entityType = value;
            }
        }

        public bool IsDirty { get; internal set; }
        public RemarkType RemarkType { get; internal set; }
        public string TypeId { get { return RemarkType.TypeId; } }
        public int OwnerKey { get { return RemarkType.Context.OwnerKey; } }
        public bool CanDelete { get { return RemarkType.CanDelete == 1; } }
        public bool CanUpdate { get { return RemarkType.CanUpdate == 1; } }
        public bool CanCreate { get { return RemarkType.CanCreate == 1; } }
        public bool CanRead { get { return RemarkType.CanRead == 1; } }
        public string Caption { get { return RemarkType.Caption; } }



        public void Commit()
        {
            DateStamp = DateTime.Now;

            if (string.IsNullOrEmpty(UserId))
                UserId = RemarkType.Context.UserId;


            if(MemoKey == 0)
                DAL.AddRemark(this);
            else
                DAL.UpdateRemark(this);

            IsDirty = false;
        }


        public void Delete()
        {
            DAL.DeleteRemark(MemoKey);
        }


        public void Initialize(RemarkType remarkType, int memoKey, DateTime dateStamp, string memoText, bool isDirty)
        {
            RemarkType = remarkType;
            MemoKey = memoKey;
            DateStamp = dateStamp;
            MemoText = memoText;
            IsDirty = isDirty;
        }

        public Remark Clone()
        {
            var remarkToReturn = new Remark();
            remarkToReturn.Initialize(RemarkType, MemoKey, DateStamp, MemoText, IsDirty);

            return remarkToReturn;
        }
    }
}
