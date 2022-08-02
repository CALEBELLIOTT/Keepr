<template>
  <div class="container">
    <div class="d-flex justify-content-between">
      <div>
        <h1>{{ vault.name }}</h1>
        <p>Keeps: {{ keeps.length }}</p>
      </div>
      <button class="btn btn-outline-danger mt-3" v-if="account.id == vault.creatorId">delete vault</button>
    </div>

    <div class="masonry-frame mt-5">
      <div v-for="k in keeps" :key="k.id">
        <Keep :keep="k" class="my-3"></Keep>
      </div>
    </div>

  </div>



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
    let keeps = computed(() => AppState.activeVaultKeeps)
    let vault = computed(() => AppState.activeVault)
    let account = computed(() => AppState.account)
    onMounted(async () => {
      await vaultKeepsService.getVaultKeeps(route.params.id)
      await vaultsService.getVault(route.params.id)
    })
    return {
      keeps,
      vault,
      account
    }
  }
}
</script>


<style lang="scss" scoped>
button {
  height: fit-content;
}

.masonry-frame {
  columns: 4;

  div {
    break-inside: avoid;
  }
}
</style>
