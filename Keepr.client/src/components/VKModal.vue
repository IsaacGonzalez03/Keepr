<template>
  <div class="modal fade" id="Modal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <div class="col-sm-6 p-0 d-flex justify-content-center">
                <img :src="state.activeKeep.img" class="img-fluid img-size rounded" alt="">
              </div>
              <div class="col-sm-6 p-1">
                <div class="d-flex justify-content-around user-select-none">
                  <small><i class="far fa-eye"></i> {{ state.activeKeep.views }}</small><small><i class="far fa-save"></i> {{ state.activeKeep.keeps }}</small><small><i class="fas fa-share-alt"></i> {{ state.activeKeep.shares }}</small>
                </div>
                <hr>
                <h2 class="text-center">
                  {{ state.activeKeep.name }}
                </h2>
                <p>{{ state.activeKeep.description }}</p>
                <hr>
                <div class="row">
                  <div class="col-4 text-center">
                    <i data-dismiss="modal" class="far fa-trash-alt text-danger" @click="deleteKeep" v-if="state.account.id === state.activeKeep.creatorId"></i>
                  </div>
                  <div class="col-4 text-wrap">
                    <div v-if="state.activeKeep.creator">
                      <router-link :to="{name:'ProfilePage', params:{id: state.activeKeep.creatorId}}" data-dismiss="modal">
                        <img :src="state.activeKeep.creator.picture" alt="creator pic" class="user-pic" v-if="state.activeKeep.creator">
                        <p class="mt-2 p-0 text-decoration-none">
                          {{ state.activeKeep.creator.name }}
                        </p>
                      </router-link>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { profilesService } from '../services/ProfilesService'
import { vaultKeepsService } from '../services/VaultKeepsService'
import Pop from '../utils/Notifier'
import { logger } from '../utils/Logger'
export default {
  name: 'Modal',
  setup() {
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      activeProfile: computed(() => AppState.activeProfile),
      accountVaults: computed(() => AppState.accountVaults),
      newVaultKeep: {},
      activeVaultKeep: computed(() => AppState.activeVaultKeep)
    })
    return {
      state,
      async addVaultKeep() {
        try {
          state.newVaultKeep.keepId = state.activeKeep.id
          await vaultKeepsService.addVaultKeep(state.newVaultKeep)
          state.newVaultKeep = {}
          Pop.toast('success', 'success')
          logger.log('addeded')
        } catch (error) {
        }
      },
      async getProfile() {
        try {
          await profilesService.getById(state.activeKeep.creatorId)
        } catch (error) {
        }
      },
      async deleteKeep() {
        if (window.confirm('Cannot be undone')) {
          await vaultKeepsService.deleteVaultKeep(state.activeVaultKeep.vaultKeepId)
        }
        // if (Pop.confirm() === true) {
        // }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.user-pic{
  height: 3em;
  width: 3em;
  border-radius: 100px;
}

.img-size{
  width: 65vw;
}

</style>
