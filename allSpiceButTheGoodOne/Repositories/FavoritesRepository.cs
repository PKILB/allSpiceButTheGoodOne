namespace allSpiceButTheGoodOne.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites
            (recipeId, accountId)
            VALUES
            (@recipeId, @accountId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = id;
            return favoriteData;
        }

        internal List<FavoriteRecipe> GetMyFavoriteRecipes(string accountId)
        {
            string sql = @"
            SELECT
            rec.*,
            favor.*,
            creator.*
            FROM favorites favor
            JOIN recipes rec ON favor.recipeId = rec.id
            JOIN accounts creator ON rec.creatorId = creator.id
            WHERE favor.accountId = @accountId;
            ";
            List<FavoriteRecipe> favoriteRecipes = _db.Query<FavoriteRecipe, Favorite, Profile, FavoriteRecipe>(sql, (favoriteRecipe, favorite, profile) =>
            {
                favoriteRecipe.FavoriteId = favorite.Id;
                favoriteRecipe.Creator = profile;
                return favoriteRecipe;
            }, new { accountId }).ToList();
            return favoriteRecipes;
        }
    }
}