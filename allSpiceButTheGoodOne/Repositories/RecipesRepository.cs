namespace allSpiceButTheGoodOne.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (creatorId, title, category, img, instructions)
            VALUES
            (@creatorId, @title, @category, @img, @instructions);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }

        internal List<Recipe> GetAll()
        {
            string sql = @"
            SELECT
            rec.*,
            acct.*
            FROM recipes rec
            JOIN accounts acct ON rec.creatorId = acct.id;
            ";
            List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, prof) =>
            {
                recipe.Creator = prof;
                return recipe;
            }).ToList();
            return recipes;
        }

        internal Recipe GetOne(int id)
        {
            string sql = @"
            SELECT 
            rec.*,
            acct.*
            FROM recipes rec
            JOIN accounts acct ON rec.creatorId = acct.id
            WHERE rec.id = @id;
            ";
            Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, prof) =>
            {
                recipe.Creator = prof;
                return recipe;
            }, new { id }).FirstOrDefault();
            return recipe;
        }

        internal int UpdateRecipe(Recipe update)
        {
            string sql = @"
            UPDATE recipes
            SET
            title = @title,
            instructions = @instructions,
            category = @category,
            img = @img
            WHERE recipes.id = @id 
            ";
            int rows = _db.Execute(sql, update);
            return rows;
        }
    }
}