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

  <div class="container-fluid text-dark">
    <section class="row">
      <div class="col-12">
        <!-- {{ recipes.instructions }} -->
      </div>
    </section>
  </div>
</template>

<script>
import { onMounted, computed } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js';
import { AppState } from '../AppState.js';

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
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped lang="scss">
.bg-image {
  height: 30vh;
  background-image: url(https://images.unsplash.com/photo-1542826438-bd32f43d626f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTV8fGNha2V8ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60);
  background-size: cover;
  background-position: center;
}
</style>
