<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { useRoute } from 'vue-router'
export default {
  name: 'Account',
  setup() {
    const route = useRoute()
    onMounted(async() => {
      await keepsService.getKeepsByAccountId(route.params.id)
    })
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
