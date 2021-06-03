import 'package:flutter/material.dart';
import 'package:victims_help/main.dart';
import 'models/message.dart';
import 'models/user.dart';
import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter/services.dart';
import 'manageProfile/ChangeSubscriptionSubmitWindow.dart';
import 'package:http_client/http_client.dart' as http;
import 'package:http/io_client.dart';
import 'dart:io';


class ChatScreen extends StatefulWidget {
  @override
  _ChatScreenState createState() => _ChatScreenState();
}

class _ChatScreenState extends State<ChatScreen> {
  static const threeSec = const Duration(seconds:3);
  static String senderEmail = "asd";
  static String receiverEmail = "asd";
  static String senderName = "asd";
  static String text = "asd";
  static String dateTime = "asd";
  static int length = 20;

  TextEditingController sendText = TextEditingController();

  Future<Message> oldMessage;
  Future<Message> newMessage;

  Future sendMessage(String text) async{
    final ioc = new HttpClient();
    ioc.badCertificateCallback =
        (X509Certificate cert, String host, int port) => true;
    final http = new IOClient(ioc);

    var mapeddate = {
      'text': text
    };
    print("JSON DATA: ${mapeddate}");

    //mb fix
    var body = jsonEncode(mapeddate);

    print("JSON ENCODED DATA: ${body}");

    String psyEmail;
    if (MyAppState.psychologistEmailOriginal == null) {
      psyEmail = "admin1@gmail.com";
    } else {
      psyEmail = MyAppState.psychologistEmailOriginal;
    }

    //String token = await getToken();
    final response = await http.post(Uri.https('10.0.2.2:44322', '/api/chat/' + psyEmail),
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + MyAppState.token
        },
        body: body);

    print("Token: ${MyAppState.token}");
    //print(pref.toString());
    print("Sending to: " + MyAppState.psychologistEmailOriginal);
    print(response.statusCode);
    //print("DATA: ${data}");

