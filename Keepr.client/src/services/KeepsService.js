import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async getKeep(id) {
    AppState.activeKeep = {}
    const res = await api.get(`api/keeps/${id}`)
    AppState.activeKeep = res.data
  }

  async create(keep) {
    const res = await api.post('api/keeps', keep)
    AppState.accountKeeps = res.data
  }

  async update(id, keep) {
    const res = await api.put(`api/keeps/${keep.id}`, keep)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
    AppState.keeps.push(res.data)
  }

  async delete(id) {
    await api.delete(`api/keeps/${id}`)
    AppState.accountKeeps = AppState.accountKeeps.filter(k => k.id !== id)
  }

  async getKeepsByVaultId(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.keeps = res.data
  }

  async getKeepsByAccountId(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    logger.log(res)
    AppState.accountKeeps = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    AppState.keeps = res.data
  }
}

export const keepsService = new KeepsService()
