<template>
  <div class="component">
    <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">
              New Keep
            </h5>
            <button title="close" type="button" class="btn" data-dismiss="modal" aria-label="Close">
              <i class="fas fa-times"></i>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="newKeep">
              <div class="form-group">
                <label for="vault name">name</label>
                <input type="text" required v-model="state.newKeep.name">
              </div>
              <div class="form-group">
                <label for="vault description">description</label>
                <input type="text" required v-model="state.newKeep.description">
              </div>
              <div class="form-group">
                <label for="vault img">img url</label>
                <input type="text" required v-model="state.newKeep.img">
              </div>
              <button type="submit" title="submit" class="btn btn-primary">
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
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
export default {
  name: 'Component',
  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      newVault: {},
      newKeep: {},
      accountKeeps: computed(() => AppState.accountKeeps),
      accountVaults: computed(() => AppState.accountVaults)
    })
    return {
      state,
      async newKeep() {
        try {
          state.newKeep.creatorId = state.account.id
          await keepsService.create(state.newKeep)
          Pop.toast('success', 'success')
        } catch (error) {
          Pop.toast('error', 'error')
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
