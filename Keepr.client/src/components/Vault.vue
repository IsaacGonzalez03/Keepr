<template>
  <div class="vault card text-center">
    <div @click="getVault">
      <img :src="vault.img" class="card-img-top img-fluid w-100">
      <h5 class="mt-2">
        {{ vault.name }}
      </h5>
      <p v-if="vault.isPrivate == true">
        Private
      </p>
    </div>
    <div>
      <button title="delete" class="btn btn-danger m-2 float-right" data-dismiss="modal" @click="deleteVault" v-if="state.account.id === vault.creatorId">
        Delete
      </button>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { useRouter } from 'vue-router'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'Vault',
  props: {
    vault: { type: Object, required: true }
  },
  setup(props) {
    const router = useRouter()
    const state = reactive({
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile)
    })
    return {
      router,
      state,
      async getVault() {
        await vaultsService.getById(props.vault.id)
        router.push({ name: 'VaultPage', params: { id: props.vault.id } })
      },
      async deleteVault() {
        if (window.confirm('Cannot be undone')) {
          await vaultsService.delete(props.vault.id)
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
