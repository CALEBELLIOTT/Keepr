<template>
  <div class="component">
    <!-- Button to activate this modal is in the create keep modal component -->
    <div class="modal fade" id="createVaultModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-body">
            <div class="d-flex flex-column">
              <h3>Create a New Keep</h3>
              <form action="" @submit.prevent="createKeep()" id="create-keep-form">
                <label for="">Title</label>
                <input type="text" class="form-control" placeholder="title..." v-model="keepData.name">
                <label for="" class="mt-2">Img Url</label>
                <input type="text" class="form-control" placeholder="image url..." v-model="keepData.img">
                <label for="" class="mt-2">Description</label>
                <textarea name="" id="" cols="30" rows="6" placeholder="description..." class="form-control"
                  v-model="keepData.description"></textarea>
                <div class="d-flex justify-content-end mt-4">
                  <button class="btn btn-primary">submit</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
</style>
