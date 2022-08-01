import { AppState } from "../AppState";
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


  async createKeep(data) {
    try {
      const res = await api.post("api/keeps", data)
      AppState.keeps.push(res.data)
      AppState.profileKeeps.push(res.data)
    } catch (error) {
      console.error(error)
      Pop.toast(error.message)
    }
  }


  // TODO put in server requires auth. Need solution
  async incrementViews(id, keep) {
    try {
      const res = await api.put("api/keeps/" + id + "/view", keep)
    } catch (error) {
      console.error(error)
      Pop.toast(error.message, "error")
    }
  }
}

export const keepsService = new KeepsService()