const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class ProfilesService {
  async getById(id) {
    const res = await api.get(`api/profiles/${id}`)
    AppState.activeProfile = res.data
  }
}
export const profilesService = new ProfilesService()
