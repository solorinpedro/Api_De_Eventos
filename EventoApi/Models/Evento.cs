using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models;

public partial class Evento
{
    [Key]
    public int Id { get; set; }

    public string Imagen { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Nombre { get; set; } = null!;

    public string Lugar { get; set; } = null!;
}
