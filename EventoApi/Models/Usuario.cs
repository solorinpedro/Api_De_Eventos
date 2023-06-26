using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventoApi.Models;

public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null;
}
