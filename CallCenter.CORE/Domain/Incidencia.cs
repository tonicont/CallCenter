using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.CORE.Domain
{
    public class Incidencia
    {
        /// <sumary>
        /// Identificador único de la incidencia
        /// <sumary>
        public Guid Id { get; set; }
        /// <summary>
        /// Descipción de la incidencia
        /// </summary>
        public String Descripcion { get; set; }
        /// <sumary>
        /// Fecha de la creación de la incidencia
        /// <sumary>
        public DateTime Fecha { get; set; }
        /// <sumary>
        /// Equipo de la incidencia
        /// <sumary>
        public Equipo Equipo { get; set; }
        /// <summary>
        /// Usuario que inicia la incidencia
        /// </summary>
        public Guid UserId { get; set; }
        /// <sumary>
        /// Estado de la incidencia
        /// <sumary>
        public EstadoIncidencia Estado { get; set; }
        /// <sumary>
        /// Colección de mensajes de la incidencia
        /// <sumary>
        public ICollection<Mensaje> Mensajes { get; set; }
    }

    public enum EstadoIncidencia : int
    {
        Abierta = 0,
        EnProceso = 1,
        Cerrada = 2
    }
}
