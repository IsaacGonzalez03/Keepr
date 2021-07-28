import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async getKeep(id) {
    const res = await api.get(`api/keeps/${id}`)
    AppState.activeKeep = res.data
  }

  async create(keep) {
    await api.post('api/keeps', keep)
  }

  async update(keep) {
    await api.put(`api/keeps/${keep.id}`, keep)
  }

  async delete(id) {
    await api.delete(`api/keeps/${id}`)
  }

  async deleteVaultKeep(vaultKeepId) {
    await api.delete(`api/vaultkeeps/${vaultKeepId}`)
  }

  async addVaultKeep(vaultKeep) {
    await api.post('api/vaultkeeps', vaultKeep)
  }

  async getVaultKeep(id) {
    const res = await api.get(`api/vaultKeeps/${id}`)
    AppState.activeVaultKeep = res.data
  }

  async getKeepsByVaultId(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.keeps = res.data
  }

  async getKeepsByAccountId(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    AppState.accountKeeps = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    AppState.keeps = res.data
  }
}

export const keepsService = new KeepsService()
