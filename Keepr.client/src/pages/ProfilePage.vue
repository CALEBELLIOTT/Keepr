<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <div class="mt-3 d-flex">
          <img class="profile-img" :src="profile.picture" alt="">
          <div class="d-flex flex-column mx-2">
            <h3>{{ profile.name }}</h3>
            <p>Keeps: {{ keeps.length }}</p>
            <p>Vaults: {{ vaults.length }}</p>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <h3 class="mt-4">Vaults<span class="text-primary"><i class="mdi mdi-plus"></i></span></h3>
      </div>
      <div class="vault-row d-flex">
        <div class="mx-2" v-for="v in vaults" :key="v.id">
          <div :style="`background-image: url(${v.img});`" class="text-light vault-container m-0 p-2 position-relative"
            @click="navToVaultPage(v.id)">
            <div class="d-flex align-items-end position-absolute top-0 bottom-0">
              <h3>{{ v.name }}</h3>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="mt-4">
          <h3>Keeps<span class="text-primary"><i class="mdi mdi-plus"></i></span></h3>
        </div>
      </div>
      <div class="masonry-frame">
        <Keep class="my-2" v-for="k in keeps" :key="k.id" :keep="k"></Keep>
      </div>
    </div>
  </div>


  <CreateVaultsAndKeeps v-if="account.id == route.params.id"></CreateVaultsAndKeeps>
</template>


<script>
import { computed, onMounted } from "vue"
import { useRoute, useRouter } from "vue-router"
import { AppState } from "../AppState"
import { profilesService } from "../services/ProfilesService"
import Keep from "../components/Keep.vue"

export default {
  setup() {
    let route = useRoute();
    let router = useRouter();
    let keeps = computed(() => AppState.profileKeeps);
    let vaults = computed(() => AppState.profileVaults);
    let profile = computed(() => AppState.activeProfile);
    let account = computed(() => AppState.account);
    onMounted(async () => {
      await profilesService.getProfileKeeps(route.params.id);
      await profilesService.getProfileVaults(route.params.id);
      await profilesService.getProfile(route.params.id);
    });
    return {
      route,
      keeps,
      vaults,
      profile,
      account,
      router,
      navToVaultPage(id) {
        router.push({ name: "Vault", params: { id } });
      }
    };
  },
  components: { Keep }
}
</script>


<style lang="scss" scoped>
.profile-img {
  height: 7rem;
  width: 7rem;
  border-radius: 3px;
  object-fit: contain;
}

.vault-container {
  height: 15rem;
  width: 15rem;
  background-size: cover;
  border-radius: 4px;
  transition: 400ms;
}

.vault-container:hover {
  cursor: pointer;
  transform: scale(1.01);
  transition: 400ms;
}

.vault-container h3 {
  text-shadow: 1px 1px rgba(57, 56, 56, 0.868);
}

.vault-row {
  overflow-x: scroll;
}
</style>
