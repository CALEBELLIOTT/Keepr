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
}

export const profilesService = new ProfilesService()