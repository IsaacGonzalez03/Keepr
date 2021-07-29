import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultKeepsService {
  async addVaultKeep(vaultKeep) {
    const res = await api.post('api/vaultkeeps', vaultKeep)
    AppState.activeVaultKeep.push(res.data)
  }

  async getVaultKeep(id) {
    const res = await api.get(`api/vaultKeeps/${id}`)
    AppState.activeVaultKeep = res.data
  }

  async deleteVaultKeep(vaultKeepId) {
    await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    AppState.keeps = AppState.keeps.filter(k => k.id !== vaultKeepId)
  }
}
export const vaultKeepsService = new VaultKeepsService()
