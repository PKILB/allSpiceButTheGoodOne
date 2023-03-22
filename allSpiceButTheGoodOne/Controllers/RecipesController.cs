namespace allSpiceButTheGoodOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth;

        public RecipesController(RecipesService recipesService, Auth0Provider auth)
        {
            _recipesService = recipesService;
            _auth = auth;
        }

    [HttpGet]
    async public Task<ActionResult<List<Recipe>>> FindRecipe()
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            List<Recipe> recipes = _recipesService.GetRecipes(userInfo?.Id);
            return Ok(recipes);
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Authorize]

    async public Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = _recipesService.CreateRecipe(recipeData);
            recipe.Creator = userInfo;
            return Ok(recipe);
        }
        catch (System.Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    }
    
}