<template>
  <div class="VaultPage">
    <div class="container-fluid">
      <div class="row">
        <div class="col">
          <p>
            {{ state.vault.name }}
          </p>
          <hr>
          <div class="card-columns">
            <VKeep v-for="keep in state.keep" :key="keep.id" :keep="keep" />
          </div>
        </div>
      </div>
    </div>
  </div>
  <VKModal />
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      profile: computed(() => AppState.activeProfile),
      vault: computed(() => AppState.activeVault),
      keep: computed(() => AppState.keeps)
    })
    onMounted(async() => {
      try {
        // if (state.profile.id !== state.vault.creatorId && state.vault.isPrivate === true) {
        //   router.push({ path: 'Home' })
        // } else {
        await vaultsService.getById(route.params.id)
        await keepsService.getKeepsByVaultId(route.params.id)
        // }
      } catch (error) {
      }
    })
    return { state }
  }
}
</script>

<style lang="scss" scoped>

.card-columns{
  column-count: 4;
}
@media(max-width: 650px){
.card-columns{
  column-count: 2;
}
}

</style>
