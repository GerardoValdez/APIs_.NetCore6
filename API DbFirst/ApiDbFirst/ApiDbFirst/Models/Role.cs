using System;
using System.Collections.Generic;

namespace ApiDbFirst.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string Rol { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
