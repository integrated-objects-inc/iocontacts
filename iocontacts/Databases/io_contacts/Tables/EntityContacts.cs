using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class EntityContacts : View
    {
        public enum Fields
            {
                 Active = 0,
                 ContactPhone1 = 1,
                 ContactPhone2 = 2,
                 DateCreated = 3,
                 Email = 4,
                 EntityContactKey = 5,
                 EntityLocationKey = 6,
                 EntityLocationKey_Managing = 7,
                 FirstName = 8,
                 InviteExpires = 9,
                 LastName = 10,
                 Password = 11,
                 PasswordExpired = 12,
                 Phone1TypeKey = 13,
                 Phone2TypeKey = 14,
                 Title = 15,
                 UID = 16
            }

            public const Int16 CONTACTPHONE1_MAXLENGTH = 50;
            public const Int16 CONTACTPHONE2_MAXLENGTH = 50;
            public const Int16 EMAIL_MAXLENGTH = 50;
            public const Int16 FIRSTNAME_MAXLENGTH = 30;
            public const Int16 LASTNAME_MAXLENGTH = 30;
            public const Int16 PASSWORD_MAXLENGTH = 50;
            public const Int16 TITLE_MAXLENGTH = 50;
            public const Int16 UID_MAXLENGTH = 36;

            private EntityContact DefaultValues(EntityContact row)
            {
                return row;
            }

            public static io.Data.Return<EntityContacts.EntityContact> GetObjectWithKey(int key)
            { 
                using(EntityContacts objects = new EntityContacts(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<EntityContacts.EntityContact>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<EntityContacts.EntityContact>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tEntityContacts";
                _source = @"tEntityContacts";
                _id = @"EntityContactKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());

                base.Query();
            }

            public EntityContacts(int entityContactKey, params Fields[] selectFields)
            {
                _where = "EntityContactKey = " + entityContactKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityContacts(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityContacts(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityContacts(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityContact this[int index]
            {
                get { return (EntityContact)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EntityContact(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(EntityContact);
            }

            public EntityContact NewEntityContact()
            {
                EntityContact row = (EntityContact)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class EntityContact : io.Data.ViewRow
            {

                internal EntityContact(DataRowBuilder rb, IView view) : base(rb, view)
                {
                }

                public bool Active
                {
                    get { return this.DBBoolean(Fields.Active.ToString()); }
                    set { this.SetDBBoolean(Fields.Active.ToString(), value); }
                }

                public string ContactPhone1
                {
                    get { return this.DBString(Fields.ContactPhone1.ToString()); }
                    set { this.SetDBString(Fields.ContactPhone1.ToString(), value, CONTACTPHONE1_MAXLENGTH); }
                }

                public string ContactPhone2
                {
                    get { return this.DBString(Fields.ContactPhone2.ToString()); }
                    set { this.SetDBString(Fields.ContactPhone2.ToString(), value, CONTACTPHONE2_MAXLENGTH); }
                }

                public string DateCreated
                {
                    get { return this.DBDate(Fields.DateCreated.ToString()); }
                }

                public string Email
                {
                    get { return this.DBString(Fields.Email.ToString()); }
                    set { this.SetDBString(Fields.Email.ToString(), value, EMAIL_MAXLENGTH); }
                }

                public int EntityContactKey
                {
                    get { return this.DBInteger(Fields.EntityContactKey.ToString()); }
                }

                public int EntityLocationKey
                {
                    get { return this.DBInteger(Fields.EntityLocationKey.ToString()); }
                    set { this.SetDBInteger(Fields.EntityLocationKey.ToString(), value, false); }
                }

                public int EntityLocationKey_Managing
                {
                    get { return this.DBInteger(Fields.EntityLocationKey_Managing.ToString()); }
                    set { this.SetDBInteger(Fields.EntityLocationKey_Managing.ToString(), value); }
                }

                public string FirstName
                {
                    get { return this.DBString(Fields.FirstName.ToString()); }
                    set { this.SetDBString(Fields.FirstName.ToString(), value, FIRSTNAME_MAXLENGTH); }
                }

                public string InviteExpires
                {
                    get { return this.DBDate(Fields.InviteExpires.ToString()); }
                    set { this.SetDBDate(Fields.InviteExpires.ToString(), Convert.ToDateTime(value)); }
                }

                public string LastName
                {
                    get { return this.DBString(Fields.LastName.ToString()); }
                    set { this.SetDBString(Fields.LastName.ToString(), value, LASTNAME_MAXLENGTH); }
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

                public int Phone1TypeKey
                {
                    get { return this.DBInteger(Fields.Phone1TypeKey.ToString()); }
                    set { this.SetDBInteger(Fields.Phone1TypeKey.ToString(), value); }
                }

                public int Phone2TypeKey
                {
                    get { return this.DBInteger(Fields.Phone2TypeKey.ToString()); }
                    set { this.SetDBInteger(Fields.Phone2TypeKey.ToString(), value); }
                }

                public string Title
                {
                    get { return this.DBString(Fields.Title.ToString()); }
                    set { this.SetDBString(Fields.Title.ToString(), value, TITLE_MAXLENGTH); }
                }

                public string UID
                {
                    get { return this.DBString(Fields.UID.ToString()); }
                    set { this.SetDBString(Fields.UID.ToString(), value, UID_MAXLENGTH); }
                }
            }
        }
    }
