namespace allSpiceButTheGoodOne.Services
{
    public class RecipesService
    {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

        internal static Recipe Find(int id)
        {
            throw new NotImplementedException();
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
    }
}