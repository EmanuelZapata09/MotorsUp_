using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class RolXpermiso
    {
        public int IdRolXpermiso { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }

        public virtual Permiso? IdPermisoNavigation { get; set; } = null!;
        public virtual Role? IdRolNavigation { get; set; } = null!;
    }
}
