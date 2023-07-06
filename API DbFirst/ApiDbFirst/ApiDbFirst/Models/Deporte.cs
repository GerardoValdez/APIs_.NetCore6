using System;
using System.Collections.Generic;


namespace ApiDbFirst.Models;

public partial class Deporte
{
    public Guid Id { get; set; }

    public string Deporte1 { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public Guid IdTipoDeporte { get; set; }

    public virtual TipoDeporte IdTipoDeporteNavigation { get; set; } = null!; //hace el join para mostrar el tipo de deporte
}
