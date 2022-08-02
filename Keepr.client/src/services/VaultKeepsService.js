import { AppState } from "../AppState";
import Pop from "../utils/Pop";
import { api } from "./AxiosService"
import { keepsService } from "./KeepsService";

class VaultKeepsService {

  async createVaultKeep(data) {

    try {
      const res = await api.post("api/vaultKeeps", data)
      Pop.toast("Keep Successfully Added to Vault!", "success")
    } catch (error) {
      Pop.toast(error.message)
      console.error(error)
    }
  }

  async getVaultKeeps(vaultId) {
    try {
      const res = await api.get(`api/vaults/${vaultId}/keeps`)
      AppState.activeVaultKeeps = res.data
      console.log(AppState.activeVaultKeeps);
    } catch (error) {
      console.error(error)
      Pop.toast(error.message, "error")
    }
  }

  async deleteVaultKeep(id) {
    try {
      const res = await api.delete(`api/vaultkeeps/${id}`)
      AppState.activeVaultKeeps = AppState.activeVaultKeeps.filter(vk => vk.vaultKeepId != id)
      console.log(res.data);
    } catch (error) {
      console.error(error)
      Pop.toast(error.message)
    }
  }
}

export const vaultKeepsService = new VaultKeepsService()