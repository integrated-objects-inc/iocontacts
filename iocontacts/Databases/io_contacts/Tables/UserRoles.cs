using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class UserRoles : View
    {
        public enum Fields
            {
                 Enabled = 0,
                 UserRoleKey = 1,
                 UserRoleName = 2
            }

            public const Int16 USERROLENAME_MAXLENGTH = 50;

            private UserRole DefaultValues(UserRole row)
            {
                return row;
            }

            public static io.Data.Return<UserRoles.UserRole> GetObjectWithKey(int key)
            { 
                using(UserRoles objects = new UserRoles(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<UserRoles.UserRole>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<UserRoles.UserRole>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tUserRoles";
                _source = @"tUserRoles";
                _id = @"UserRoleKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());

                base.Query();
            }

            public UserRoles(int userRoleKey, params Fields[] selectFields)
            {
                _where = "UserRoleKey = " + userRoleKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public UserRoles(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public UserRoles(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public UserRoles(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public UserRole this[int index]
            {
                get { return (UserRole)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new UserRole(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(UserRole);
            }

            public UserRole NewUserRole()
            {
                UserRole row = (UserRole)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class UserRole : io.Data.ViewRow
            {

                internal UserRole(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public bool Enabled
                {
                    get { return this.DBBoolean(Fields.Enabled.ToString()); }
                    set { this.SetDBBoolean(Fields.Enabled.ToString(), value); }
                }

                public int UserRoleKey
                {
                    get { return this.DBInteger(Fields.UserRoleKey.ToString()); }
                }

                public string UserRoleName
                {
                    get { return this.DBString(Fields.UserRoleName.ToString()); }
                    set { this.SetDBString(Fields.UserRoleName.ToString(), value, USERROLENAME_MAXLENGTH); }
                }
            }
        }
    }
