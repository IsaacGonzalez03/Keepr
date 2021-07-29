import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfilesService {
  async getById(id) {
    const res = await api.get(`api/profiles/${id}`)
    logger.log(res)
    AppState.activeProfile = res.data
  }
}
export const profilesService = new ProfilesService()
