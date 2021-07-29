import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  async getById(id) {
    const res = await api.get(`api/vaults/${id}`)
    AppState.activeVault = res.data
  }

  async create(newVault) {
    const res = await api.post('api/vaults', newVault)
    AppState.accountVaults.push(res.data)
  }

  async update(vault) {
    const res = await api.put(`api/vaults/${vault.id}`, vault)
    AppState.vaults = AppState.vaults.filter(v => v.id !== vault.id)
    AppState.vaults.push(res.data)
  }

  async delete(id) {
    await api.put(`api/vaults/${id}`)
    AppState.vaults = AppState.vaults.filter(v => v.id !== id)
  }

  async getVaultsByAccountId(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    logger.log(res)
    AppState.accountVaults = res.data
  }

  async getVaultsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.vaults = res.data
  }
}
export const vaultsService = new VaultsService()
