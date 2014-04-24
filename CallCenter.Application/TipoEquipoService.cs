using CallCenter.DAO;
using CallCenter.CORE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.Application
{
    public class TipoEquipoService
    {
        private DBContext _dbContext;

        public TipoEquipoService(DBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        /// <sumary>
        /// Método que retorna un tipo de equipo a través de su identificador.
        /// </sumary>
        /// <param name="id">Identificador</param>
        /// <returns>TipoEquipo con el identificador indicado. Null si no se encuentra</returns>
        public TipoEquipo GetById(Guid id)
        {
            return _dbContext.TiposEquipo.Find(id);
            //throw new NotImplementedException();
        }

        /// <sumary>
        /// Método que retorna una lista de todos los tipos de equipo
        /// </suamry>
        /// <returns>Lista de TipoEquipo</returns>
        public IQueryable<TipoEquipo> GetAlls()
        {
            return _dbContext.Set<TipoEquipo>();
        }

        /// <sumary>
        /// Método que inserta un tipo de equipo en la base de datos
        /// </sumary>
        /// <param name="tipoEquipo">TipoEquipo</param>
        public void Insert(TipoEquipo tipoEquipo)
        {
 
            _dbContext.TiposEquipo.Add(tipoEquipo);
            _dbContext.SaveChanges();
        }

        /// <sumary>
        /// Método que actualiza un tipo de equipo
        /// </sumary>
        /// <param name="tipoEquipo">TipoEquipo a actualizar</param>
        public void Update(TipoEquipo tipoEquipo)
        {
            TipoEquipo TipoEquipoBD = GetById(tipoEquipo.Id);
            if (TipoEquipoBD != null)
            {
                TipoEquipoBD.Id = tipoEquipo.Id;
                TipoEquipoBD.Nombre = tipoEquipo.Nombre;
                TipoEquipoBD.Descripcion = tipoEquipo.Descripcion;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("No se ha encontrado el registro a actualizar");
            }
        }

        /// <sumary>
        /// Método que elimina un tipo de equipo de la base de datos
        /// </sumary>
        /// <param name="idTipoEquipo">Identificador del tipo de equipo</param>
        public void Delete(Guid idTipoEquipo)
        {
            TipoEquipo TipoEquipoBD = GetById(idTipoEquipo);

            if (TipoEquipoBD != null)
            {
                _dbContext.TiposEquipo.Remove(TipoEquipoBD);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("No se ha encontrado el registro a eliminar");
            }
        }
    }
}
