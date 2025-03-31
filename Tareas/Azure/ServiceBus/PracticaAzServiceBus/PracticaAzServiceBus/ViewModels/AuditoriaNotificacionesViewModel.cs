using PracticaAzServiceBus.Models;

namespace PracticaAzServiceBus.ViewModels
{
    public class AuditoriaNotificacionesViewModel
    {
        public List<Transaccion> Transacciones { get; set; }
        public List<Transaccion> TransaccionesPorNotificar { get; set; }
    }
}
