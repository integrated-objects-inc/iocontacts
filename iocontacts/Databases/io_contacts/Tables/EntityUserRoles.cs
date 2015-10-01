using System;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class EntityUserRoles : View
    {
        public enum Fields
            {
                 DateCreated = 0,
                 EntityUserRoleKey = 1,
                 EntityUserRoleName = 2
            }

            public const Int16 ENTITYUSERROLENAME_MAXLENGTH = 50;

            private EntityUserRole DefaultValues(EntityUserRole row)
            {
                return row;
            }

            public static io.Data.Return<EntityUserRoles.EntityUserRole> GetObjectWithKey(int key)
            { 
                using(EntityUserRoles objects = new EntityUserRoles(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<EntityUserRoles.EntityUserRole>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<EntityUserRoles.EntityUserRole>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tEntityUserRoles";
                _source = @"tEntityUserRoles";
                _id = @"EntityUserRoleKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());
                base.Query();
            }

            public EntityUserRoles(int entityUserRoleKey, params Fields[] selectFields)
            {
                _where = "EntityUserRoleKey = " + entityUserRoleKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityUserRoles(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityUserRoles(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityUserRoles(int top, string @where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = @where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityUserRole this[int index]
            {
                get { return (EntityUserRole)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EntityUserRole(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(EntityUserRole);
            }

            public EntityUserRole NewEntityUserRole()
            {
                EntityUserRole row = (EntityUserRole)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class EntityUserRole : io.Data.ViewRow
            {

                internal EntityUserRole(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public string DateCreated
                {
                    get { return this.DBDate(Fields.DateCreated.ToString()); }
                }

                public int EntityUserRoleKey
                {
                    get { return this.DBInteger(Fields.EntityUserRoleKey.ToString()); }
                }

                public string EntityUserRoleName
                {
                    get { return this.DBString(Fields.EntityUserRoleName.ToString()); }
                    set { this.SetDBString(Fields.EntityUserRoleName.ToString(), value, ENTITYUSERROLENAME_MAXLENGTH); }
                }
            }
        }
    }
