namespace allSpiceButTheGoodOne.Services
{
    public class RecipesService
    {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

        internal Recipe GetRecipe(int id, string userId)
        {
            Recipe recipe = _repo.GetOne(id);
            if (recipe == null) throw new Exception("it's not there");
            return recipe;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.CreateRecipe(recipeData);
            return recipe;
        }

        internal List<Recipe> GetRecipes(string userId)
        {
            List<Recipe> recipes = _repo.GetAll();
            return recipes;
        }

        internal Recipe UpdateRecipe(int id, Recipe updateData, Account userInfo)
        {
            Recipe original = this.GetRecipe(id, userInfo.Id);
            if (original.CreatorId != userInfo.Id) throw new Exception("that is not your recipe, I don't know you");

            original.Title = updateData.Title != null ? updateData.Title : original.Title;
            original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
            original.Category = updateData.Category != null ? updateData.Category : original.Category;
            original.Img = updateData.Img != null ? updateData.Img : original.Img;
            int rowsAffected = _repo.UpdateRecipe(original);
            if (rowsAffected == 0) throw new Exception($"could not modify {updateData.Instructions} {updateData.Title} @ id {updateData.Id} for some reason.");
            if (rowsAffected > 1) throw new Exception($"Something horrible just happend, you made at least {rowsAffected} of cars into {updateData.Instructions} {updateData.Title}, might wanna check the db");

            return original;
        }

        internal string RemoveRecipe(int id, Account userInfo)
        {
            Recipe recipe = this.GetRecipe(id, userInfo.Id);
            bool result = _repo.removeRecipe(id);
            if (recipe.CreatorId != userInfo.Id) throw new Exception("You don't own that!");
            // _repo.removeRecipe(recipe);
            return $"You have successfully deleted the {recipe.Title} recipe!";;
        }
    }
}