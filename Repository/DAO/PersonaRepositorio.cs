using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class PersonaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Persona> ObtenerLista()
        {
            List<Persona> lista = new List<Persona>();
            //DateTime Fecha = new DateTime(1998, 01, 15);
            //lista.Add(new Persona() {Id = 1, Name = "Jonathan", Lastname ="Valdes" , CURP = "VASJ980125HQRLNN00", RFC = "VASJ980125PU9", FechaNacimiento= Fecha });
            //lista.Add(new Persona() { Id = 2, Name = "Eduardo", Lastname = "Pastelin", CURP = "VASJ980125HQRLNN00", RFC = "VASJ980125PU9", FechaNacimiento = Fecha });
            //lista.Add(new Persona() { Id = 3, Name = "Sofia", Lastname = "Carolina", CURP = "VASJ980125HQRLNN00", RFC = "VASJ980125PU9", FechaNacimiento = Fecha });
            //lista.Add(new Persona() { Id = 4, Name = "Yair", Lastname = "Casas", CURP = "VASJ980125HQRLNN00", RFC = "VASJ980125PU9", FechaNacimiento = Fecha });
            
            lista = _context.Personas.ToList(); 

            return lista;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> list = new List<Empleado>();

            list = _context.Empleados.Include(x => x.Area).ToList();

            return list;
        }
    }
}
