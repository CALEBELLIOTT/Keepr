import Pop from "../utils/Pop";
import { api } from "./AxiosService"

class VaultKeepsService {

  async createVaultKeep(data) {
    const res = await api.post("api/vaultKeeps", data)
    console.log(res.data);
    Pop.toast("Keep Successfully Added to Vault!", "success")
  }
}

export const vaultKeepsService = new VaultKeepsService()