using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.CORE.Domain
{
    public class TipoEquipo
    {
        /// <sumary>
        /// Identificador único del tipo equipo
        /// <sumary>
        public Guid Id { get; set; }
        /// <sumary>
        /// Nombre del tipo de equipo
        /// <sumary>
        public String Nombre { get; set; }
        /// <sumary>
        /// Descripción del tipo de equipo
        /// </sumary>
        public String Descripcion { get; set; }
    }
}
