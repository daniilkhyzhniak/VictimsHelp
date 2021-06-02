import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import 'main.dart';
import 'package:http_client/http_client.dart' as http;
import 'package:http/io_client.dart';
import 'dart:io';
import 'package:intl/intl.dart';

import 'package:url_launcher/url_launcher.dart';
import 'models/event.dart';
import 'dart:async';
import 'dart:convert';

class CalendarTab extends StatefulWidget {
  @override
  CalendarTabState createState() => CalendarTabState();
}

Future<Event> getEvent(int index) async {
  final ioc = new HttpClient();
  ioc.badCertificateCallback =
      (X509Certificate cert, String host, int port) => true;
  final http = new IOClient(ioc);

  final response =
  await http.get(Uri.https('10.0.2.2:44322', 'api/calendar/events'),
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + MyAppState.token
      }
  );

  print(response.statusCode);

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    print(jsonDecode(response.body)[1]);
    return Event.fromJson(jsonDecode(response.body.toString())[index]);
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load event');
  }
}

//fix
Future getEventsLength() async {
  final ioc = new HttpClient();
  ioc.badCertificateCallback =
      (X509Certificate cert, String host, int port) => true;
  final http = new IOClient(ioc);

  final response =
  await http.get(Uri.https('10.0.2.2:44322', 'api/calendar/events'),
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + MyAppState.token
      }
  );

  print(response.statusCode);

  if (response.statusCode == 200) {
    print(jsonDecode(response.body)[1]);
    return response.body.length;
  } else {
    throw Exception('Failed to load events');
  }
}

Future addEmergency() async{
  final ioc = new HttpClient();
  ioc.badCertificateCallback =
      (X509Certificate cert, String host, int port) => true;
  final http = new IOClient(ioc);
  final response = await http.post(Uri.https('10.0.2.2:44322', '/api/calendar/emergencyCall/' + MyAppState.emailOriginal),
    headers: {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Authorization': 'Bearer ' + MyAppState.token
    });

  print(response.body);
  print(response.body.toString());
  print(response.statusCode);

  if (response.statusCode == 200)
  {
    print(response.body.toString().substring(1, response.body.toString().length - 1));
    launch(response.body.toString().substring(1, response.body.toString().length - 1));
  }
  else {
    //new Text("Invalid email or password");
  }
  print("Token: ${MyAppState.token}");
  //print(pref.toString());
  print(response.statusCode);

}

class CalendarTabState extends State<CalendarTab> {
  Future<Event> futureEvent;
  Future eventsLength;
  var formatter = new DateFormat('dd-MM-yyyy');

  @override
  Widget build(BuildContext context) {
    print(getEventsLength());
    return Scaffold(
      body: Scrollbar(
        child: ListView(
          restorationId: 'list_demo_list_view',
          padding: const EdgeInsets.symmetric(vertical: 8,
          horizontal: 40),
          children: [
            SizedBox(
              width: 200,
              height: 50,
              child: RaisedButton(
                color: Colors.red,
                onPressed: (){
                  //launch("http://youtube.com");
                  addEmergency();
                },
                shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(50.0),
                    side: BorderSide(color: Colors.black45,width: 2)
                ),
                textColor:Colors.white,child: Text("Emergency call",
                style: TextStyle(fontSize: 15),),

              ),
            ),
            SizedBox(
              height: 15,
            ),

            for (int index = 0; index < 14; index++)
              FutureBuilder<Event>(
                future: futureEvent = getEvent(index),
                builder: (context, snapshot) {
                  if (snapshot.hasData) {
                    return Padding(
                        padding: EdgeInsets.all(20),
                        child: Align(
                            alignment: Alignment.topLeft,
                            child: TextButton(
                                style: TextButton.styleFrom(
                                  textStyle: const TextStyle( fontSize:20.0,
                                      color: const Color(0xAAFF1E00),
                                      fontWeight: FontWeight.w400,
                                      letterSpacing: 0.5,
                                      fontFamily: "Roboto"),
                                ),
                                onPressed: () => launch(snapshot.data.hangoutLink.toString()
                                    .substring(1, snapshot.data.hangoutLink.toString().length - 1)),
                                child: new Text(snapshot.data.start.substring(0, 10) + "\n"
                                 + snapshot.data.summary +
                                "\n" + snapshot.data.start.substring(11, 16) +
                                " - " + snapshot.data.end.substring(11, 16)
                                )
                            )
                        )

                    );
                  } else if (snapshot.hasError) {
                    //print(snapshot.data.summary);
                    return Text("");// Text("${snapshot.error}");
                  }

                  // By default, show a loading spinner.
                  return LinearProgressIndicator();
                },
              )
          ],
        ),
      ),
    );
  }
}