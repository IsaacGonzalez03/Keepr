<template>
  <div class="masonry">
    <div>
      <Keep class="card" v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
  <div class="modal fade"
       id="exampleModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Modal title
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          ...
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="button" class="btn btn-primary">
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    onMounted(() => {
      keepsService.getAll()
    })
    return { keeps: computed(() => AppState.keeps) }
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

h1 {
  text-align: center;
  margin-top: 50px;
}

p {
  text-align: center;
  margin-bottom:60px;
}

h4{
  text-align:center;
  line-height:80px;
  font-weight:normal;

}

.masonry {
  -webkit-column-count: 4;
  -moz-column-count:4;
  column-count: 4;
  -webkit-column-gap: 1em;
  -moz-column-gap: 1em;
  column-gap: 1em;
  margin: 1.5em;
  padding: 0;
  -moz-column-gap: 1.5em;
  -webkit-column-gap: 1.5em;
  column-gap: 1.5em;
  font-size: .85em;
}

@media only screen and (max-width: 320px) {
    .masonry {
      -moz-column-count: 1;
      -webkit-column-count: 1;
      column-count: 1;
    }
}

@media only screen and (min-width: 321px) and (max-width: 768px){
    .masonry {
      -moz-column-count: 2;
      -webkit-column-count: 2;
      column-count: 2;
    }
}
@media only screen and (min-width: 769px) and (max-width: 1200px){
    .masonry {
      -moz-column-count: 3;
      -webkit-column-count: 3;
      column-count: 3;
    }
}
@media only screen and (min-width: 1201px) {
    .masonry {
      -moz-column-count: 4;
      -webkit-column-count: 4;
      column-count: 4;
    }
}
</style>
