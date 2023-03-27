import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";



class RecipesService {

    async getRecipes() {
        const res = await api.get('api/recipes')
        logger.log('[Got Recipes]', res.data)
        AppState.recipes = res.data
    }
}

export const recipesService = new RecipesService();