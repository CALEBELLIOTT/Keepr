<template>
  <div class="component">
    <!-- <div class="p-2 keep-container d-flex align-items-end justify-content-between"
      :style="`background-image: url('${keep.img}');`">
      <h3>{{ keep.name }}</h3>
      <img class="creator-img" :src="keep.creator.picture" alt="">
    </div> -->

    <div class="keep-container h-20 w-20 text-light" data-bs-target="#keepModal" data-bs-toggle="modal"
      @click="setActiveKeep()">
      <img :src="keep.img" alt="" class="img-fluid keep-img">
      <div class="d-flex justify-content-between img-text mx-2">
        <h3 class="mx-2">{{ keep.name }}</h3>
        <img :src="keep.creator?.picture" alt="" class="creator-img my-2">
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from "../AppState"
import { keepsService } from "../services/KeepsService"

export default {
  props: { keep: { type: Object, required: true } },
  setup(props) {
    return {
      setActiveKeep() {
        props.keep.views++
        AppState.activeKeep = props.keep
        keepsService.incrementViews(props.keep.id, props.keep)
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.creator-img {
  border-radius: 50%;
  height: 3rem;
}

.keep-container {
  position: relative;
  transition: 400ms;
}

.keep-container:hover {
  cursor: pointer;
  transform: scale(1.01);
  transition: 400ms;
}

.img-text {
  position: absolute;
  z-index: 1;
  bottom: 0;
  left: 0;
  right: 0;
  // top: 0;
  // right: auto;
  font-weight: bold;
  text-shadow: 1px 1px rgba(37, 37, 37, 0.656);
}

.keep-img {
  object-fit: cover;
}
</style>
