<template>
  <button class="item text-white" type="button" data-toggle="modal" data-target="#exampleModal">
    <img :src="keep.img" class="card-img img-fluid">
    <div class="card-img-overlay tpbg">
      <div>
        <p>
          {{ keep.name }}
        </p>
        <p>
          {{ keep.description }}
        </p>
        <img :src="keep.creator.picture" class="rounded-circle isize">
        <p>
          {{ keep.creator.name }}
        </p>
      </div>
    </div>
  </button>
</template>

<script>
import { reactive } from '@vue/reactivity'
export default {
  props: {
    keep: { type: Object, required: true }
  },
  name: 'Keep',
  setup() {
    const state = reactive({

    })
    return { state }
  }
}
</script>

<style lang="scss" scoped>
.isize{
  height: 2em;
  width: 2em;
}
.tpbg{
  background-color: #0000001d;
  background-image: url("https://www.transparenttextures.com/patterns/cream-paper.png");
}
.item {
    display: inline-block;
    background:none;
    margin: 0 0 1.5em;
    width: 100%;
    box-sizing: border-box;
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
    box-shadow: 2px 2px 4px 0 #ccc;
}
.item img{max-width:100%; height: auto;}

</style>
