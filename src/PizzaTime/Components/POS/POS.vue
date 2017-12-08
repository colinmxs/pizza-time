<template>
  <div id="pos">
    <div class="header">
      <grid>
        <div class="col-3-12">
          {{clock.localDate}}
        </div>
        <div class="col-6-12" style="text-align:center;">
          PIZZA TIME P.O.S.
        </div>
        <div class="col-3-12" style="text-align:right;">
          {{clock.localTime}}
        </div>
      </grid>
    </div>
    <login v-if="!isLoggedIn"></login>
  </div>
</template>

<script>
  import Login from './Login';
  import Grid from '../Grid';

  export default {
    name: 'pos',
    props: ['clock'],
    data() {
      return {
        isLoggedIn: false        
      }
    },    
    components: {
      'login': Login,
      'grid': Grid
    }    
  }
</script>

<style lang="scss">
  @import url('https://fonts.googleapis.com/css?family=Press+Start+2P');

  #pos {
    font-family: 'Press Start 2P', cursive;
    min-height: 500px;
    height: 75vh;
    background-color: #331FF9;
    color: #FFF;
  }

    #pos .header:first-child {
      padding-top: 10px;
    }

  .line-item {
    text-transform: uppercase;
  }

  .header {
    background-color: #B10AF9;    
  }

  .highlighted {
    background-color: #09BCF8;
  }
</style>
