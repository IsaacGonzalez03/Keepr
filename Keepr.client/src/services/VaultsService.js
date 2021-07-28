const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class VaultsService {
  async getById(id) {
    const res = await api.get(`api/vaults/${id}`)
    AppState.activeVault = res.data
  }

  async create(newVault) {
    const res = await api.post('api/vaults', newVault)
    AppState.vaults = [res.data, ...AppState.vaults]
  }

  async update(vault) {
    await api.put(`api/vaults/${vault.id}`, vault)
  }

  async delete(id) {
    await api.put(`api/vaults/${id}`)
  }

  async getVaultsByAccountId(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.accountVaults = res.data
  }

  async getVaultsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.vaults = res.data
  }
}
export const vaultsService = new VaultsService()
