using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Security.Cryptography;
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
            
            lista = _context.Personas.ToList(); 

            return lista;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> list = new List<Empleado>();

            list = _context.Empleados.Include(x => x.Area).ToList();

            return list;
        }

        public bool validCredentials(string  email, string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                string passEncrypted = BitConverter.ToString(bytes).Replace("-", "").ToLower();

                bool isValid = _context.Empleados.Any(e => e.Correo == email && e.password == passEncrypted);
                return isValid;
            }
        }
    }
}
