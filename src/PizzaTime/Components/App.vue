<template>
  <div id="app">
    <grid>
      <point-of-sale :clock="clock"></point-of-sale>
    </grid>
  </div>
</template>

<script>
  import POS from './POS/POS';
  import Grid from './Grid';
  import Clock from './clock';
  
export default {
    name: 'app',
    data() {
      return {
        clock: Clock
      }
    },
    components: {
    'point-of-sale':POS,
    'grid':Grid
  },
  mounted() {
    Clock.start();
  },
  destroyed() {
    Clock.stop();
  }
}
</script>

<style lang="scss">

</style>
