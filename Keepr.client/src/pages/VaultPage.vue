<template>




</template>


<script>
import { computed, onMounted } from "vue"
import { useRoute } from "vue-router"
import { AppState } from "../AppState"
import { vaultKeepsService } from "../services/VaultKeepsService"
import { vaultsService } from "../services/VaultsService"

export default {
  setup() {
    let route = useRoute()
    onMounted(async () => {
      await vaultKeepsService.getVaultKeeps(route.params.id)
      await vaultsService.getVault(route.params.id)
    })
    return {
      keeps: computed(() => { AppState.activeVaultKeeps }),
      vault: computed(() => AppState.activeVault)
    }
  }
}
</script>


<style lang="scss" scoped>
</style>
