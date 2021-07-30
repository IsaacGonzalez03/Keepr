<template>
  <div v-if="state.loading===true && !state.profile">
    ...Loading
  </div>
  <div class="container-fluid" v-else>
    <div class="row p-sm-5 p-2">
      <div class="col-sm-3 card bg-none">
        <img :src="state.profile.picture" alt="profile pic" class="bg-none">
      </div>
      <div class="col-2">
        <p>{{ state.profile.name }}</p>
        <p>Vaults: {{ state.vaults.length }}</p>
        <button title="add vault"
                v-if="state.account.id == state.profile.id"
                type="button"
                class="btn btn-primary"
                data-toggle="modal"
                data-target="#exampleModal"
                data-whatever="@mdo"
        >
          Vault <i class="fas fa-plus text-success text-shadow"></i>
        </button>
        <hr>
        <p>Keeps: {{ state.keeps.length }}</p>
        <button title="add keep"
                v-if="state.account.id == state.profile.id"
                type="button"
                class="btn btn-primary"
                data-toggle="modal"
                data-target="#keepModal"
                data-whatever="@mdo"
        >
          Keep <i class="fas fa-plus text-success text-shadow"></i>
        </button>
      </div>
      <div class="row">
        <div class="col-12">
          <h1>Vaults</h1>
          <hr>
          <div class="card-columns">
            <Vault v-for="vault in state.vaults" :key="vault.id" :vault="vault" />
          </div>
        </div>
        <div class="col-12">
          <h1>Keeps</h1>
          <hr>
          <div class="card-columns">
            <Keep v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
          </div>
        </div>
      </div>
    </div>
  </div>
  <NewKeepModal />
  <NewVaultModal />
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { profilesService } from '../services/ProfilesService'
import Pop from '../utils/Notifier'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
import { useRoute } from 'vue-router'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      profile: computed(() => AppState.activeProfile),
      vaults: computed(() => AppState.vaults),
      account: computed(() => AppState.account),
      accountVaults: computed(() => AppState.accountVaults),
      accountKeeps: computed(() => AppState.accountKeeps),
      keeps: computed(() => AppState.keeps),
      newVault: {},
      newKeep: {},
      loading: true
    })
    onMounted(async() => {
      try {
        await profilesService.getById(route.params.id)
        await vaultsService.getVaultsByProfileId(route.params.id)
        await keepsService.getKeepsByProfileId(route.params.id)
        state.loading = false
      } catch (error) {
        Pop.toast('error')
      }
    })
    return {
      state,
      async newVault() {
        try {
          state.newVault.creatorId = state.account.id
          await vaultsService.create(state.newVault)
          Pop.toast('success')
        } catch (error) {
          Pop.toast('error')
        }
      },
      async newKeep() {
        try {
          state.newKeep.creatorId = state.account.id
          await keepsService.create(state.newKeep)
          window.alert('created')
        } catch (error) {
          window.alert('failed')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.bg-none{
  position: relative;
  background: none;
  border: none;
    border-radius: 100%;
}
</style>
