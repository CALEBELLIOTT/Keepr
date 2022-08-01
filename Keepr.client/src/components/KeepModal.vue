<template>
  <div class="component">


    <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-body p-0">
            <div class="row">
              <div class="col-md-6">
                <img :src="keep.img" class="keep-img img-fluid" alt="">
              </div>
              <div class="col-md-6">
                <div class="d-flex flex-column">
                  <div class="d-flex justify-content-center fs-4 text-primary">
                    <i class="mdi mdi-eye"></i>
                    <p class="ms-1 me-4">{{ keep.views }}</p>
                    <i class="mdi mdi-alpha-k-box-outline"></i>
                    <p class="ms-1 me-4">{{ keep.kept }}</p>
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
    return {
      keep: computed(() => AppState.activeKeep)
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
