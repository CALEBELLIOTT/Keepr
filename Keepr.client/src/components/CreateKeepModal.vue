<template>
  <!-- Toggle button that activates both create keep and create vault modal -->
  <!-- TODO separate the dropdown button into its own component -->
  <div class="component">
    <div class="btn-group dropstart">
      <button type="button" class="btn btn-primary dropdown-toggle modal-btn" data-bs-toggle="dropdown"
        aria-expanded="false">
        <h1 class="m-0"><i class="mdi mdi-plus p-0 m-0"></i></h1>
      </button>
      <ul class="dropdown-menu">
        <li><a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#createVaultModal">Create Vault</a></li>
        <li><a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#createKeepModal">Create Keep</a></li>
      </ul>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="createKeepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
import { ref } from "vue"
import { keepsService } from "../services/KeepsService"

export default {
  setup() {
    let keepData = ref({})
    return {
      keepData,
      async createKeep() {
        keepData.value.views = 0
        keepData.value.kept = 0
        await keepsService.createKeep(keepData.value)
        document.getElementById("create-keep-form").reset()
        keepData.value = {}
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.modal-btn {
  position: fixed;
  right: 1.5rem;
  bottom: 1.5rem;
  border-radius: 50%;
}

.dropdown-toggle::before {
  content: none;
}

.dropdown-menu li:hover {
  cursor: pointer;
}
</style>
