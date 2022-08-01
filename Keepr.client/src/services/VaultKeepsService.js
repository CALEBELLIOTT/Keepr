import { api } from "./AxiosService"

class VaultKeepsService {

  async createVaultKeep(data) {
    const res = await api.post("api/vaultKeeps", data)
    console.log(res.data);
  }
}

export const vaultKeepsService = new VaultKeepsService()