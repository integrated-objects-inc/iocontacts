using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Views.Middleware
{
    [System.ComponentModel.DesignerCategory("")]
    public class ActivateUser_EntityContacts : View
    {
        public enum Fields
            {
                 Email = 0,
                 EntityContactKey = 1,
                 InviteExpires = 2,
                 Password = 3,
                 PasswordExpired = 4,
                 UID = 5
            }

            public const Int16 EMAIL_MAXLENGTH = 50;
            public const Int16 PASSWORD_MAXLENGTH = 20;
            public const Int16 UID_MAXLENGTH = 36;

            private ActivateUser_EntityContact DefaultValues(ActivateUser_EntityContact row)
            {
                return row;
            }

            public static io.Data.Return<ActivateUser_EntityContacts.ActivateUser_EntityContact> GetObjectWithKey(int key)
            { 
                using(ActivateUser_EntityContacts objects = new ActivateUser_EntityContacts(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<ActivateUser_EntityContacts.ActivateUser_EntityContact>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<ActivateUser_EntityContacts.ActivateUser_EntityContact>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"vmw_ActivateUser_EntityContacts";
                _source = @"tEntityContacts";
                _id = @"EntityContactKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());

                base.Query();
            }

            public ActivateUser_EntityContacts(int entityContactKey, params Fields[] selectFields)
            {
                _where = "EntityContactKey = " + entityContactKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ActivateUser_EntityContacts(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ActivateUser_EntityContacts(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ActivateUser_EntityContacts(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ActivateUser_EntityContact this[int index]
            {
                get { return (ActivateUser_EntityContact)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ActivateUser_EntityContact(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(ActivateUser_EntityContact);
            }

            public ActivateUser_EntityContact NewActivateUser_EntityContact()
            {
                ActivateUser_EntityContact row = (ActivateUser_EntityContact)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class ActivateUser_EntityContact : io.Data.ViewRow
            {

                internal ActivateUser_EntityContact(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public string Email
                {
                    get { return this.DBString(Fields.Email.ToString()); }
                }

                public int EntityContactKey
                {
                    get { return this.DBInteger(Fields.EntityContactKey.ToString()); }
                }

                public string InviteExpires
                {
                    get { return this.DBDate(Fields.InviteExpires.ToString()); }
                    set { this.SetDBDate(Fields.InviteExpires.ToString(), Convert.ToDateTime(value)); }
                }

                public string Password
                {
                    get { return this.DBString(Fields.Password.ToString()); }
                    set { this.SetDBString(Fields.Password.ToString(), value, PASSWORD_MAXLENGTH); }
                }

                public bool PasswordExpired
                {
                    get { return this.DBBoolean(Fields.PasswordExpired.ToString()); }
                    set { this.SetDBBoolean(Fields.PasswordExpired.ToString(), value); }
                }

                public string UID
                {
                    get { return this.DBString(Fields.UID.ToString()); }
                }
            }
        }
    }
