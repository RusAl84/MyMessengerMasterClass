<template>
  <v-app>
    <v-main>
      <ChatPage/>
    </v-main>
  </v-app>
</template>

<script>
import ChatPage from './components/ChatPage';
export default {
  name: 'App',
  components: {
    ChatPage,
  },
  data: () => ({}),
}
</script>
