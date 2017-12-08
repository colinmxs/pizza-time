<template>
  <span>
    {{thingy1}}<span class="blinking-cursor">_</span>
    <input v-model="thingy1" type="text" />
  </span>
</template>

<script>
  export default {
    props: ['thingy'],
    data() {
      return {
        thingy1: this.thingy
      }
    }

  }
</script>

<style lang="scss">
  /*input {
    height: 0;
    width: 0;
    background: rgba(0, 0, 0, 0);
    border: none;
    outline: none;
  }*/
  .blinking-cursor {
    font-weight: 500;
    font-size: 30px;
    color: #FFF;
    -webkit-animation: 1s blink step-end infinite;
    -moz-animation: 1s blink step-end infinite;
    -ms-animation: 1s blink step-end infinite;
    -o-animation: 1s blink step-end infinite;
    animation: 1s blink step-end infinite;
  }

  @keyframes

  "blink" {
    from, to

  {
    color: transparent;
  }

  50% {
    color: #FFF;
  }

  }

  @-moz-keyframes blink {
    from, to {
      color: transparent;
    }

    50% {
      color: #FFF;
    }
  }

  @-webkit-keyframes

  "blink" {
    from, to

  {
    color: transparent;
  }

  50% {
    color: #FFF;
  }

  }

  @-ms-keyframes

  "blink" {
    from, to

  {
    color: transparent;
  }

  50% {
    color: #FFF;
  }

  }

  @-o-keyframes

  "blink" {
    from, to

  {
    color: transparent;
  }

  50% {
    color: #FFF;
  }

  }
</style>
