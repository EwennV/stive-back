using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;

namespace StiveBack.Services
{
    public class SupplierService
    {
        private MainDbContext _database;

        public SupplierService() { }

        public SupplierService(MainDbContext mainDbContext)
        {
            _database = mainDbContext;
        }

        /// <summary>
        /// Récupère un objet SupplierRessource à partir de l'id de son objet Supplier
        /// </summary>
        /// <param name="id">Identifiant de l'objet Supplier</param>
        /// <returns>Objet SupplierRessource correspondant à l'id passé en paramètre</returns>
        public SupplierRessource Select(int id)
        {
            Supplier? supplier = _database.suppliers.FirstOrDefault(s => s.Id == id);
            SupplierRessource supplierRessource = SupplierToSupplierRessource(supplier);

            return supplierRessource;
        }

        /// <summary>
        /// Récupère la liste de tous les suppliers de la base de données
        /// </summary>
        /// <returns>Liste des suppliers présents en base de données</returns>
        public List<SupplierRessource> SelectAll()
        { 
            List<SupplierRessource> supplierRessources = new List<SupplierRessource>();
            List<Supplier> suppliers = _database.suppliers.ToList();
            foreach (Supplier supplierItem in suppliers)
            {
                supplierRessources.Add(SupplierToSupplierRessource(supplierItem));
            }

            return supplierRessources;
        }

        /// <summary>
        /// Ajoute le supplier à la base de données
        /// </summary>
        /// <param name="categoryRessource">Objet de type SupplierRessource à ajouter à la base de données</param>
        /// <returns>Objet SupplierRessource de Supplier ajouté à la base de données</returns>
        public SupplierRessource Add(SupplierRessource supplierRessource)
        {
            var supplier = SupplierRessourceToSupplier(supplierRessource);

            _database.suppliers.Add(supplier);
            _database.SaveChanges();

            return supplierRessource;
        }

        /// <summary>
        /// Met à jour le supplier dans la base de données
        /// </summary>
        /// <param name="id">Identifiant du supplier à mettre à jour</param>
        /// <param name="newCategoryRessource">Objet SupplierRessource contenant les informations mises à jour</param>
        /// <returns>Objet SupplierRessource du Supplier mis à jour dans la base de données</returns>
        public SupplierUpdateRessource Update(int id, SupplierUpdateRessource newSupplierRessource)
        {
            Supplier? supplier = _database.suppliers.FirstOrDefault(s => s.Id == id);

            if (supplier == null)
            {
                throw new Exception("Supplier not found");
            }

            supplier.Id = id;
            supplier.Name = newSupplierRessource.Name ?? supplier.Name;
            supplier.Siret = newSupplierRessource.Siret ?? supplier.Siret;
            supplier.Address1 = newSupplierRessource.Address1 ?? supplier.Address1;
            supplier.Address2 = newSupplierRessource.Address2 ?? supplier.Address2;
            supplier.PostalCode = newSupplierRessource.PostalCode ?? supplier.PostalCode;
            supplier.City = newSupplierRessource.City ?? supplier.City;
            
            _database.suppliers.Update(supplier);
            _database.SaveChanges();

            return newSupplierRessource;
        }

        /// <summary>
        /// Supprime le supplier de la base de données
        /// </summary>
        /// <param name="id">Identifiant du supplier à supprimer dans la base de données</param>
        public void Delete(int id)
        {
            Supplier? supplier = _database.suppliers.FirstOrDefault(s => s.Id == id);

            if (supplier == null)
            {
                throw new Exception("Supplier not found");
            }

            _database.suppliers.Remove(supplier);
            _database.SaveChanges();
        }

        /// <summary>
        /// Transforme un objet SupplierRessource en objet Supplier
        /// </summary>
        /// <param name="categoryRessource">Objet de type SupplierRessource à trnasformer en objet de type Supplier</param>
        /// <returns>Objet Supplier correspondant à l'objet SupplierRessource passé en paramètre</returns>
        public Supplier SupplierRessourceToSupplier(SupplierRessource supplierRessource)
        {
            var supplier = new Supplier
            {
                Id = supplierRessource.Id,
                Name = supplierRessource.Name,
                Siret = supplierRessource.Siret,
                Address1 = supplierRessource.Address1,
                Address2 = supplierRessource.Address2,
                PostalCode = supplierRessource.PostalCode,
                City = supplierRessource.City,
            };

            return supplier;
        }

        /// <summary>
        /// Transforme un objet Supplier en objet SupplierRessource
        /// </summary>
        /// <param name="category">Objet Supplier à transformer en objet SupplierRessource</param>
        /// <returns>Objet SupplierRessource correspondant à l'objet Supplier passé en paramètre</returns>
        public SupplierRessource SupplierToSupplierRessource(Supplier supplier)
        {
            var supplierRessource = new SupplierRessource
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Siret = supplier.Siret,
                Address1 = supplier.Address1,
                Address2 = supplier.Address2,
                PostalCode = supplier.PostalCode,
                City = supplier.City
            };

            return supplierRessource;
        }
    }
}
