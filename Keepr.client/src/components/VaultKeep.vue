<template>
  <div class="component">
    <div class="keep-container" data-bs-target="#keepModal" data-bs-toggle="modal" @click="setActiveKeep()">
      <img :src="keep.img" alt="" class="img-fluid">
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
  z-index: 100;
  bottom: 0;
  left: 0;
  right: 0;
  // top: 0;
  // right: auto;
  font-weight: bold;
  text-shadow: 1px 1px rgba(126, 125, 125, 0.313);
}
</style>
