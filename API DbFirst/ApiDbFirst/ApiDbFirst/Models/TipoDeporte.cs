using System;
using System.Collections.Generic;

namespace ApiDbFirst.Models;

public partial class TipoDeporte
{
    public Guid Id { get; set; }

    public string TipoDeporte1 { get; set; } = null!;

    public virtual Deporte? Deporte { get; set; }
}
