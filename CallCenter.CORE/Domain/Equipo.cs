using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.CORE.Domain
{
    public class Equipo
    {
        /// <sumary>
        /// Identificador único del equipo
        /// <sumary>
        public Guid Id { get; set; }
        /// <sumary>
        /// Nombre del equipo
        /// <sumary>
        public String Nombre { get; set; }
        /// <summary>
        /// Descripción del equipo
        /// </summary>
        public String Descripcion { get; set; }
        /// <sumary>
        /// Tipo al que corresponde el equipo
        /// <sumary>
        public TipoEquipo Tipo { get; set;}
        /// <sumary>
        /// Usuario del equipo
        /// </sumary>
        public Guid UserId { get; set; }
    }
}
