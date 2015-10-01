using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class EntityLocationAdmins : View
    {
        public enum Fields
            {
                 EntityContactKey = 0,
                 EntityLocationAdminKey = 1,
                 EntityLocationKey = 2
            }

            private EntityLocationAdmin DefaultValues(EntityLocationAdmin row)
            {
                return row;
            }

            public static io.Data.Return<EntityLocationAdmins.EntityLocationAdmin> GetObjectWithKey(int key)
            { 
                using(EntityLocationAdmins objects = new EntityLocationAdmins(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<EntityLocationAdmins.EntityLocationAdmin>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<EntityLocationAdmins.EntityLocationAdmin>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tEntityLocationAdmins";
                _source = @"tEntityLocationAdmins";
                _id = @"EntityLocationAdminKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());

                base.Query();
            }

            public EntityLocationAdmins(int entityLocationAdminKey, params Fields[] selectFields)
            {
                _where = "EntityLocationAdminKey = " + entityLocationAdminKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityLocationAdmins(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityLocationAdmins(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityLocationAdmins(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityLocationAdmin this[int index]
            {
                get { return (EntityLocationAdmin)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EntityLocationAdmin(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(EntityLocationAdmin);
            }

            public EntityLocationAdmin NewEntityLocationAdmin()
            {
                EntityLocationAdmin row = (EntityLocationAdmin)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class EntityLocationAdmin : io.Data.ViewRow
            {

                internal EntityLocationAdmin(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int EntityContactKey
                {
                    get { return this.DBInteger(Fields.EntityContactKey.ToString()); }
                    set { this.SetDBInteger(Fields.EntityContactKey.ToString(), value); }
                }

                public int EntityLocationAdminKey
                {
                    get { return this.DBInteger(Fields.EntityLocationAdminKey.ToString()); }
                }

                public int EntityLocationKey
                {
                    get { return this.DBInteger(Fields.EntityLocationKey.ToString()); }
                    set { this.SetDBInteger(Fields.EntityLocationKey.ToString(), value); }
                }
            }
        }
    }
