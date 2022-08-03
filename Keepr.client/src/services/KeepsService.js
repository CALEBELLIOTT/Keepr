import { useRoute } from "vue-router";
import { AppState } from "../AppState";
import { router } from "../router";
import Pop from "../utils/Pop";
import { api } from "./AxiosService"

class KeepsService {
  async getAllKeeps() {
    try {
      const res = await api.get("api/keeps");
      AppState.keeps = res.data
    } catch (error) {
      console.log(error);
      Pop.toast(error.message, "error")
    }
  }


  async createKeep(data, route) {
    try {
      const res = await api.post("api/keeps", data)
      AppState.keeps.push(res.data)
      AppState.userKeeps.push(res.data)
      // AppState.profileKeeps.push(res.data)
    } catch (error) {
      console.error(error)
      Pop.toast(error.message)
    }
  }


  async incrementViews(id, keep) {
    try {
      const res = await api.put("api/keeps/" + id + "/view", keep)
    } catch (error) {
      console.error(error)
      Pop.toast(error.message, "error")
    }
  }

  async incrementKeeps(keepId, keep) {
    try {
      keep.kept += 1
      const res = await api.put("api/keeps/" + keepId + "/keep", keep)
    } catch (error) {
      console.error(error)
      Pop.toast(error.message, "error")
    }
  }

  async deleteKeep(id) {
    try {
      const res = await api.delete("api/keeps/" + id)
      AppState.keeps = AppState.keeps.filter(k => k.id != id)
      AppState.profileKeeps = AppState.profileKeeps.filter(k => k.id != id)
      AppState.userKeeps = AppState.userKeeps.filter(k => k.id != id)
      Pop.toast("keep deleted!", "success")
    } catch (error) {
      console.error(error)
      Pop.toast(error.message, "error")
    }
  }
}

export const keepsService = new KeepsService()