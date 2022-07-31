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
}

export const keepsService = new KeepsService()