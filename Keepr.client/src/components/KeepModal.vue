<template>
  <div class="modal fade" id="Modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <div class="col-sm-6 p-0">
                <img :src="state.activeKeep.img" class="img-fluid img-size rounded" alt="">
              </div>
              <div class="col-sm-6">
                <div class="d-flex justify-content-around user-select-none">
                  <small><i class="far fa-eye"></i> {{ state.activeKeep.views }}</small><small><i class="far fa-save"></i> {{ state.activeKeep.keeps }}</small><small><i class="fas fa-share-alt"></i> {{ state.activeKeep.shares }}</small>
                </div>
                <hr>
                <h2 class="text-center">
                  {{ state.activeKeep.name }}
                </h2>
                <p>{{ state.activeKeep.description }}</p>
                <hr>
                <div class="d-flex align-self-baseline">
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
                  <i class="far fa-trash-alt text-danger" type="button" data-dismiss="modal"></i>
                  <div class="d-flex" v-if="state.activeKeep.creator">
                    <img :src="state.activeKeep.creator.picture" alt="creator pic" class="user-pic">
                    <p class="mt-2 p-0">
                      {{ state.activeKeep.creator.name }}
                    </p>
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
export default {
  name: 'Modal',
  setup() {
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      activeProfile: computed(() => AppState.activeProfile)
    })
    return { state }
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
