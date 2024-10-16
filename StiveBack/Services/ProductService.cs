using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;

namespace StiveBack.Services
{
    public class ProductService
    {
        private MainDbContext _database;

        public ProductService() { }

        public ProductService(MainDbContext mainDbContext)
        {
            _database = mainDbContext;
        }

        /// <summary>
        /// Récupère un objet ProductRessource à partir de l'id de son objet Product
        /// </summary>
        /// <param name="id">Identifiant de l'objet Category</param>
        /// <returns>Objet CategoryRessource correspondant à l'id passé en paramètre</returns>
        public ProductRessource Select(int id)
        {
            Product product = _database.products.FirstOrDefault(c => c.Id == id);
            ProductRessource productRessource = ProductToProductRessource(product);

            return productRessource;
        }

        /// <summary>
        /// Récupère la liste de tous les products de la base de données
        /// </summary>
        /// <returns>Liste des products présents en base de données</returns>
        public List<ProductRessource> SelectAll()
        {
            List<ProductRessource> productRessources = new List<ProductRessource>();
            List<Product> products = _database.products.ToList();
            foreach (Product productItem in products)
            {
                productRessources.Add(ProductToProductRessource(productItem));
            }

            return productRessources;
        }

        /// <summary>
        /// Ajoute le product à la base de données
        /// </summary>
        /// <param name="productRessource">Objet ProductRessource à ajouter à la base de données</param>
        /// <returns>Objet ProductRessource ajoutée en base de données</returns>
        public ProductRessource Add(ProductRessource productRessource)
        {
            var product = ProductRessourceToProduct(productRessource);

            _database.products.Add(product);
            _database.SaveChanges();

            return productRessource;
        }

        /// <summary>
        /// Met à jour le produit dans la base de données
        /// </summary>
        /// <param name="id">Identifiant du produit à mettre à jour</param>
        /// <param name="newCategoryRessource">Objet ProductRessource contenant les informations mises à jour</param>
        /// <returns>Objet ProductRessource mis à jour dans la base de données</returns>
        public ProductRessource Update(int id, ProductRessource newProductRessource)
        {
            Product product = _database.products.FirstOrDefault(c => c.Id == id);
            product.Name = newProductRessource.Name;
            product.Reference = newProductRessource.Reference;
            product.SellPrice = newProductRessource.SellPrice;
            product.SellTva = newProductRessource.SellTva;
            product.Quantity = newProductRessource.Quantity;
            product.MinThreshold = newProductRessource.MinThreshold;
            product.ReorderQuantity = newProductRessource.ReorderQuantity;
            product.BottlingDate = newProductRessource.BottlingDate;
            product.PurchasePrice = newProductRessource.PurchasePrice;
            product.PurchaseTva = newProductRessource.PurchaseTva;
            product.House = newProductRessource.House;
            product.SupplierId = newProductRessource.SupplierId;
            product.ProductCategorie = newProductRessource.ProductCategories;
            //product.ProductCategorie = newProductRessource.ProductCategories.Where(pc => pc.ProductId == ProductCategories.Id).ToList();

            _database.products.Update(product);
            _database.SaveChanges();

            return newProductRessource;
        }

        /// <summary>
        /// Supprime le product de la base de données
        /// </summary>
        /// <param name="id">Identifiant du product à supprimer dans la base de données</param>
        public void Delete(int id)
        {
            Product product = _database.products.FirstOrDefault(c => c.Id == id);
            _database.products.Remove(product);
            _database.SaveChanges();
        }

        /// <summary>
        /// Transforme un objet de type ProductRessource en objet de type Product
        /// </summary>
        /// <param name="productRessource">Objet de type ProductRessource à transformer en objet de type Product</param>
        /// <returns>Objet Product correspondant à l'objet ProductRessource passé en paramètre</returns>
        public Product ProductRessourceToProduct(ProductRessource productRessource)
        {
            var product = new Product
            {
                Name = productRessource.Name,
                Reference = productRessource.Reference,
                SellPrice = productRessource.SellPrice,
                SellTva = productRessource.SellTva,
                Quantity = productRessource.Quantity,
                MinThreshold = productRessource.MinThreshold,
                ReorderQuantity = productRessource.ReorderQuantity,
                BottlingDate = productRessource.BottlingDate,
                PurchasePrice = productRessource.PurchasePrice,
                PurchaseTva = productRessource.PurchaseTva,
                House = productRessource.House,
                ImageName = productRessource.ImageName,
                AutoProvisioning = productRessource.AutoProvisioning,
                Supplier = _database.suppliers.FirstOrDefault(c => c.Id == productRessource.Supplier.Id),
                ProductCategorie = productRessource.ProductCategories,
                //ProductCategorie = _database.productcategories.Where(pc => pc.ProductId == productRessource.Id).ToList(),
                //OrderProduct = _database.orderproducts.Where(op => op.ProductId == productRessource.Id).ToList(),
                //PurchaseOrderProduct = _database.purchaseorderproducts.Where(pop => pop.ProductId == productRessource.Id).ToList(),

            };

            return product;
        }

        /// <summary>
        /// Transforme un objet Product en objet ProductRessource
        /// </summary>
        /// <param name="category">Objet de type Product à transformer en objet de type ProductRessource</param>
        /// <returns>Objet ProductRessource correspondant à l'objet Product passé en paramètre</returns>
        public ProductRessource ProductToProductRessource(Product product)
        {
            var productRessource = new ProductRessource
            {
                Name = product.Name,
                Reference = product.Reference,
                SellPrice = product.SellPrice,
                SellTva = product.SellTva,
                Quantity = product.Quantity,
                MinThreshold = product.MinThreshold,
                ReorderQuantity = product.ReorderQuantity,
                BottlingDate = product.BottlingDate,
                PurchasePrice = product.PurchasePrice,
                House = product.House,
                ImageName = product.ImageName,
                AutoProvisioning = product.AutoProvisioning,
                ProductCategories = _database.productcategories.Where(pc => pc.ProductId == product.Id).ToList(),
                SupplierId = product.SupplierId,
                //OrderProducts = _database.orderproducts.Where(op => op.ProductId == product.Id).ToList(),
                //PurchaseOrderProducts = _database.purchaseorderproducts.Where(pop => pop.ProductId == product.Id).ToList(),
            };

            return productRessource;
        }
    }
}
