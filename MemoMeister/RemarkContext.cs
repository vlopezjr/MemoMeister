using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace MemoMeister
{
    public class RemarkContext
    {
        #region Properties
        public string ContextId { get; internal set; }
        public string UserId { get; internal set; }
        private string ownerId;
        public string OwnerId
        {
            get { return ownerId; }

            set
            {
                Save();
                ownerId = value;
            }
        }

        public string Server
        {
            get { return DAL.ConnectionString; }
        }

        public int RowHeight { get; internal set; }
        public short GroupByType { get; internal set; }
        public short AllowRowSizing { get; internal set; }


        public string Caption { get; internal set; }
        public int? EntityKey { get; internal set; }
        public string EntityName { get; internal set; }
        public int OwnerKey { get; internal set; }
        public string OwnerName { get; internal set; }
        public string SPGetOwnerName { get; internal set; }


        public OrderedDictionary RemarkTypes { get; internal set; }
        public List<Remark> Remarks { get; internal set; }
        public List<Remark> RemarksDeleted { get; internal set; }

        public EditBehavior EditBehavior { get; set; }
        #endregion

        public RemarkContext()
        {
            RemarksDeleted = new List<Remark>();
        }



        public void Load(string contextId, string ownerId, string userId)
        {
            Save();

            ContextId = contextId;
            OwnerId = ownerId;
            UserId = userId;

            LoadContext();

            LoadRemarkTypes();

            MergeRights();

            GetOwnerInfo();

            LoadMemos();
        }


        public void Save(bool forceSave = false)
        {
            if (!forceSave)
            {
                switch (EditBehavior)
                {
                    case EditBehavior.AutoSaveOnClose:
                        //do nothing here, continue to perform actual save
                        break;

                    case EditBehavior.NoAutoSave:
                        //exit function, nothing to be saved
                        return;

                    case EditBehavior.PromptForSave:
                        if (MessageBox.Show("Save changes to these remarks?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                        break;
                }
            }

            SaveRemarkList();
        }

        private void SaveRemarkList()
        {
            if(Remarks != null)
            {
                foreach (var remark in Remarks)
                {
                    if (remark.IsDirty)
                        remark.Commit();
                }
            }


            foreach (var remark in RemarksDeleted)
            {
                remark.Delete();
            }

            RemarksDeleted = new List<Remark>();
        }

        public void RefreshRemarkList()
        {
            Save();
            LoadMemos();
        }

        public void RemoveRemark(int memoKey)
        {
            var remarkToRemove = Remarks.First(c => c.MemoKey == memoKey);

            Remarks.Remove(remarkToRemove);
            RemarksDeleted.Add(remarkToRemove);
        }

        private void LoadContext()
        {
            using (var conn = new SqlConnection(DAL.ConnectionString))
            {
                conn.Open();

                var parameter = new SqlParameter("@ContextID", ContextId);
                var command = new SqlCommand("spCPCmmGetContext", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parameter);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Caption = (string)reader["Caption"];
                    EntityKey = (int?)reader["EntityKey"];
                    EntityName = (string)reader["EntityName"];
                    SPGetOwnerName = (string)reader["spGetOwnerName"];
                    GroupByType = (short)reader["GroupByType"];
                    RowHeight = (int)reader["RowHeight"];
                    AllowRowSizing = (short)reader["AllowRowSizing"];
                    EditBehavior = (EditBehavior)reader["EditBehavior"];
                }
            }
        }

        private void LoadRemarkTypes()
        {
            using (var conn = new SqlConnection(DAL.ConnectionString))
            {
                conn.Open();

                var parameter = new SqlParameter("@ContextID", ContextId);
                var command = new SqlCommand("spCPCmmGetRemarkTypes", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parameter);

                var reader = command.ExecuteReader();
                RemarkTypes = new OrderedDictionary();

                while (reader.Read())
                {
                    var remarkToAdd = new RemarkType
                    {
                        Context = this,
                        TypeId = (string)reader["TypeID"],
                        Caption = (string)reader["Caption"],
                        ShowPopup = (short)reader["Priority"] == 1
                    };

                    RemarkTypes.Add(remarkToAdd.TypeId, remarkToAdd);
                }
            }
        }

        private void MergeRights()
        {
            using (var conn = new SqlConnection(DAL.ConnectionString))
            {
                conn.Open();

                var parameter = new SqlParameter("@UserID", UserId);
                var command = new SqlCommand("spCPCmmGetUserRights", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(parameter);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var typeId = (string)reader["TypeID"];

                    var typeToEdit = (RemarkType)RemarkTypes[typeId];
                    if (typeToEdit != null)
                    {
                        typeToEdit.CanCreate = (short)reader["CanCreate"];
                        typeToEdit.CanRead = (short)reader["CanRead"];
                        typeToEdit.CanUpdate = (short)reader["CanUpdate"];
                        typeToEdit.CanDelete = (short)reader["CanDelete"];
                    }
                }
            }
        }

        private void GetOwnerInfo()
        {
            using (var conn = new SqlConnection(DAL.ConnectionString))
            {
                conn.Open();

                var param = new SqlParameter("@OwnerID", ownerId);

                var command = new SqlCommand(SPGetOwnerName, conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(param);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    OwnerKey = (int)reader["OwnerKey"];
                    OwnerName = (string)reader["OwnerName"];
                }
            }
        }

        private void LoadMemos()
        {
            using (var conn = new SqlConnection(DAL.ConnectionString))
            {
                conn.Open();

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ContextID", ContextId),
                    new SqlParameter("@EntityType", EntityKey),
                    new SqlParameter("@OwnerKey", OwnerKey)
                };

                var command = new SqlCommand("spCPCmmGetFilteredMemos", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                var reader = command.ExecuteReader();

                Remarks = new List<Remark>();

                while (reader.Read())
                {
                    var typeID = (string)reader["TypeID"];

                    var typeToCheckAgainst = (RemarkType)RemarkTypes[typeID];

                    if (typeToCheckAgainst != null && typeToCheckAgainst.CanRead > 0)
                    {
                        Remarks.Add(new Remark
                        {
                            RemarkType = typeToCheckAgainst,
                            MemoKey = (int)reader["MemoKey"],
                            MemoText = (string)reader["MemoText"],
                            DateStamp = (DateTime)reader["DateStamp"],
                            UserId = (string)reader["UserID"],
                            EntityType = (short)reader["EntityType"]
                        });
                    }
                }

                Remarks = Remarks.OrderBy(c => c.DateStamp).ToList();
            }
        }

        public void AddRemark(object remarkIndex, string remarkText, string userId)
        {
            RemarkType remarkType = null;

            if (remarkIndex is int)
            {
                var index = Convert.ToInt32(remarkIndex);
                remarkType = (RemarkType)RemarkTypes[index];
            }

            if (remarkIndex is string)
            {
                var index = remarkIndex.ToString();
                remarkType = (RemarkType)RemarkTypes[index];
            }

            if (remarkType == null)
            {
                throw new Exception("Illegal remark type for this context");
            }

            if (Remarks == null)
            {
                Remarks = new List<Remark>();
            }

            var remark = new Remark();
            remark.RemarkType = remarkType;
            remark.MemoText = remarkText;
            remark.UserId = userId;
            remark.DateStamp = DateTime.Now;
            remark.IsDirty = true;

            Remarks.Add(remark);
        }


        public void Edit(string contextId, string ownerId, string userId)
        {
            Load(contextId, ownerId, userId);
            EditMemos();
        }

        public void Popup(string contextId, string ownerId, string userId)
        {
            Load(contextId, ownerId, userId);
            PopupMemos();
        }

        public void PopupMemos(bool refresh = false)
        {
            if(refresh)
                RefreshRemarkList();

            var popupForm = new PopupForm();
            popupForm.View(this);
        }

        public void EditMemos(bool refresh = false)
        {
            if (refresh)
                RefreshRemarkList();

            var editForm = new EditForm();
            editForm.View(this);
        }


        public bool CanUpdate(int indexOrKey)
        {
            Remark remark = Remarks.FirstOrDefault(c => c.MemoKey == indexOrKey);

            if ((remark == null) && indexOrKey > (Remarks.Count - 1))
            {
                remark = Remarks[indexOrKey];
            }

            if (remark != null)
            {
                var remarkType = (RemarkType)RemarkTypes[remark.TypeId];
                if (remarkType != null)
                {
                    return remarkType.CanUpdate == 1;
                }
            }

            return false;
        }

        public bool CanDelete(int indexOrKey)
        {
            {
                Remark remark = Remarks.FirstOrDefault(c => c.MemoKey == indexOrKey);

                if ((remark == null) && indexOrKey > (Remarks.Count - 1))
                {
                    remark = Remarks[indexOrKey];
                }

                if (remark != null)
                {
                    var remarkType = (RemarkType)RemarkTypes[remark.TypeId];
                    if (remarkType != null)
                    {
                        return remarkType.CanDelete == 1;
                    }
                }

                return false;
            }
        }

        public bool CanCreate(int indexOrKey)
        {
            Remark remark = Remarks.FirstOrDefault(c => c.MemoKey == indexOrKey);

            if ((remark == null) && indexOrKey > (Remarks.Count - 1))
            {
                remark = Remarks[indexOrKey];
            }

            if (remark != null)
            {
                var remarkType = (RemarkType)RemarkTypes[remark.TypeId];
                if (remarkType != null)
                {
                    return remarkType.CanCreate == 1;
                }
            }

            return false;
        }
    }
}
