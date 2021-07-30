import { AppState } from '../AppState'
import { router } from '../router'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  // hits b-e but be will deny the request because the b-e is set up to not return data
  async getById(id) {
    try {
      const res = await api.get(`api/vaults/${id}`)
      AppState.activeVault = res.data
    } catch (error) {
      router.push({ name: 'Home' })
    }
    // const vault = res.data
    // logger.log(vault)
    // if (vault.isPrivate === true && vault.creator.id !== AppState.accountId) {
    //   router.push({ name: 'Home' })
    // } else {
    // authSettled()
    // }
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
    await api.delete(`api/vaults/${id}`)
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
