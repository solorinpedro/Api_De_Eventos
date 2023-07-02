using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EventoApi.Models;

public partial class Evento
{
    [Key]
    public int Id { get; set; }

    public string Imagen { get; set; } = null!;

    [JsonConverter(typeof(ConvertirFecha))]
    public DateTime Fecha { get; set; }

    public string Nombre { get; set; } = null!;

    public string Lugar { get; set; } = null!;

    public int CantidadTicket { get; set; }
}

