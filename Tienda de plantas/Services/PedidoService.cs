using PlantStore.dbcontext;
using PlantStore.model;

namespace PlantStore.services
{
    public static class PlantaService
    {
        public static void AddPlant(string nombre, decimal precio, int stock, int categoriaId)
        {
            using var db = new TiendaContext();
            db.Plantas.Add(new Planta { Name = nombre, Precio = precio, Stock = stock, CategoriaId = categoriaId });
            db.SaveChanges();
        }

        public static List<Planta> GetPlants()
        {
            using var db = new TiendaContext();
            return db.Plantas.ToList();
        }

        public static Planta? GetPlantById(int id)
        {
            using var db = new TiendaContext();
            return db.Plantas.Find(id);
        }

        public static void UpdatePlant(Planta planta)
        {
            using var db = new TiendaContext();
            db.Plantas.Update(planta);
            db.SaveChanges();
        }

        public static void DeletePlant(int id)
        {
            using var db = new TiendaContext();
            var p = db.Plantas.Find(id);
            if (p != null)
            {
                db.Plantas.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
