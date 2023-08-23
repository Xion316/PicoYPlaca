namespace PicoYPlaca.Domain;
using System;
using System.ComponentModel.DataAnnotations;

public class VehicleQuery
{
    [Required]
    [StringLength(4, MinimumLength = 3, ErrorMessage = "La placa debe tener entre 3 y 4 letras.")]
    public string PlacaLetras { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]{1,4}$", ErrorMessage = "El número de placa debe ser un valor numérico entre 1 y 9999.")]
    public int PlacaNumeros { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public TimeSpan Hora { get; set; }
}
