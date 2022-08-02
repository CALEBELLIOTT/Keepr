<template>
  <div class="container">
    <div class="d-flex justify-content-between">
      <div>
        <h1>{{ vault.name }}</h1>
        <p>Keeps: {{ keeps.length }}</p>
      </div>
      <button class="btn btn-outline-danger mt-3" v-if="account.id == vault.creatorId"
        @click="deleteVault(vault.id)">delete vault</button>
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
import { useRoute, useRouter } from "vue-router"
import { AppState } from "../AppState"
import { vaultKeepsService } from "../services/VaultKeepsService"
import { vaultsService } from "../services/VaultsService"
import Pop from "../utils/Pop"

export default {
  setup() {
    let route = useRoute()
    let keeps = computed(() => AppState.activeVaultKeeps)
    let vault = computed(() => AppState.activeVault)
    let account = computed(() => AppState.account)
    let router = useRouter()
    onMounted(async () => {
      let vault = await vaultsService.getVault(route.params.id)
      if (!vault && vault?.creatorId != account.id) {
        router.push({ name: "Home" })
      }
      await vaultKeepsService.getVaultKeeps(route.params.id)
    })
    return {
      keeps,
      vault,
      account,
      router,
      route,
      async deleteVault(id) {
        if (await Pop.confirm("Are you sure you want to delete the vault?", "This cannot be undone", "warning")
        ) {
          await vaultsService.deleteVault(id)
          router.push({ name: "Profile", params: { id: AppState.account.id } })
          Pop.toast("Vault Deleted", "success")
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
button {
  height: fit-content;
}
</style>
