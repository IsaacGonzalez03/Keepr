<template>
  <div class="modal fade" id="Modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-l">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <div class="col-sm-6 p-0">
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
                <div class="row justify-content-around">
                  <div class="col-4 m-0 p-0">
                    <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                      <div class="btn-group" role="group">
                        <button id="btnGroupDrop1" type="button" class="btn btn-success dropdown-toggle shadow-none" data-toggle="dropdown" aria-expanded="false">
                          Add to Vault
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                          <li>
                            <p class="dropdown-item">
                              Vault 1
                            </p>
                          </li>
                          <li>
                            <p class="dropdown-item">
                              Vault 2
                            </p>
                          </li>
                        </ul>
                      </div>
                    </div>
                  </div>
                  <div class="col-4 text-center" v-if="state.account.id === state.activeKeep.creatorId">
                    <i data-dismiss="modal" class="far fa-trash-alt text-danger" @click="deleteKeep"></i>
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
import { keepsService } from '../services/KeepsService'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router'
export default {
  name: 'Modal',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      activeProfile: computed(() => AppState.activeProfile)
    })
    return {
      state,
      async getProfile() {
        try {
          await profilesService.getById(state.activeKeep.creatorId)
        } catch (error) {
          Window.alert('cannot get profile')
        }
      },
      async deleteKeep() {
        try {
          await keepsService.delete(state.activeKeep.id)
        } catch (error) {
          Window.alert('not yours')
        }
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
  width: 100vw;
}
</style>
