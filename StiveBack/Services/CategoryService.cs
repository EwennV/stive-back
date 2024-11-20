using StiveBack.Database;
using StiveBack.Models;
using StiveBack.Ressources;

namespace StiveBack.Services
{
    public class CategoryService
    {
        private MainDbContext _database;

        public CategoryService() { }

        public CategoryService(MainDbContext mainDbContext)
        {
            _database = mainDbContext;
        }

        /// <summary>
        /// Récupère un objet CategoryRessource à partir de l'id de son objet Category
        /// </summary>
        /// <param name="id">Identifiant de l'objet Category</param>
        /// <returns>Objet CategoryRessource correspondant à l'id passé en paramètre</returns>
        public CategoryRessource Select(int id)
        {
            Category? category = _database.categories.FirstOrDefault(c => c.Id == id);

            return CategoryToCategoryRessource(category);
        }

        /// <summary>
        /// Récupère la liste de toutes les catégories de la base de données
        /// </summary>
        /// <returns>Liste des catégories présentes en base de données</returns>
        public List<CategoryRessource> SelectAll()
        { 
            List<CategoryRessource> categoryRessources = new List<CategoryRessource>();
            List<Category> categories = _database.categories.ToList();
            foreach (Category categoryItem in categories)
            {
                categoryRessources.Add(CategoryToCategoryRessource(categoryItem));
            }

            return categoryRessources;
        }

        /// <summary>
        /// Ajoute la catégorie à la base de données
        /// </summary>
        /// <param name="categoryRessource">Objet de type CategoryRessource à ajouter à la base de données</param>
        /// <returns>Objet CategoryRessource de la catégorie ajoutée en base de données</returns>
        public CategoryRessource Add(CategorySaveRessource categorySaveRessource)
        {
            Category category = CategorySaveRessourceToCategory(categorySaveRessource);

            _database.categories.Add(category);
            _database.SaveChanges();

            return CategoryToCategoryRessource(category);
        }

        /// <summary>
        /// Met à jour la catégorie dans la base de données
        /// </summary>
        /// <param name="id">Identifiant de la catégorie à mettre à jour</param>
        /// <param name="newCategoryRessource">Objet CategoryRessource contenant les informations mises à jour</param>
        /// <returns>Objet CategoryRessource de la catégorie mise à jour dans la base de données</returns>
<<<<<<< HEAD
        public CategorySaveRessource Update(int id, CategorySaveRessource newCategoryRessource)
=======

        public CategorySaveRessource Update(int id, CategorySaveRessource newCategoryRessource)

>>>>>>> e81f41d8d62e39f78e6a2400ff47e50b401fb2df
        {
            Category? category = _database.categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            int? categParentIdValue = newCategoryRessource.CategoryParentId == 0 ? null : newCategoryRessource.CategoryParentId;

            category.Name = newCategoryRessource.Name ?? category.Name;
            category.CategoryParentId = categParentIdValue;
<<<<<<< HEAD
=======

>>>>>>> e81f41d8d62e39f78e6a2400ff47e50b401fb2df
            
            _database.categories.Update(category);
            _database.SaveChanges();

            return newCategoryRessource;
        }

        /// <summary>
        /// Supprime la catégorie de la base de données
        /// </summary>
        /// <param name="id">Identifiant de la catégorie à supprimer dans la base de données</param>
        public void Delete(int id)
        {
            Category? category = _database.categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            _database.categories.Remove(category);
            _database.SaveChanges();
        }

        /// <summary>
        /// Transforme un objet CategoryRessource en objet Category
        /// </summary>
        /// <param name="categorySaveRessource">Objet de type CategorySaveRessource à transformer en objet de type Category</param>
        /// <returns>Objet Category correspondant à l'objet CategorySaveRessource passé en paramètre</returns>
        public Category CategorySaveRessourceToCategory(CategorySaveRessource categorySaveRessource)
        {
            Category category = new Category
            {
                Name = categorySaveRessource.Name,
                CategoryParentId = categorySaveRessource.CategoryParentId == 0 ? null : categorySaveRessource.CategoryParentId,
            };

            return category;
        }

        /// <summary>
        /// Transforme un objet Category en objet CategoryRessource
        /// </summary>
        /// <param name="category">Objet Category à transformer en objet CategoryRessource</param>
        /// <returns>Objet CategoryRessource correspondant à l'objet Category passé en paramètre</returns>
        public CategoryRessource CategoryToCategoryRessource(Category category)
        {
            
            if (category == null)
            {
                return null;
            }
            
            CategoryRessource categoryRessource = new CategoryRessource
            {
                Id = category.Id,
                Name = category.Name,
            };

            // Récupère l'objet category correspondant à la catégorie parente
            Category parentCategory = _database.categories.FirstOrDefault(parentCategory => parentCategory.Id == category.CategoryParentId);
            if (parentCategory == null)
            {
                categoryRessource.CategoryParent = null;
            }
            else
            {
                categoryRessource.CategoryParent = CategoryToCategoryRessource(parentCategory);
            }

            return categoryRessource;
        }
    }
}
