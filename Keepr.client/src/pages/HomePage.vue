<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="card-columns mt-4">
          <Keep v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
        </div>
      </div>
    </div>
  </div>
  <KeepModal />
</template>

<script>
import { computed, onMounted, reactive } from '@vue/runtime-core'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account)
    })
    onMounted(async() => {
      try {
        await keepsService.getAll()
      } catch (error) {
        Pop.toast()
      }
    })
    return { state }
  }
}

</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
body {
  font-family: sans-serif;
   margin: 0;
   background: #f2f2f2;
}

.card-columns{
  column-count: 4;
}
@media(max-width: 650px){
.card-columns{
  column-count: 2;
}
}

</style>
