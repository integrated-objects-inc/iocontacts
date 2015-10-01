using System;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Views.Middleware
{
    [System.ComponentModel.DesignerCategory("")]
    public class UserProfileExpiredPasswords : View
    {
        public enum Fields
            {
                 EntityContactKey = 0
            }

            private UserProfileExpiredPassword DefaultValues(UserProfileExpiredPassword row)
            {
                return row;
            }

            public static io.Data.Return<UserProfileExpiredPasswords.UserProfileExpiredPassword> GetObjectWithKey(int key)
            { 
                using(UserProfileExpiredPasswords objects = new UserProfileExpiredPasswords(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<UserProfileExpiredPasswords.UserProfileExpiredPassword>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<UserProfileExpiredPasswords.UserProfileExpiredPassword>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"vmw_UserProfileExpiredPasswords";
                _source = @"";
                _id = @"EntityContactKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());
                base.Query();
            }

            public UserProfileExpiredPasswords(int entityContactKey, params Fields[] selectFields)
            {
                _where = "EntityContactKey = " + entityContactKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public UserProfileExpiredPasswords(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public UserProfileExpiredPasswords(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public UserProfileExpiredPasswords(int top, string @where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = @where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public UserProfileExpiredPassword this[int index]
            {
                get { return (UserProfileExpiredPassword)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new UserProfileExpiredPassword(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(UserProfileExpiredPassword);
            }

            public UserProfileExpiredPassword NewUserProfileExpiredPassword()
            {
                UserProfileExpiredPassword row = (UserProfileExpiredPassword)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class UserProfileExpiredPassword : io.Data.ViewRow
            {

                internal UserProfileExpiredPassword(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int EntityContactKey
                {
                    get { return this.DBInteger(Fields.EntityContactKey.ToString()); }
                }
            }
        }
    }
