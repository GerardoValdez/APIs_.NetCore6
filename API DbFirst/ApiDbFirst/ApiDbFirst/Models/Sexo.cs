using System;
using System.Collections.Generic;

namespace ApiDbFirst.Models;

public partial class Sexo
{
    public Guid Id { get; set; }

    public string Sexo1 { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
