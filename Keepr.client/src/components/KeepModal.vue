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
                <div class="row">
                  <div class="col d-flex justify-content-around">
                    <small><i class="far fa-eye"></i> {{ state.activeKeep.views }}</small><small><i class="far fa-save"></i> {{ state.activeKeep.keeps }}</small><small><i class="fas fa-share-alt"></i> {{ state.activeKeep.shares }}</small>
                  </div>
                </div>
                <div class="row">
                  <div class="col p-3">
                    <h2 class="text-center">
                      {{ state.activeKeep.name }}
                    </h2>
                    <p class="mt-5 ml-3">
                      {{ state.activeKeep.description }}
                    </p>
                  </div>
                </div>
                <div class="row mt-5">
                  <div class="col mt-5">
                    <form @submit.prevent="addVaultKeep" class="mb-5 ml-5 mt-5">
                      <div class="dropdown" v-if="state.accountVaults.length === 0">
                        <label>Add To Vault</label>
                        <select class="form-select" aria-labelledby="dropdownMenuButton" v-model="state.newVaultKeep.vaultId" required>
                          <option>no vaults</option>
                        </select>
                      </div>
                      <div v-else class="dropdown d-flex">
                        <select class="form-select" aria-labelledby="dropdownMenuButton" v-model="state.newVaultKeep.vaultId" required>
                          <option v-for="vault in state.accountVaults" :key="vault.id" :value="vault.id">
                            {{ vault.name }}
                          </option>
                        </select>
                        <button type="submit" title="add to vault" class="btn btn-success" v-if="state.accountVaults.length>0">
                          Add to vault
                        </button>
                      </div>
                    </form>
                    <div class="text-center float-right" v-if="state.account.id === state.activeKeep.creatorId">
                      <button data-dismiss="modal" class="btn btn-danger" @click="deleteKeep">
                        Delete
                      </button>
                    </div>
                    <div class="text-wrap" v-if="state.activeKeep.creator">
                      <router-link title="go to Profile" :to="{name:'ProfilePage', params:{id: state.activeKeep.creatorId}}" data-dismiss="modal" class="d-flex justify-content-around mt-5">
                        <img :src="state.activeKeep.creator.picture" alt="creator pic" class="user-pic justify-content-around" v-if="state.activeKeep.creator">
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
import { keepsService } from '../services/KeepsService'
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
      newVaultKeep: {}
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
          await keepsService.delete(state.activeKeep.id)
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
  width: 40vw;
  height: 60vh;
}
</style>
