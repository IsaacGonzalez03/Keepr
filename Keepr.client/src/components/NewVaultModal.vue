<template>
  <div class="component">
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">
              New Vault
            </h5>
            <button type="button" class="btn" data-dismiss="modal" aria-label="Close">
              <i class="fas fa-times"></i>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="newVault">
              <div class="form-group">
                <label for="vault name">name</label>
                <input type="text" required v-model="state.newVault.name">
              </div>
              <div class="form-group">
                <label for="vault description">description</label>
                <input type="text" required v-model="state.newVault.description">
              </div>
              <div class="form-group">
                <label for="vault img">img url</label>
                <input type="text" required v-model="state.newVault.img">
              </div>
              <div class="form-group">
                <label for="">Private
                  <input type="checkbox" v-model="state.newVault.isPrivate">
                </label>
              </div>
              <button type="submit" class="btn btn-primary">
                Submit
              </button>
            </form>
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
import { vaultsService } from '../services/VaultsService'
import Pop from '../utils/Notifier'
export default {
  name: 'Component',
  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile),
      vaults: computed(() => AppState.accountVaults),
      keeps: computed(() => AppState.accountKeeps),
      newVault: {},
      newKeep: {}
    })
    return {
      state,
      async newVault() {
        try {
          state.newVault.creatorId = state.account.id
          await vaultsService.create(state.newVault)
          Pop.toast('success', 'success')
          state.newVault = {}
        } catch (error) {
          Pop.toast('error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
