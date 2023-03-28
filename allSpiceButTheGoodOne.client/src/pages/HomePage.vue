<template>
  <div class="container-fluid mt-3">
    <div class="row">
      <div class="col-11 bg-image m-auto rounded">
        <div class="row">
          <div class="col-12 text-light">
            <div class="row m-2">
              <div class="col-12 d-flex justify-content-center align-items-center mt-5">
                <h1>
                  All Spice
                </h1>
              </div>
            </div>
            <div class="row">
              <div class="col-12 d-flex justify-content-center align-items-center">
                <h3>
                  Cherish Your Family And Their Cooking!
                </h3>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="container-fluid text-dark mt-4">
    <div class="row">
      <div v-for="r in recipes" class="col-4">
        <div class="">
          <Recipe :recipe="r" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import { onMounted, computed } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { AppState } from '../AppState.js';
import Recipe from '../components/Recipe.vue';

export default {
  setup() {
    onMounted(() => {
      getRecipes()
    })

    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        logger.error(error)
        Pop.error(error.message)
      }
    }
    return {
      recipes: computed(() => AppState.recipes),
      // account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped lang="scss">
.bg-image {
  height: 35vh;
  background-image: url(https://i0.wp.com/www.faithanddoubt.com/wp-content/uploads/hossein-farahani-pqJ21tErTgI-unsplash-scaled.jpg?ssl=1);
  background-size: cover;
  background-position: center;
}
</style>
