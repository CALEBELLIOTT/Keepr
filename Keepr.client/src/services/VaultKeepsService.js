import Pop from "../utils/Pop";
import { api } from "./AxiosService"
import { keepsService } from "./KeepsService";

class VaultKeepsService {

  async createVaultKeep(data) {

    try {
      const res = await api.post("api/vaultKeeps", data)
      await keepsService.incrementKeeps(data)
      console.log(res.data);
      Pop.toast("Keep Successfully Added to Vault!", "success")
    } catch (error) {
      Pop.toast(error.message)
      console.error(error)
    }
  }
}

export const vaultKeepsService = new VaultKeepsService()