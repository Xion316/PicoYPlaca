using System.ComponentModel.DataAnnotations;

namespace PicoYPlaca.Domain;

public class CirculationResult
{
    [Key]
    public Guid Id { get; set; }
    public string Placa { get; set; }
    public bool CanCirculate { get; set; }
}
