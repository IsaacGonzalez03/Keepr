import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultKeepsService {
  async addVaultKeep(vaultKeep) {
    await api.post('api/vaultkeeps', vaultKeep)
  }

  async getVaultKeep(id) {
    const res = await api.get(`api/vaultKeeps/${id}`)
    AppState.activeVaultKeep = res.data
  }

  // vaultId AS param to get vkeeps after deletion
  async deleteVaultKeep(vaultKeepId) {
    await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    AppState.keeps = AppState.keeps.filter(k => k.id !== vaultKeepId)
    // const res = await api.get(`api/vaults/${vaultId}/keeps`)
    // AppState.keeps = res.data
  }
}
export const vaultKeepsService = new VaultKeepsService()
