using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class EntityAdmins : View
    {
        public enum Fields
            {
                 EntityAdminKey = 0,
                 EntityContactKey = 1,
                 EntityKey = 2
            }

            private EntityAdmin DefaultValues(EntityAdmin row)
            {
                return row;
            }

            public static io.Data.Return<EntityAdmins.EntityAdmin> GetObjectWithKey(int key)
            { 
                using(EntityAdmins objects = new EntityAdmins(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<EntityAdmins.EntityAdmin>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<EntityAdmins.EntityAdmin>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tEntityAdmins";
                _source = @"tEntityAdmins";
                _id = @"EntityAdminKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());

                base.Query();
            }

            public EntityAdmins(int entityAdminKey, params Fields[] selectFields)
            {
                _where = "EntityAdminKey = " + entityAdminKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityAdmins(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityAdmins(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityAdmins(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityAdmin this[int index]
            {
                get { return (EntityAdmin)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EntityAdmin(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(EntityAdmin);
            }

            public EntityAdmin NewEntityAdmin()
            {
                EntityAdmin row = (EntityAdmin)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class EntityAdmin : io.Data.ViewRow
            {

                internal EntityAdmin(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int EntityAdminKey
                {
                    get { return this.DBInteger(Fields.EntityAdminKey.ToString()); }
                }

                public int EntityContactKey
                {
                    get { return this.DBInteger(Fields.EntityContactKey.ToString()); }
                    set { this.SetDBInteger(Fields.EntityContactKey.ToString(), value); }
                }

                public int EntityKey
                {
                    get { return this.DBInteger(Fields.EntityKey.ToString()); }
                    set { this.SetDBInteger(Fields.EntityKey.ToString(), value); }
                }
            }
        }
    }
