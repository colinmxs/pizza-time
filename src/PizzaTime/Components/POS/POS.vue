<template>
  <div id="pos">
      <div class="header">
          <grid>
              <div class="col-3-12">
                  {{currentDate}}
              </div>
              <div class="col-6-12" style="text-align:center;">
                PIZZA TIME P.O.S.             
              </div>
              <div class="col-3-12" style="float:right;">
                  {{currentTime}}
              </div>
          </grid>
      </div>
      <login v-if="isLoggedIn"></login>      
  </div>
</template>

<script>
import Login from './Login';
import Grid from '../Grid';
export default {
    name: 'pos',
    data(){
        return {
            isLoggedIn : true
        }
    },
    computed: {
        currentDate() {
            var date = new Date();
            var locale = date.toLocaleDateString();
            return locale;
        },
        currentTime() {
            var date = new Date();
            var locale = date.toLocaleTimeString();
            return locale;
        }
    },
    components: {
        'login': Login,
        'grid': Grid
    }
}
</script>

<style lang="scss">
@import url('https://fonts.googleapis.com/css?family=Dhurjati');
#pos {
    width:100%;
    height:75vh;
    font-family: 'Dhurjati', sans-serif;
    font-size:20px;
    background-color: #331FF9;
    line-height: 100%;
    color: #FFF;
}
.line-item {
    text-transform: uppercase;    
}
.header {
    background-color: #B10AF9;
}
.highlighted {
    background-color:  #09BCF8;
}
</style>
