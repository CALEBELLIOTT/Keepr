import { AppState } from "../AppState"
import { api } from "./AxiosService"

class VaultsService {
  async createVault(data) {
    const res = await api.post("api/vaults", data)
    AppState.profileVaults.push(res.data)
    AppState.userVaults.push(res.data)
  }


}


export const vaultsService = new VaultsService()