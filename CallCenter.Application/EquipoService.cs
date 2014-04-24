using CallCenter.DAO;
using CallCenter.CORE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace CallCenter.Application
{
    public class EquipoService
    {
        private DBContext _dbContext;

        public EquipoService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <sumary>
        /// Método que inserta un equipo en la base de datos
        /// </sumary>
        /// <param name="equipo">Equipo</param>
        public void Insert(Equipo equipo)
        {
            _dbContext.Equipos.Add(equipo);
            _dbContext.SaveChanges();
        }

        /// <sumary>
        /// Método que actualiza un equipo en la base de datos
        /// </sumary>
        /// <param name="equipo">Equipo</param>
        public void Update(Equipo equipo)
        {
            Equipo EquipoBD = GetById(equipo.Id);

            if (EquipoBD != null)
            {
                EquipoBD.Id = equipo.Id;
                EquipoBD.Nombre = equipo.Nombre;
                EquipoBD.Tipo = equipo.Tipo;
                EquipoBD.Descripcion = equipo.Descripcion;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("No se ha encontrado el registro para actualizar");
            }
        }

        /// <sumary>
        /// Método que elimina un equipo de la base de datos
        /// </sumary>
        /// <param name="idEquipo">Identificador del equipo</param>
        public void Delete(Guid idEquipo)
        {
            Equipo EquipoBD = GetById(idEquipo);

            if (EquipoBD != null)
            {
                _dbContext.Equipos.Remove(EquipoBD);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("No se encotró el retistro para eliminar");
            }
        }

        /// <sumary>
        /// Método que retorna un Equipo a través de su identificador
        /// </sumary>
        /// <param name="idEquipo">Identificador del Equipo</param>
        /// <returns>Entidad con el identificador indicaco. Null si no se encuentra el identificador</returns>
        public Equipo GetById(Guid idEquipo)
        {
            return _dbContext.Equipos.Include(e => e.Tipo).Where(e => e.Id == idEquipo).SingleOrDefault();
        }

        /// <sumary>
        /// Método que retorna una lista de Equipos de un usuario determinado
        /// </sumary>
        /// <param name="userId">Identificador del usuario</param>
        /// <returns>Lista de Equipos de un usuario concreto</returns>
        public IQueryable<Equipo> GetByUserId(Guid userId)
        {
            return _dbContext.Equipos.Include(e => e.Tipo).Where(e => e.UserId == userId);
        }

    }
}
