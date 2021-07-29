<template>
  <div class="profile">
    <div class="container-fluid">
      <div class="row">
        <div class="col-5">
          <div class="card d-flex">
            <img :src="state.activeProfile.creator.picture" alt="profile pic">
            <h1>{{ state.creator.name }}</h1>
            <h2>Vaults: {{ state.accountVaults.length }}</h2>
            <h2>Keeps: {{ state.accountKeeps.length }}</h2>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Profile',
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
