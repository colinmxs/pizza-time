export default {
  localTime: '',
  localDate: '',
  interval: '',
  start() {
    this.interval = setInterval(() => {
      this.updateTime()
    }, 1000);
  },
  stop() {
    clearInterval(this.interval);
  },
  updateTime() {
    var date = new Date();
    this.localTime = date.toLocaleTimeString();
    this.localDate = date.toLocaleDateString();
  }
}
