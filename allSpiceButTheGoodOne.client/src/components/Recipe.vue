<template>
    <div class="row" @click="clicked">
        <div class="col-12">
            <div class="card elevation-2 rounded my-3">
                <div class="row">
                    <div class="col-12">
                        <img :src="recipe?.img" alt="" class="card-img img-fluid recipe-img">
                    </div>
                </div>
                <div class="card-img-overlay row glassy-text shadow">
                    <div class="text-bg col-12">
                        <h4>
                            {{ recipe.category }}
                        </h4>
                    </div>
                    <div class="d-flex align-content-bottom col-12">
                        <h6>
                            {{ recipe.title }}
                        </h6>
                    </div>
                    <div class="d-flex col-12">
                        <p>
                            {{ recipe.instructions }}
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { Recipe } from '../models/Recipe.js';

export default {
    props: { recipe: { type: Recipe, required: true } },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>
.recipe-size {
    height: 15vh;
    width: 100%;
    object-fit: cover;
    // background-position: center;
}

.recipe-img {
    width: 100%;
    height: 30vh;
    object-fit: cover;
}

// .text-bg {
.glassy-text {
    background-color: rgba(175, 170, 170, 0.486);
    border-radius: 5px;
    color: #161414;
    // text-shadow: ;
    line-height: 1.5;
    max-width: 50%;
    padding: 1rem 2rem;
}
</style>