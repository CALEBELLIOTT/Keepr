import { AppState } from "../AppState";
import Pop from "../utils/Pop";
import { api } from "./AxiosService"

class ProfilesService {
  async getProfileKeeps(id) {
    try {
      const res = await api.get(`api/profiles/${id}/keeps`)
      if (AppState.account.id === id) {
        AppState.userKeeps = res.data
      }
      AppState.profileKeeps = res.data
    } catch (error) {
      console.log(error);
      Pop.toast(error.message, "error")
    }
  }

  async getProfileVaults(id) {
    try {
      const res = await api.get(`api/profiles/${id}/vaults`)
      AppState.profileVaults = res.data
    } catch (error) {
      console.error(error)
      Pop.toast(error.message)
    }
  }

  async getProfile(id) {
    try {
      const res = await api.get(`api/profiles/${id}`)
      AppState.activeProfile = res.data
    } catch (error) {
      console.error(error)
      Pop.toast(error.message)
    }
  }
}

export const profilesService = new ProfilesService()