<template>
  <h1>{{ route.params.id }}</h1>



</template>


<script>
import { useRoute } from "vue-router"

export default {
  setup() {
    let route = useRoute()
    return {
      route
    }
  }
}
</script>


<style lang="scss" scoped>
</style>
