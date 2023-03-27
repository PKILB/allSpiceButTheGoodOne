
export class Recipe {
    constructor(data) {
        this.activeRecipe = data.activeRecipe || null
        this.id = data.id
        this.creatorId = data.creatorId
        this.title = data.title
        this.category = data.category
        this.instructions = data.instructions
        this.img = data.img
    }
}