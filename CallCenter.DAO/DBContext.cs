using CallCenter.CORE;
using CallCenter.CORE.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.DAO
{
    public class DBContext : DbContext
    {
        /// 
		/// Constructor que recibe el nombre de la cadena de conexiÛn o la cadena de conexiÛn
		/// 
        public DBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
		{

		}

		/// 
		/// ColecciÛn de incidencias
		/// 
		public IDbSet<Incidencia> Incidencias { get; set; }

        ///
        /// Colección de equipos
        /// 
        public IDbSet<Equipo> Equipos { get; set; }

        ///
        /// Colección de tipos de equipos
        /// 
        public IDbSet<TipoEquipo> TiposEquipo { get; set; }

        /// 
        /// Colección de Mensajes
        /// 
        public IDbSet<Mensaje> Mensajes { get; set; }

		///... aqui tienes que poner todas las demas propiedades que tienes en CORE menos el enumerado

	}
}
