<template>
  <div class="keep card rounded shadow">
    <img :src="keep.img" alt="image" class="w-100 image rounded" @click="getKeep">
    <p>{{ keep.name }}</p>
  </div>
</template>

<script>

import { reactive } from '@vue/reactivity'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
import { computed } from '@vue/runtime-core'
export default {
  name: 'Keep',
  setup(props) {
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {
      state,
      async getKeep() {
        try {
          await keepsService.getKeep(props.keep.id)
        } catch (error) {
          Pop.toast()
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
