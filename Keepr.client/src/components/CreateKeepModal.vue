<template>
  <div class="component">

    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary modal-btn" data-bs-toggle="modal" data-bs-target="#exampleModal">
      <h2 class="p-0 m-0"><i class="mdi mdi-plus"></i></h2>
    </button>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-body">
            <div class="d-flex flex-column">
              <h3>Create a New Keep</h3>
              <form action="">
                <label for="">Title</label>
                <input type="text" class="form-control" placeholder="title...">
                <label for="" class="mt-2">Img Url</label>
                <input type="text" class="form-control" placeholder="image url...">
                <label for="" class="mt-2">Description</label>
                <textarea name="" id="" cols="30" rows="6" placeholder="description..." class="form-control"></textarea>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.modal-btn {
  position: absolute;
  right: 1.5rem;
  bottom: 1.5rem;
  border-radius: 50%;
}
</style>
