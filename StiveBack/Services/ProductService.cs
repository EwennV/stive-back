using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;

namespace StiveBack.Services
{
    public class ProductService
    {
        private MainDbContext _database;
        private readonly SupplierService _supplierService;
        private readonly CategoryService _categoryService;

        public ProductService(SupplierService SupplierService, CategoryService CategoryService)
        {
            _supplierService = SupplierService;
            _categoryService = CategoryService;
        }

        public ProductService(MainDbContext mainDbContext, SupplierService SupplierService, CategoryService CategoryService)
        {
            _database = mainDbContext;
            _supplierService = SupplierService;
            _categoryService = CategoryService;
        }

        /// <summary>
        /// Récupère un objet ProductRessource à partir de l'id de son objet Product
        /// </summary>
        /// <param name="id">Identifiant de l'objet Category</param>
        /// <returns>Objet CategoryRessource correspondant à l'id passé en paramètre</returns>
        public ProductRessource Select(int id)
        {
            Product product = _database.products.Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }
            else
            {
                return ProductToProductRessource(product);
            }
        }

        /// <summary>
        /// Récupère la liste de tous les products de la base de données
        /// </summary>
        /// <returns>Liste des products présents en base de données</returns>
        public List<ProductRessource> SelectAll()
        {
            List<ProductRessource> allProductRessources = new List<ProductRessource>();
            List<Product> allProducts = _database.products.Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).ToList();
            if (allProducts.Count == 0)
            {
                return null;
            }
            foreach (Product product in allProducts)
            {
                allProductRessources.Add(ProductToProductRessource(product));
            }
            return allProductRessources;
        }

        /// <summary>
        /// Ajoute le product à la base de données
        /// </summary>
        /// <param name="productSaveRessource">Objet ProductRessource à ajouter à la base de données</param>
        /// <returns>Objet ProductRessource ajoutée en base de données</returns>
        public ProductRessource Add(ProductSaveRessource productSaveRessource)
        {
            Product product = ProductSaveRessourceToProduct(productSaveRessource);

            _database.products.Add(product);
            _database.SaveChanges();

            return Select(product.Id);
        }

        /// <summary>
        /// Met à jour le produit dans la base de données
        /// </summary>
        /// <param name="id">Identifiant du produit à mettre à jour</param>
        /// <param name="newCategoryRessource">Objet ProductRessource contenant les informations mises à jour</param>
        /// <returns>Objet ProductRessource mis à jour dans la base de données</returns>
        public ProductRessource Update(int id, ProductSaveRessource productSaveRessource)
        {
            Product product = _database.products.Include(p => p.ProductCategories).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }

            product.Name = productSaveRessource.Name;
            product.Reference = productSaveRessource.Reference;
            product.SellPrice = productSaveRessource.SellPrice;
            product.SellTva = productSaveRessource.SellTva;
            product.Quantity = productSaveRessource.Quantity;
            product.MinThreshold = productSaveRessource.MinThreshold;
            product.ReorderQuantity = productSaveRessource.ReorderQuantity;
            product.BottlingDate = productSaveRessource.BottlingDate;
            product.PurchasePrice = productSaveRessource.PurchasePrice;
            product.PurchaseTva = productSaveRessource.PurchaseTva;
            product.House = productSaveRessource.House;
            product.SupplierId = productSaveRessource.SupplierId;
            product.ProductCategories.Clear();

            foreach (var categoryId in productSaveRessource.CategoryIds)
            {
                product.ProductCategories.Add(new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = categoryId
                });
            }

            _database.products.Update(product);
            _database.SaveChanges();

            return Select(product.Id);
        }

        /// <summary>
        /// Supprime le product de la base de données
        /// </summary>
        /// <param name="id">Identifiant du product à supprimer dans la base de données</param>
        public void Delete(int id)
        {
            Product product = _database.products.FirstOrDefault(p => p.Id == id);
          
            _database.products.Remove(product);
            _database.SaveChanges();
        }

        /// <summary>
        /// Transforme un objet de type ProductSaveRessource en objet de type Product
        /// </summary>
        /// <param name="productSaveRessource">Objet de type ProductSaveRessource à transformer en objet de type Product</param>
        /// <returns>Objet Product correspondant à l'objet ProductSaveRessource passé en paramètre</returns>
        public Product ProductSaveRessourceToProduct(ProductSaveRessource productSaveRessource)
        {
            
            if (productSaveRessource == null)
            {
                return null;
            }
            
            var product = new Product
            {
                Name = productSaveRessource.Name,
                Reference = productSaveRessource.Reference,
                SellPrice = productSaveRessource.SellPrice,
                SellTva = productSaveRessource.SellTva,
                Quantity = productSaveRessource.Quantity,
                MinThreshold = productSaveRessource.MinThreshold,
                ReorderQuantity = productSaveRessource.ReorderQuantity,
                BottlingDate = productSaveRessource.BottlingDate,
                PurchasePrice = productSaveRessource.PurchasePrice,
                PurchaseTva = productSaveRessource.PurchaseTva,
                House = productSaveRessource.House,
                ImageName = productSaveRessource.ImageName,
                AutoProvisioning = productSaveRessource.AutoProvisioning,
                SupplierId = productSaveRessource.SupplierId,
                ProductCategories = productSaveRessource.CategoryIds.Select(categoryId => new ProductCategory
                {
                    CategoryId = categoryId
                }).ToList(),
            };

            return product;
        }

        /// <summary>
        /// Transforme un objet Product en objet ProductRessource
        /// </summary>
        /// <param name="product">Objet de type Product à transformer en objet de type ProductRessource</param>
        /// <returns>Objet ProductRessource correspondant à l'objet Product passé en paramètre</returns>
        public ProductRessource ProductToProductRessource(Product product)
        {
            
            if (product == null)
            {
                return null;
            }

            ProductRessource productRessource = new ProductRessource
            {
                Id = product.Id,
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
                Categories = product.ProductCategories
            .Where(pc => pc.Category != null)
            .Select(pc => new CategoryRessource
            {
                Id = pc.Category.Id,
                Name = pc.Category.Name,
            }).ToList(),
                Supplier = _supplierService.Select(product.SupplierId),
            };

            return productRessource;
        }
    }
}
