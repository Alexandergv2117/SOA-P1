using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PersonaServicio : IPersona
    {
        private readonly ILogger<PersonaServicio> _logger;
        private readonly PersonaRepositorio personaRepositorio;


        public PersonaServicio(ILogger<PersonaServicio> logger, ApplicationDbContext context)
        {
            _logger = logger;
            personaRepositorio = new PersonaRepositorio(context);
        }

        public List<Persona> ObtenerLista()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                personas = personaRepositorio.ObtenerLista();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return personas;
        }

        public List<EmpleadoVM> ObtenerEmpleados()
        {
            List<EmpleadoVM> empleados = new List<EmpleadoVM>();
             try
            {
                empleados = personaRepositorio.ObtenerEmpleados().Select(x => new EmpleadoVM()
                { Nombre = x.Name, apellidos = x.Lastname,
                    Area = x.Area.Nombre,
                    Email = x.Correo,
                    NumEmpleado = x.NumEmpleado.ToString() }).ToList();
            } catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return empleados;
        }
    }
}
