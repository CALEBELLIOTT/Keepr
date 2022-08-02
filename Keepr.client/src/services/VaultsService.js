import { AppState } from "../AppState"
import { router } from "../router"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"

class VaultsService {
  async createVault(data) {
    try {
      const res = await api.post("api/vaults", data)
      AppState.profileVaults.push(res.data)
      AppState.userVaults.push(res.data)
    } catch (error) {
      console.error(error)
      Pop.toast(error.message, "error")
    }
  }

  async getVault(vaultId) {
    try {
      const res = await api.get("api/vaults/" + vaultId)
      AppState.activeVault = res.data
    } catch (error) {
      console.error(error.response)
      Pop.toast(error.response.data, "error")
      router.push({ name: "Home" })
    }
  }

  async deleteVault(id) {
    try {
      const res = await api.delete("api/vaults/" + id)
      console.log(res.data);
    } catch (error) {
      console.error(error)
      Pop.toast(error.message, "error")
    }
  }


}


export const vaultsService = new VaultsService()