    if (response.statusCode == 200)
    {
      print(text);
      print("sent to " + MyAppState.psychologistEmailOriginal);
    }
    else {
      //new Text("Invalid email or password");
    }
  }

  Future<Message> getNewMessage(int index) async{
    final ioc = new HttpClient();
    ioc.badCertificateCallback =
        (X509Certificate cert, String host, int port) => true;
    final http = new IOClient(ioc);

    print(MyAppState.psychologistEmailOriginal.toString());

    String psyEmail;
    if (MyAppState.psychologistEmailOriginal == null) {
      psyEmail = "admin1@gmail.com";
    } else {
      psyEmail = MyAppState.psychologistEmailOriginal;
    }
    //fix
    final response =
        await http.get(Uri.https('10.0.2.2:44322', 'api/chat/' + psyEmail),
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Bearer ' + MyAppState.token
          });

    print(response.statusCode);
    //print(response.body);

    if (response.statusCode == 200) {
      // If the server did return a 200 OK response,
      // then parse the JSON.
      //print(jsonDecode(response.body)[jsonDecode(response.body).length - 1]);
      print(jsonDecode(response.body)[index]);
      return Message.fromJson(jsonDecode(response.body)[index]);
    } else {
      // If the server did not return a 200 OK response,
      // then throw an exception.
      throw Exception('Failed to load message');
    }
  }

  Timer timer;

  void timerStart() {
    timer = Timer.periodic(threeSec, (timer) {
      MyAppState.getInfo();
      // Stop the timer when it matches a condition
      if (timer.tick >= 0) {
        setState(() {});
      }
      print('Tick: ${timer.tick}');
    });
  }

  //function for showing chat bubbles
  _chatBubble() {
    //checking if the user is the sender
    if (_ChatScreenState.senderEmail == MyAppState.emailOriginal) {
      return Column(
        children: <Widget>[
          //container with text message
          Container(
                alignment: Alignment.topRight,
                child: Container(
                  constraints: BoxConstraints(
                    maxWidth: MediaQuery.of(context).size.width * 0.80,
                  ),
                  padding: EdgeInsets.all(10),
                  margin: EdgeInsets.symmetric(vertical: 10),
                  decoration: BoxDecoration(
                    color: Theme.of(context).primaryColor,
                    borderRadius: BorderRadius.circular(15),
                    boxShadow: [
                      BoxShadow(
                        color: Colors.grey.withOpacity(0.5),
                        spreadRadius: 2,
                        blurRadius: 5,
                      ),
                    ],
                  ),
                  child: Text(
                    _ChatScreenState.text,
                    style: TextStyle(
                      color: Colors.white,
                    ),
                  ),
                ),
              ),
              (_ChatScreenState.senderEmail == MyAppState.emailOriginal)
              ? Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: <Widget>[
                  Text(
                    _ChatScreenState.dateTime.substring(11, 16),
                    style: TextStyle(
                      fontSize: 12,
                      color: Colors.black45,
                    ),
                  ),
                  SizedBox(
                    width: 10,
                  ),
                  Container(
                    decoration: BoxDecoration(
                      shape: BoxShape.circle,
                      boxShadow: [
                        BoxShadow(
                          color: Colors.grey.withOpacity(0.5),
                          spreadRadius: 2,
                          blurRadius: 5,
                        ),
                      ],
                    ),
                  ),
                ],
              )
              : Container(
            child: null,
          ),
        ],
      );
    } else {
      return Column(
        children: <Widget>[
          Container(
            alignment: Alignment.topLeft,
            child: Container(
              constraints: BoxConstraints(
                maxWidth: MediaQuery.of(context).size.width * 0.80,
              ),
              padding: EdgeInsets.all(10),
              margin: EdgeInsets.symmetric(vertical: 10),
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(15),
                boxShadow: [
                  BoxShadow(
                    color: Colors.grey.withOpacity(0.5),
                    spreadRadius: 2,
                    blurRadius: 5,
                  ),
                ],
              ),
              child: Text(
                _ChatScreenState.text,
                style: TextStyle(
                  color: Colors.black54,
                ),
              ),
            ),
          ),
          _ChatScreenState.senderEmail != MyAppState.emailOriginal//!isSameUser
              ? Row(
            children: <Widget>[
              Container(
                decoration: BoxDecoration(
                  shape: BoxShape.circle,
                  boxShadow: [
                    BoxShadow(
                      color: Colors.grey.withOpacity(0.5),
                      spreadRadius: 2,
                      blurRadius: 5,
                    ),
                  ],
                ),
              ),
              SizedBox(
                width: 10,
              ),
              Text(
                _ChatScreenState.dateTime.substring(11, 16),
                style: TextStyle(
                  fontSize: 12,
                  color: Colors.black45,
                ),
              ),
            ],
          )
              : Container(
            child: null,
          ),
        ],
      );
    }
  }

  _sendMessageArea() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 8),
      height: 70,
      color: Colors.white,
      child: Row(
        children: <Widget>[
          Expanded(
            child: TextField(
              decoration: InputDecoration.collapsed(
                hintText: '     Send a message...',
              ),
              controller: sendText,
              textCapitalization: TextCapitalization.sentences,
            ),
          ),
          IconButton(
            icon: Icon(Icons.send),
            iconSize: 25,
            color: Theme.of(context).primaryColor,
            onPressed: () {
              sendMessage(sendText.text);
              senderEmail = MyAppState.emailOriginal;
              receiverEmail = MyAppState.psychologistEmailOriginal;
              senderName = MyAppState.firstNameOriginal;
              text = sendText.text;
              sendText.clear();
              setState(() {});
              //dateTime = DateTim;
            },
          ),
        ],
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    int prevUserId;
    return Scaffold(
      //backgroundColor: Color(0xFFF6F6F6),
      /*
      appBar: AppBar(
        brightness: Brightness.dark,
        centerTitle: true,
        title: RichText(
          textAlign: TextAlign.center,
          text: TextSpan(
            children: [
              TextSpan(
                  text: "Psychologist",
                  style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.w400,
                  )),
              TextSpan(text: '\n'),
              true ?
              TextSpan(
                text: 'Online',
                style: TextStyle(
                  fontSize: 11,
                  fontWeight: FontWeight.w400,
                ),
              )
                  :
              TextSpan(
                text: 'Offline',
                style: TextStyle(
                  fontSize: 11,
                  fontWeight: FontWeight.w400,
                ),
              )
            ],
          ),
        ),
        leading: IconButton(
            icon: Icon(Icons.arrow_back_ios),
            color: Colors.white,
            onPressed: () {
              Navigator.pop(context);
            }),
      ),*/
      body: Column(
        children: <Widget>[
            Expanded(
              child: ListView.builder(
              reverse: true,
              padding: EdgeInsets.all(20),
              itemCount: length,
              itemBuilder: (BuildContext context, int index) {
                  return FutureBuilder<Message>(
                      future: newMessage = getNewMessage(length - index - 1),
                      builder: (context, snapshot) {
                        print("FutureBuilder<Message> got in");
                        if (snapshot.hasData) {
                          if (timer == null) {
                            timerStart();
                          }
                          print("getNewMessage() worked");
                          if (oldMessage.toString() != newMessage.toString()) {
                            print("oldMessage != newMessage");
                            //oldMessage = newMessage;
                            _ChatScreenState.senderEmail =
                                snapshot.data.senderEmail;
                            _ChatScreenState.receiverEmail =
                                snapshot.data.receiverEmail;
                            _ChatScreenState.senderName =
                                snapshot.data.senderName;
                            _ChatScreenState.text = snapshot.data.text;
                            _ChatScreenState.dateTime = snapshot.data.dateTime;
                            return _chatBubble();
                          } else {
                            return Text("same");
                          }
                        } else if (snapshot.hasError) {
                          print(snapshot.error);
                          return Text("");
                        } else
                          print(snapshot.data);
                        print("Future builder end");
                        return LinearProgressIndicator();
                      }
                  );
                },
                )
            ),
          _sendMessageArea(),
        ],
      ),
    );
  }
}