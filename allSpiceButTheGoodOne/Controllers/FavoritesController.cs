namespace allSpiceButTheGoodOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;

        private readonly Auth0Provider _auth;

        public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
        {
            _favoritesService = favoritesService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                favoriteData.AccountId = userInfo.Id;
                Favorite favorite = _favoritesService.CreateFavorite(favoriteData);
                return Ok(favorite);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}