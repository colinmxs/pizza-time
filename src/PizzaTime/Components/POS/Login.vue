<template>
  <div id="login">
    {{employeeNumber}}
      Enter your employee number:<blinking-cursor :thingy="employeeNumber"></blinking-cursor>
  </div>
</template>

<script>
  import Cursor from './Cursor';
  export default {
    data() {
      return {
        employeeNumber: ''
      }
    },
    components:
    {
      'blinking-cursor': Cursor
    },
    mounted() {
    }
}
</script>

<style lang="scss">
  #login input {
   
  }
</style>
