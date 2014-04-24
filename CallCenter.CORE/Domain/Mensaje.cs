using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.CORE.Domain
{
    public class Mensaje
    {
        /// <sumary>
        /// Identificador único del mensaje
        /// <sumary>
        public Guid Id { get; set; }
        /// <sumary>
        /// Fecha de la creación del mensaje
        /// <sumary>
        public DateTime Fecha { set; get; }
        /// <sumary>
        /// Texto del mensaje
        /// <sumary>
        public String Texto { set; get; }
        /// <sumary>
        /// Usuario que escribe el mensaje
        /// </sumary>
        public Guid UserId { get; set; }
        /// <sumary>
        /// Incidencia a la que pertenece el mensaje
        /// </sumary>
        public Guid IncidenciaId { get; set; }
    }
}
