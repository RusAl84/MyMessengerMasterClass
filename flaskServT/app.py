import json
import time
from datetime import datetime
from flask import Flask, request
from flask_cors import CORS

app = Flask(__name__)
CORS(app)

ListOfMessages = []

@app.route('/')
def dafault_route():
    return 'Messenger Flask server is running! ' \
           '<br> <a href="/status">Check status</a>'


@app.route('/status')
def status():
    return {
        'messages_count': len(ListOfMessages)
    }

# отправка сообщений
@app.route("/api/mes", methods=['POST'])
def SendMessage():
    msg = request.json
    msg['timeStamp']= datetime.now()
    print(msg)
    # messages.append({ "userName":"RusAl","messageText":"Privet na sto let!!!","timeStamp":"2021-03-05T18:23:10.932973Z"})
    ListOfMessages.append(msg)
    print(msg)
    msgtext = f"{msg['userName']} <{msg['timeStamp']}>: {msg['messageText']}"
    print(f"Всего сообщений: {len(ListOfMessages)} Посланное сообщение: {msgtext}")
    return f"Сообщение отослано успшно. Всего сообщений: {len(ListOfMessages)} ", 200


# получение сообщений
@app.route("/api/mes/<int:id>")
def GetMessage(id):
    print(id)
    if id >= 0 and id < len(ListOfMessages):
        print(ListOfMessages[id])
        return ListOfMessages[id], 200
    else:
        return "not found", 400

if __name__ == '__main__':
    app.run()