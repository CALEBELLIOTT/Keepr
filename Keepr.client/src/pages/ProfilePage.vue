<template>
  <h1>{{ keeps }}</h1>



</template>


<script>
import { computed, onMounted } from "vue"
import { useRoute } from "vue-router"
import { AppState } from "../AppState"
import { keepsService } from "../services/KeepsService"
import { profilesService } from "../services/ProfilesService"

export default {
  setup() {
    let route = useRoute()
    let keeps = computed(() => AppState.profileKeeps)
    let vaults = computed(() => AppState.profileVaults)
    let profile = computed(() => AppState.activeProfile)
    onMounted(async () => {
      await profilesService.getProfileKeeps(route.params.id)
      await profilesService.getProfileVaults(route.params.id)
      await profilesService.getProfile(route.params.id)
    })
    return {
      keeps,
      vaults,
      profile
    }
  }
}
</script>


<style lang="scss" scoped>
</style>
