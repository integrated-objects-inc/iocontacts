using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Views.DataContracts.Login
{
    [System.ComponentModel.DesignerCategory("")]
    public class GetUser : View
    {
        public enum Fields
            {
                 Active = 0,
                 Email = 1,
                 EntityContactKey = 2,
                 EntityLocationKey = 3,
                 FirstName = 4,
                 LastName = 5,
                 Password = 6
            }

            public const Int16 EMAIL_MAXLENGTH = 50;
            public const Int16 FIRSTNAME_MAXLENGTH = 30;
            public const Int16 LASTNAME_MAXLENGTH = 30;
            public const Int16 PASSWORD_MAXLENGTH = 20;

            private User DefaultValues(User row)
            {
                return row;
            }

            private string _email = "";

            private void Init()
            {
                var sql = new StringBuilder(@"SELECT EntityContactKey, EntityLocationKey, FirstName, LastName, Email, Active, Password FROM dbo.tEntityContacts WHERE (Email = @EMAIL)");

                base.AddParameterValue("@EMAIL", _email);

                _view = sql.ToString();
                _source = "";
                _id = "EntityContactKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());
                base.Query();
            }

            public GetUser(string email)
            {
                _email = email;
                Init(); 
            }

            public User this[int index]
            {
                get { return (User)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new User(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(User);
            }

            public User NewUser()
            {
                User row = (User)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class User : io.Data.ViewRow
            {

                internal User(DataRowBuilder rb, IView view) : base(rb, view)
                {
                }

                public bool Active
                {
                    get { return this.DBBoolean(Fields.Active.ToString()); }
                }

                public string Email
                {
                    get { return this.DBString(Fields.Email.ToString()); }
                }

                public int EntityContactKey
                {
                    get { return this.DBInteger(Fields.EntityContactKey.ToString()); }
                }

                public int EntityLocationKey
                {
                    get { return this.DBInteger(Fields.EntityLocationKey.ToString()); }
                }

                public string FirstName
                {
                    get { return this.DBString(Fields.FirstName.ToString()); }
                }

                public string LastName
                {
                    get { return this.DBString(Fields.LastName.ToString()); }
                }

                public string Password
                {
                    get { return this.DBString(Fields.Password.ToString()); }
                }
            }
        }
    }
