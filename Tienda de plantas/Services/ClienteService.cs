using PlantStore.dbcontext;
using PlantStore.model;
using Microsoft.EntityFrameworkCore;

namespace PlantStore.services
{
    public static class ClienteService
    {
        public static void AddClient(string name, string email, string telefono)
        {
            using var db = new TiendaContext();
            var cliente = new Cliente
            {
                Name = name,
                Email = email,
                Telefono = telefono
            };
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }

        public static List<Cliente> GetClients()
        {
            using var db = new TiendaContext();
            return db.Clientes.ToList();
        }

        public static Cliente? GetClientById(int id)
        {
            using var db = new TiendaContext();
            return db.Clientes
                     .FirstOrDefault(c => c.Id == id);
        }

        public static void UpdateClient(Cliente cliente)
        {
            using var db = new TiendaContext();
            db.Clientes.Update(cliente);
            db.SaveChanges();
        }

        public static void DeleteClient(int id)
        {
            using var db = new TiendaContext();
            var cliente = db.Clientes.Find(id);
            if (cliente != null)
            {
                db.Clientes.Remove(cliente);
                db.SaveChanges();
            }
        }
    }
}
