using Microsoft.EntityFrameworkCore;
using PlantStore.dbcontext;
using PlantStore.model;

namespace PlantStore.services
{
    public static class CategoriaService
    {
        public static void AddCategory(string name)
        {
            using var db = new TiendaContext();
            var categoria = new Categoria
            {
                Name = name,
                Plantas = new List<Planta>() // inicializamos la lista para evitar null
            };
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        public static List<Categoria> GetCategories()
        {
            using var db = new TiendaContext();
            return db.Categorias
                     .Include(c => c.Plantas) // incluimos las plantas relacionadas
                     .ToList();
        }

        public static Categoria? GetCategoryById(int id)
        {
            using var db = new TiendaContext();
            return db.Categorias
                     .Include(c => c.Plantas) // incluimos las plantas relacionadas
                     .FirstOrDefault(c => c.Id == id);
        }

        public static void UpdateCategory(Categoria categoria)
        {
            using var db = new TiendaContext();
            db.Categorias.Update(categoria);
            db.SaveChanges();
        }

        public static void DeleteCategory(int id)
        {
            using var db = new TiendaContext();
            var categoria = db.Categorias
                              .Include(c => c.Plantas)
                              .FirstOrDefault(c => c.Id == id);

            if (categoria != null)
            {
                db.Categorias.Remove(categoria);
                db.SaveChanges();
            }
        }
    }
}
