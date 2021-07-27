import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    logger.log('keeps', res.data)
    AppState.keeps = res.data
  }
}

export const keepsService = new KeepsService()