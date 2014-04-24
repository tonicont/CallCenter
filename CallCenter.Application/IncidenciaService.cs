using CallCenter.DAO;
using CallCenter.CORE.Domain;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenter.Application
{
    public class IncidenciaService
    {
        private DBContext _dbContext;

        public IncidenciaService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <sumary>
        /// Método que retorna todas las incidencias 
        /// </sumary>
        /// <returns>Lista de todas las incidencias</returns>
        public IQueryable<Incidencia> GetAll()
        {
            return _dbContext.Incidencias.Include(i => i.Equipo);
        }

        /// <summary>
        /// MÈtodo que retorna una Incidencia a travÈs de su identificador
        /// retorna null si no se encuentra
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>Entidad con el identificador deseado</returns>
        public Incidencia GetById(Guid id)
        {
            return _dbContext.Incidencias.Include(i => i.Equipo).Where(i => i.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// MÈtodo que retorna una lista de Incidencias a travÈs del identificador de usuario
        /// </summary>
        /// <param name="userId">identificador del usuario</param>
        /// <returns>Lista de Incidencias de un usuario concreto</returns>
        public IQueryable<Incidencia> GetByUserId(Guid userId)
        {
            return _dbContext.Incidencias.Include(i => i.Equipo).Where(i => i.UserId == userId);
        } 

        /// <sumary>
        /// Método que retorna una lista de Incidencias a través del identificador del equipo
        /// </sumary>
        /// <param name="equipoId">Identificador del equipo</param>
        /// <returns>Lista de Incidencias de un equipo concreto</returns>
        public IQueryable<Incidencia> GetByEquipoId(Guid equipoId)
        {
            return _dbContext.Incidencias.Include(i => i.Equipo).Where(i => i.Equipo.Id == equipoId);
        }

        /// <sumary>
        /// Método que inserta una nueva Incidencia en la base de datos
        /// </sumary>
        /// <param name="incidencia">Incidencia a guardar</param>
        public void Insert(Incidencia incidencia)
        {
            _dbContext.Incidencias.Add(incidencia);
            _dbContext.SaveChanges();
        }

        /// <sumary>
        /// Método que actualiza una Incidencia
        /// </sumary>
        /// <param name="incidencia">Incidencia a cambiar</param>
        public void Update(Incidencia incidencia)
        {
            Incidencia IncidenciaBD = GetById(incidencia.Id);
            if (IncidenciaBD != null)
            {
                IncidenciaBD.Id = incidencia.Id;
                IncidenciaBD.Equipo = incidencia.Equipo;
                IncidenciaBD.Estado = incidencia.Estado;
                IncidenciaBD.Fecha = incidencia.Fecha;
                IncidenciaBD.UserId = incidencia.UserId;
                IncidenciaBD.Mensajes = incidencia.Mensajes;

                _dbContext.SaveChanges();
            }
            else 
            {
                throw new KeyNotFoundException("No se ha encontrado el registro para actualizar");
            }
        }

        /// <sumary>
        /// Método que elimina una incidencia de la base de datos
        /// </sumary>
        /// <param name="idIncidencia">Identificador de la incidencia</param>
        public void Delete(Guid idIncidencia)
        {
            Incidencia IncidenciaBD = GetById(idIncidencia);
            if (IncidenciaBD != null)
            {
                _dbContext.Incidencias.Remove(IncidenciaBD);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("No se ha encontrado el retistro para eliminar");
            }
        }

        /// <sumary>
        /// Metodo que agrega un mensaje a una incidencia
        /// </sumary>
        /// <param name="idIncidencia">Identificador de la incidencia</param>
        /// <param name="mensaje">Mensaje a agregar</param>
        public void AddMensaje(Guid idIncidencia, Mensaje mensaje)
        {
            Incidencia IncidenciaBD = GetById(idIncidencia);
            if (IncidenciaBD != null)
            {
                _dbContext.Mensajes.Add(mensaje);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("No se ha encontrado la incidencia para añadir mensaje");
            }
        }

        /// <sumary>
        /// Método que obtiene todos los mensajes de una incidencia identificada por id
        /// </sumary>
        /// <param name="idIncidencia">Identificador de la incidencia</param>
        /// <returns>Lista de Mensajes de la incidencia identificada</returns>
        public IQueryable<Mensaje> GetMensajes(Guid idIncidencia)
        {
            return _dbContext.Mensajes.Where(m => m.IncidenciaId == idIncidencia).OrderBy(m => m.Fecha);
        }
    }
}
