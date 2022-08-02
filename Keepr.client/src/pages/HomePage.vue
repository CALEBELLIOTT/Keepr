<template>
  <div class="container">

    <div class="masonry-frame mt-2">
      <div v-for="k in keeps" :key="k.id" class="">
        <Keep :keep="k" class="my-2"></Keep>
      </div>
    </div>

  </div>



  <CreateVaultsAndKeeps />
</template>

<script>
import { computed } from "vue"
import { AppState } from "../AppState"

export default {
  setup() {
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}

</script>

<style scoped lang="scss">
// .masonry-frame {
//   columns: 4;

//   div {
//     break-inside: avoid;
//   }
// }
</style>
