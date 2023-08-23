using Microsoft.AspNetCore.Mvc;
using PicoYPlaca.Infraestructure;
using PicoYPlaca.Domain;

namespace PicoYPlaca.HttpApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CirculationController : ControllerBase
    {
        private readonly PicoYPlacaDbContext _dbContext;

        public CirculationController(PicoYPlacaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("check")]
        public IActionResult CheckCirculation(VehicleQuery query)
        {
            // Validación de fecha y hora
            var currentDateTime = DateTime.Now;
            var inputDateTime = query.Fecha.Date + query.Hora;

            if (inputDateTime < currentDateTime)
            {
                return BadRequest("La fecha y hora ingresadas son anteriores a la fecha y hora actual.");
            }

            // Validación de la placa
            if (!IsValidPlacaLetters(query.PlacaLetras))
            {
                return BadRequest("El campo 'Placa letras' debe contener solo letras y tener 3 o 4 caracteres.");
            }

            if (!IsValidPlacaNumbers(query.PlacaNumeros))
            {
                return BadRequest("El campo 'Placa números' debe contener números del 0001 al 9999.");
            }

            // Lógica de restricción de circulación
            var lastDigit = query.PlacaNumeros % 10;
            var dayOfWeek = query.Fecha.DayOfWeek;

            bool canCirculate = (lastDigit <= 2 && dayOfWeek != DayOfWeek.Monday) ||
                                (lastDigit >= 3 && lastDigit <= 4 && dayOfWeek != DayOfWeek.Tuesday) ||
                                (lastDigit >= 5 && lastDigit <= 6 && dayOfWeek != DayOfWeek.Wednesday) ||
                                (lastDigit >= 7 && lastDigit <= 8 && dayOfWeek != DayOfWeek.Thursday) ||
                                (lastDigit >= 9 && dayOfWeek != DayOfWeek.Friday);

            var placaNumerosString = query.PlacaNumeros.ToString("D4"); // Asegura que tenga 4 dígitos, con ceros a la izquierda si es necesario

            var result = new CirculationResult
            {
                Placa = query.PlacaLetras + placaNumerosString,
                CanCirculate = canCirculate
            };

            _dbContext.CirculationResults.Add(result);
            _dbContext.SaveChanges();

            if (canCirculate)
            {
                Console.WriteLine($"El vehículo con placa {result.Placa} puede circular.");
                return Ok(result);
            }
            else
            {
                if (!IsValidRestrictedTime(inputDateTime.TimeOfDay))
                {
                    return BadRequest("El vehículo no puede circular en este horario.");
                }
                else
                {
                    Console.WriteLine($"El vehículo con placa {result.Placa} no puede circular en este horario.");
                    return BadRequest("El vehículo no puede circular en este horario.");
                }
            }
        }

        private bool IsValidPlacaLetters(string placaLetras)
        {
            return !string.IsNullOrEmpty(placaLetras) && placaLetras.Length >= 3 && placaLetras.Length <= 4 && placaLetras.All(char.IsLetter);
        }

        private bool IsValidPlacaNumbers(int placaNumeros)
        {
            return placaNumeros >= 1 && placaNumeros <= 9999;
        }

        private bool IsValidRestrictedTime(TimeSpan timeOfDay)
        {
            // Horarios de restricción de circulación
            var morningStart = new TimeSpan(6, 0, 0);
            var morningEnd = new TimeSpan(9, 30, 0);
            var afternoonStart = new TimeSpan(16, 0, 0);
            var afternoonEnd = new TimeSpan(20, 0, 0);

            // Validación de horario
            return (timeOfDay < morningStart || timeOfDay > morningEnd) &&
                   (timeOfDay < afternoonStart || timeOfDay > afternoonEnd);
        }
    }
}
