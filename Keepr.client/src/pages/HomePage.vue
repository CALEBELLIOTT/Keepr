<template>
  <div class="masonry-frame">
    <div v-for="k in keeps" :key="k.id" class="p-2">
      <Keep :keep="k"></Keep>
    </div>
  </div>




  <CreateKeepModal />
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
.masonry-frame {
  columns: 4;

  div {
    break-inside: avoid;
  }
}
</style>
