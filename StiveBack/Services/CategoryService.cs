﻿using StiveBack.Database;
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
            Category category = _database.categories.FirstOrDefault(c => c.Id == id);
            CategoryRessource categoryRessource = CategoryToCategoryRessource(category);

            return categoryRessource;
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
        /// <param name="categoryRessource"></param>
        /// <returns>Objet CategoryRessource de la catégorie ajoutée en base de données</returns>
        public CategoryRessource Add(CategoryRessource categoryRessource)
        {
            var category = CategoryRessourceToCategory(categoryRessource);

            _database.categories.Add(category);
            _database.SaveChanges();

            return categoryRessource;
        }

        /// <summary>
        /// Met à jour la catégorie dans la base de données
        /// </summary>
        /// <param name="id">Identifiant de la catégorie à mettre à jour</param>
        /// <param name="newCategoryRessource">Objet CategoryRessource contenant les informations mises à jour</param>
        /// <returns>Objet CategoryRessource de la catégorie mise à jour dans la base de données</returns>
        public CategoryRessource Update(int id, CategoryRessource newCategoryRessource)
        {
            Category category = _database.categories.FirstOrDefault(c => c.Id == id);
            category.Name = newCategoryRessource.Name;
            category.CategoryParentId = newCategoryRessource.CategoryRessourceParentId;
            
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
            Category category = _database.categories.FirstOrDefault(c => c.Id == id);
            _database.categories.Remove(category);
            _database.SaveChanges();
        }

        /// <summary>
        /// Transforme un objet CategoryRessource en objet Category
        /// </summary>
        /// <param name="categoryRessource"></param>
        /// <returns>Objet Category correspondant à l'objet CategoryRessource passé en paramètre</returns>
        public Category CategoryRessourceToCategory(CategoryRessource categoryRessource)
        {
            var category = new Category
            {
                Name = categoryRessource.Name,
                CategoryParentId = categoryRessource.CategoryRessourceParentId,
            };

            return category;
        }

        /// <summary>
        /// Transforme un objet Category en objet CategoryRessource
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Objet CategoryRessource correspondant à l'objet Category passé en paramètre</returns>
        public CategoryRessource CategoryToCategoryRessource(Category category)
        {
            var categoryRessource = new CategoryRessource
            {
                Name = category.Name,
                CategoryRessourceParentId = category.CategoryParentId
            };

            return categoryRessource;
        }
    }
}
