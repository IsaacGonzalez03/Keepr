<template>
  <div class="vault card col-md-3 col-6">
    <div @click="getVault">
      <img :src="vault.img" class="card-img-top img-fluid w-100">
      <h5>{{ vault.name }}</h5>
      <p v-if="vault.isPravate == true">
        Private
      </p>
    </div>
    <div>
      <button class="btn" data-dismiss="modal" @click="deleteVault" v-if="state.account.id === vault.creatorId">
        Delete
      </button>
    </div>
  </div>
</template>

<script>
import { vaultsService } from '../services/VaultsService'
import { reactive } from '@vue/reactivity'
import { useRouter } from 'vue-router'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
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
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
