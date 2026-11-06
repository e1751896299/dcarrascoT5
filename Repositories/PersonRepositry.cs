using dcarrascoT5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace dcarrascoT5.Repositories
{
    public class PersonRepositry
    {
        string _dbPatrh;
        private SQLiteConnection _conn;

        public string StatusMessage { get; set; }

        public PersonRepositry(string path)
        {
            _dbPatrh = path;
        }

        private void Init()
        {
            if (_conn is not null)
                return;
            _conn = new(_dbPatrh);
            _conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");
                Persona persona = new() { Name = name };
                result = _conn.Insert(persona);
                StatusMessage = string.Format("Dato Ingresado");
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error" + ex.Message);
            }
        }

        public List<Persona> GetAllPersona()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error" + ex.Message);
            }
            return new List<Persona>();
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                int result = _conn.Delete<Persona>(id);
                StatusMessage = result > 0
                    ? "Persona eliminada"
                    : "No se encontró la persona";
            }
            catch (Exception ex)
            {
                StatusMessage = "Error: " + ex.Message;
            }
        }


    }
}
