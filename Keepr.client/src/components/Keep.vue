<template>
  <div type="button" class="bg-none card rounded shadow text-white text-wrap" data-toggle="modal" data-target="#Modal" @click="getKeep">
    <img :src="keep.img" alt="image" class="rounded card-img img-fluid">
    <div class="d-flex justify-content-around card-img-overlay card-text align-items-end pb-0">
      <p>
        {{ keep.name }}
      </p>
      <div class="d-flex">
        <img :src="keep.creator.picture" alt="creator-img" class="user-pic">
        <p>
          {{ keep.creator.name }}
        </p>
      </div>
    </div>
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
  props: {
    keep: { type: Object, required: true }
  },
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
          Pop.toast('error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.user-pic{
  height: 2em;
  width: 2em;
  border-radius: 100px;
}
.bg-none{
  position: relative;
  background: none;
  border: none;
  transition: transform 1s;
}
.bg-none:hover{
transform: scale(.95);
}
</style>
