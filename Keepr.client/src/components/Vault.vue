<template>
  <div class="vault card">
    <div @click="getVault">
      <img :src="vault.img" class="card-img-top img-fluid w-100">
      <h5>{{ vault.name }}</h5>
      <p v-if="vault.isPrivate == true">
        Private
      </p>
    </div>
    <div>
      <button class="btn btn-danger" data-dismiss="modal" @click="deleteVault" v-if="state.account.id === vault.creatorId">
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
      state
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
