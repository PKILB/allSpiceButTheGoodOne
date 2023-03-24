namespace allSpiceButTheGoodOne.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            Ingredient ingredient = _repo.CreateIngredient(ingredientData);
            return ingredient;
        }

        internal string DeleteIngredient(int recipeId, Account userInfo)
        {
            Ingredient ingredient = _repo.FindIngredient(recipeId);
            bool result = _repo.deleteIngredient(recipeId);
            return $"You have successfully deleted the {ingredient.Name} ingredient!";
        }

        internal List<Ingredient> FindByRecipe(int recipeId)
        {
            List<Ingredient> ingredients = _repo.FindByRecipe(recipeId);
            return ingredients;
        }
    }
}