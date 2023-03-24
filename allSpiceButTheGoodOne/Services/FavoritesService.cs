namespace allSpiceButTheGoodOne.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repo.CreateFavorite(favoriteData);
            return favorite;
        }

        internal List<FavoriteRecipe> GetMyFavoriteRecipes(string accountId)
        {
            List<FavoriteRecipe> favoriteRecipes = _repo.GetMyFavoriteRecipes(accountId);
            return favoriteRecipes;
        }

        internal string removeFavorite(int id, string userId)
        {
            Favorite favorite = _repo.GetOne(id);
            if (favorite == null) throw new Exception($"not favorite and {id}");
            if (favorite.AccountId != userId) throw new UnauthorizedAccessException("that's not for you to decide you fracking loser...");
            _repo.RemoveFavorite(id);
            return $"removed your favorite on that recipe!";
        }
    }
}