using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models;

public partial class Ticket
{
    [Key]
    public int Id { get; set; }

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public string Area { get; set; } = null!;

    public string NombreUsuario { get; set; } = string.Empty!;

    public string NombreEvento { get; set; } = string.Empty!;

    public int EventoId { get; set; }

    public Evento Evento { get; set; }
}
