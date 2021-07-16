<template>
  <v-container>
    <!--  <div id="example-1">-->
    <!--    <button v-on:click="counter += 1">+1</button>-->
    <!--    <p>Кнопка выше была нажата {{ counter }} раз</p>-->
    <!--  </div>-->
    <v-card>
      <v-card-title>MyMessenger</v-card-title>
      <!-- Панель сообщений -->
      <v-card-text>
        <div class="messages-view">
          <div class="message" v-for="(message, i) in messages" :key="i">
            <span class="message-date mr-3">{{ new Date(message.TimeStamp).toDateString() }}</span>
            <span class="message-username mr-5">{{ message.UserName }}</span>
            <span class="message-text">{{ message.MessageText }}</span>
          </div>
        </div>
      </v-card-text>
      <!-- Панель действий -->
      <v-card-text>
        <div>
          <v-text-field style="width: 40%; min-width: 200px" outlined dense v-model="UserName" label="UserName"/>
        </div>
        <div class="d-flex">
          <v-text-field class="mr-10" outlined dense v-model="MessageText" label="MessageText"/>
          <v-btn
              depressed
              color="primary"
              @click="onSendClick"
              :disabled="!MessageText.length"
          >
            <v-icon>mdi-send</v-icon>
          </v-btn>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
import API from '../api/api.js';

export default {
  // Модель данных страницы
  data: () => {
    return {
      // counter: 0,
      UserName: '',
      MessageText: '',
      // messages: [
      //   { "UserName":"RusAl","MessageText":"Privet na sto let!!!","TimeStamp":"2021-03-05T18:23:10.932973Z"},
      //]
      messages: [],
      intervalCtx: null,
      lastMsgID: 0,
    }

  },

  // Хук который сработает когда страница создасться
  mounted() {
    this.UserName = "Login"
    this.intervalCtx = setInterval(async () => {
      try {
        const msg = await API.getMessage(this.lastMsgID)
        if (typeof msg === typeof {}) {
          this.messages.push(msg)
          this.lastMsgID++
        }
      } catch (e) {
        console.error(e)
      }
    }, 1000)
  },

  methods: {
    // Реакция на кнопку отправки
    async onSendClick() {
      try {
        await API.sendMessage(this.UserName, this.MessageText)
        console.log('cleared')
        this.message = ''
      } catch (e) {
        console.error(e)
      }
    },
  },
  // После уничтожения компонента
  destroyed() {
    clearInterval(this.intervalCtx)
  }
}
</script>

<style lang="sass" scoped>
.messages-view
  //border: 1px solid black
  border-radius: 3px
  overflow-x: hidden
  overflow-y: scroll
  height: 40vh

  .message
    background: #9fc8ea
    border-radius: 3px
    padding: 3px
    margin: 5px

    .message-date
      color: rgba(255, 255, 255, 0.9)

    .message-username
      color: rgba(255, 255, 0, 0.8)

    .message-text
      color: rgba(0, 0, 0, 0.9)
</style>