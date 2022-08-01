<template>
  <div class="component">


    <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-xl modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-body p-0">
            <div class="row">
              <div class="col-md-6">
                <img :src="keep.img" class="keep-img img-fluid" alt="">
              </div>
              <div class="col-md-6 position-relative">
                <div
                  class="d-flex flex-column mt-4 justify-content-between position-absolute top-0 bottom-0 end-0 start-0 pe-3">
                  <div class=" d-flex justify-content-center fs-4 text-primary">
                    <i class="mdi mdi-eye"></i>
                    <p class="ms-1 me-4">{{ keep.views }}</p>
                    <i class="mdi mdi-alpha-k-box-outline"></i>
                    <p class="ms-1 me-4">{{ keep.kept }}</p>
                  </div>
                  <div class="d-flex flex-column mb-5">
                    <h2 class="align-self-center my-5">{{ keep.name }}</h2>
                    <p class="mt-3 mx-5">{{ keep.description }}</p>
                    <div class="divider-line"></div>
                  </div>
                  <div class="my-5">
                    <div class="dropdown">
                      <button class="btn btn-outline-primary dropdown-toggle" type="button" id="dropdownMenuButton1"
                        data-bs-toggle="dropdown" aria-expanded="false">
                        Add To Vault
                      </button>
                      <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li v-for="v in userVaults" :key="v.id"><a class="dropdown-item" href="#">Action</a></li>
                        <li v-if="userVaults.length < 1">Create a vault first</li>
                      </ul>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>


  </div>

</template>


<script>
import { computed } from "vue"
import { AppState } from "../AppState"

export default {
  setup() {
    let keep = computed(() => AppState.activeKeep)
    let userVaults = computed(() => AppState.userVaults)
    return {
      keep,
      userVaults
    }
  }
}
</script>


<style lang="scss" scoped>
.keep-img {
  height: 70vh;
  object-fit: cover;
}
</style>
