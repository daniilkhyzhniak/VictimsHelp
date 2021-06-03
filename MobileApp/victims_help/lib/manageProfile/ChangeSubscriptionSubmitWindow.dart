import 'dart:convert';
import 'dart:io';

import 'package:http_client/http_client.dart' as http;
import 'package:http/io_client.dart';
import 'dart:io';

import 'package:victims_help/models/psychologist.dart';
import 'package:victims_help/models/user.dart';
import 'package:victims_help/main.dart';
import 'package:victims_help/Login.dart';
import 'package:victims_help/Registration.dart';
import 'package:flutter/services.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:select_form_field/select_form_field.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:victims_help/InputDeco_design.dart';
import 'package:victims_help/AccountInfo.dart';
import 'package:http/http.dart' as http;

class ChangeSubscriptionSubmitWindow extends StatefulWidget {
  @override
  ChangeSubscriptionSubmitWindowState createState() => ChangeSubscriptionSubmitWindowState();
}

class ChangeSubscriptionSubmitWindowState extends State<ChangeSubscriptionSubmitWindow> {
  //TextController to read text entered in text field
  TextEditingController password = TextEditingController();
  Future<Psychologist> futurePsychologist;
  String psyEmail;

  @override
  void initState() {
    super.initState();

    FutureBuilder(
        future: futurePsychologist = GetPsychologistsEmails(0),
        builder: (context, snapshot) {
          if (snapshot.hasData){
            futurePsychologist = snapshot.data;
            psyEmail = snapshot.data.email;
            print("EMAIL: " + snapshot.data.email);
            print("EMAIL: " + psyEmail);
          }
          return;
        });

  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('VictimsHelp'),
        automaticallyImplyLeading: true,
        leading: IconButton(icon: Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
      ),
      body: Center(
        child: SingleChildScrollView(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                  "Are you sure you want to buy this plan?",
                  textAlign: TextAlign.center,
                  style: new TextStyle(fontSize: 32)
              ),
              SizedBox(
                height: 30,
              ),

    FutureBuilder<Psychologist>(
    future: futurePsychologist = GetPsychologistsEmails(0),
    builder: (context, snapshot) {
      if (snapshot.hasData) {
        return SizedBox(
          width: 200,
          height: 50,
          child: RaisedButton(
              color: Colors.redAccent,
              onPressed: () {
                psyEmail = snapshot.data.email;
                MakeDeclaration();
              },
              shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(50.0),
                  side: BorderSide(color: Colors.blue, width: 2)
              ),
              textColor: Colors.white,
              child: Text("Confirm",
                style: TextStyle(fontSize: 15),
              )

          ),
        );
      } else {
        return Text("");
      }
    }),
            ],
          ),
        ),
      ),
    );
  }

  /*
  bool CheckEmailPassword(TextEditingController email) async{
    //String token = await getToken();
    http.Response response = await http.post(Uri.https('localhost:44322', '/api/account/login'),
        headers: {"Content-Type": "application/json-patch+json"},
        //HttpHeaders.authorizationHeader: "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZW1haWxAdGV4dC5jb20iLCJJZCI6IjFiZTMwN2NmLTVmMTktNGE4OS01MWQyLTA4ZDkyMWJjOTc0NCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkNsaWVudCIsIm5iZiI6MTYyMjE5NDg0MiwiZXhwIjoxNjIyNjI2ODQyLCJpc3MiOiJWaWN0aW1zSGVscCJ9.nAjKD3UsMTGc9kpJCwTgB1vsTJHhPzTFND7dHTnF2kM"},
        body: body);
  }*/

  Future<Psychologist> GetPsychologistsEmails(int index) async{
    final ioc = new HttpClient();
    ioc.badCertificateCallback =
        (X509Certificate cert, String host, int port) => true;
    final http = new IOClient(ioc);

    final response =
    await http.get(Uri.https('10.0.2.2:44322', 'api/psychologists'),
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + MyAppState.token
      }
      );
    print(MyAppState.token);
    print(response.statusCode);
    if (response.statusCode == 200) {
      print(jsonDecode(response.body));
      return Psychologist.fromJson(jsonDecode(response.body)[index]);
    } else {
      // If the server did not return a 200 OK response,
      // then throw an exception.
      throw Exception('Failed to load psychologists emails');
    }
  }

  Future<Psychologist> MakeDeclaration() async{
    final ioc = new HttpClient();
    ioc.badCertificateCallback =
        (X509Certificate cert, String host, int port) => true;
    final http = new IOClient(ioc);

    print(psyEmail);

    //String token = await getToken();
    final response = await http.post(Uri.https('10.0.2.2:44322', 'api/psychologists/declaration/'
        + psyEmail),
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + MyAppState.token
        });

    print("Token: ${MyAppState.token}");
    print(response.statusCode);
    print(response.body);

    if (response.statusCode == 200)
    {
      MyAppState.psychologistEmailOriginal = psyEmail.toString();
      Navigator.pop(context);
      Navigator.pop(context);
      Navigator.push(context, MaterialPageRoute(builder: (context) => NewNavBar()));
    }
    //print("DATA: ${data}");
  }

  Future ChangeSubscriptionSubmitWindowSubmit() async{
    final ioc = new HttpClient();
    ioc.badCertificateCallback =
        (X509Certificate cert, String host, int port) => true;
    final http = new IOClient(ioc);

    SharedPreferences pref = await SharedPreferences.getInstance();

    var mapeddate = {
      'email': MyAppState.emailOriginal,
      'firstName': MyAppState.firstNameOriginal,
      'lastName': MyAppState.lastNameOriginal,
      'phoneNumber': MyAppState.phoneNumberOriginal,
      'age': MyAppState.ageOriginal,
      'gender': MyAppState.genderOriginal,
      'psychologistEmail': psyEmail,
      'password': MyAppState.passwordOriginal
    };
    print("JSON DATA: ${mapeddate}");

    //mb fix
    var body = jsonEncode(mapeddate);

    print("JSON ENCODED DATA: ${body}");

    //String token = await getToken();
    final response = await http.put(Uri.https('10.0.2.2:44322', '/api/account/profile/update'),
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + MyAppState.token
        },
        body: body);

    print("Token: ${MyAppState.token}");
    print(pref.toString());
    print(response.statusCode);
    //print("DATA: ${data}");

    if (response.statusCode == 200)
    {
      MyAppState.psychologistEmailOriginal = psyEmail.toString();
      Navigator.pop(context);
      Navigator.pop(context);
      Navigator.push(context, MaterialPageRoute(builder: (context) => NewNavBar()));
    }
    else {
      //new Text("Invalid email or password");
    }


  }
}
