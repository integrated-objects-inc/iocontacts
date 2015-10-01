using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class EntityContactRoles : View
    {
        public enum Fields
            {
                 EntityContactKey = 0,
                 EntityKey = 1,
                 EntityRoleKey = 2,
                 UserRoleKey = 3
            }

            private EntityContactRole DefaultValues(EntityContactRole row)
            {
                return row;
            }

            public static io.Data.Return<EntityContactRoles.EntityContactRole> GetObjectWithKey(int key)
            { 
                using(EntityContactRoles objects = new EntityContactRoles(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<EntityContactRoles.EntityContactRole>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<EntityContactRoles.EntityContactRole>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tEntityContactRoles";
                _source = @"tEntityContactRoles";
                _id = @"EntityRoleKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());

                base.Query();
            }

            public EntityContactRoles(int entityRoleKey, params Fields[] selectFields)
            {
                _where = "EntityRoleKey = " + entityRoleKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityContactRoles(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityContactRoles(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityContactRoles(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityContactRole this[int index]
            {
                get { return (EntityContactRole)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EntityContactRole(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(EntityContactRole);
            }

            public EntityContactRole NewEntityContactRole()
            {
                EntityContactRole row = (EntityContactRole)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class EntityContactRole : io.Data.ViewRow
            {

                internal EntityContactRole(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
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

                public int EntityRoleKey
                {
                    get { return this.DBInteger(Fields.EntityRoleKey.ToString()); }
                }

                public int UserRoleKey
                {
                    get { return this.DBInteger(Fields.UserRoleKey.ToString()); }
                    set { this.SetDBInteger(Fields.UserRoleKey.ToString(), value); }
                }
            }
        }
    }
