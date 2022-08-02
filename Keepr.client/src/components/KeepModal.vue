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
                  <div class="my-5 d-flex justify-content-between align-items-center">
                    <button class="btn btn-outline-danger" v-if="route.name == 'Vault' && checkVault()"
                      @click="deleteVaultKeep(keep.vaultKeepId)" data-bs-toggle="modal"
                      data-bs-target="#keepModal">Remove From Vault</button>
                    <div class="dropdown" v-if="route.name != 'Vault' && account.id">
                      <button class="btn btn-outline-primary dropdown-toggle" type="button" id="dropdownMenuButton1"
                        data-bs-toggle="dropdown" aria-expanded="false">
                        Add To Vault
                      </button>
                      <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li v-for="v in userVaults" :key="v.id"><a class="dropdown-item" href="#"
                            @click="createVaultKeep(keep.id, v.id, keep)">{{ v.name }}</a></li>
                        <li v-if="userVaults.length < 1">Create a vault first</li>
                      </ul>
                    </div>
                    <h2 v-if="keep.creator?.id == account.id" @click="deleteKeep(keep.id)"><i
                        class="mdi mdi-trash-can-outline text-primary cursor-pointer"></i>
                    </h2>
                    <div class="bg-dark rounded m-2 p-2 d-flex align-items-center profile"
                      @click="goToProfilePage(keep.creator?.id)" data-bs-toggle="modal" data-bs-target="#keepModal">
                      <img class="profile-img" :src="keep.creator?.picture" alt="">
                      <p class="mx-2 my-0">{{ keep.creator?.name }}</p>
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
import { useRoute, useRouter } from "vue-router"
import { AppState } from "../AppState"
import { vaultKeepsService } from "../services/VaultKeepsService"
import { keepsService } from "../services/KeepsService"
import Pop from "../utils/Pop"

export default {
  setup() {
    let keep = computed(() => AppState.activeKeep)
    let userVaults = computed(() => AppState.userVaults)
    let router = useRouter();
    let route = useRoute();
    let account = computed(() => AppState.account)
    return {
      keep,
      userVaults,
      route,
      account,
      async createVaultKeep(keepId, vaultId, keep) {
        let data = { keepId, vaultId }
        await vaultKeepsService.createVaultKeep(data)
        await keepsService.incrementKeeps(keepId, keep)
      },
      goToProfilePage(id) {
        router.push({ name: "Profile", params: { id } })
        console.log(route.name);
      },
      async deleteVaultKeep(id) {
        if (await Pop.confirm("are you sure you want to remove this keep?")) {
          await vaultKeepsService.deleteVaultKeep(id)
        }
      },
      async deleteKeep(id) {
        if (await Pop.confirm("are you sure you want to delete the keep?", "This cannot be undone", "warning")
        ) {
          await keepsService.deleteKeep(id)
        }
      },

      checkVault() {
        if (AppState.activeVault.creatorId == AppState.account.id) {
          return true
        }
      }







    }
  }
}

</script>


<style lang="scss" scoped>
.keep-img {
  height: 70vh;
  object-fit: cover;
}

.profile-img {
  height: 3rem;
  border-radius: 50%;
}

.profile:hover {
  cursor: pointer;
  transform: scale(1.02);
  transition: 400ms;
}

.profile {
  transition: 400ms;
}
</style>
