<template>
  <div class="VaultPage">
    <div class="container-fluid">
      <div class="row">
        <div class="col">
          {{ state.vault.name }}
          <hr>
          <div class="card-column">
            <Keep v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { vaultKeepsService } from '../services/VaultKeepsService'
export default {
  name: 'VaultPage',
  setup() {
    const state = reactive({
      profile: computed(() => AppState.activeProfile),
      vault: computed(() => AppState.activeVaultKeep)
    })
    onMounted(async() => {
      try {
        await vaultKeepsService.getVaultKeep()
      } catch (error) {

      }
    })
    return { state }
  }
}
</script>

<style lang="scss" scoped>

</style>
