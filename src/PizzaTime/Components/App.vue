<template>
  <div id="app">
    <grid>
      <div class="col-9-12">
        <point-of-sale></point-of-sale>               
      </div>
      <div class="col-3-12">
      </div>
    </grid>
  </div>
</template>

<script>
import POS from './POS/POS';
import Grid from './Grid';

export default {
  name: 'app',
  components: {
    'point-of-sale':POS,
    'grid':Grid
  }
}
</script>

<style lang="scss">

</style>
