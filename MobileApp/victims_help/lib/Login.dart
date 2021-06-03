import 'dart:convert';

import 'package:http_client/http_client.dart' as http;
import 'package:http/io_client.dart';
import 'dart:io';

import 'main.dart';
import 'Registration.dart';
import 'package:flutter/services.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:select_form_field/select_form_field.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'InputDeco_design.dart';
import 'AccountInfo.dart';
import 'package:http/http.dart' as http;

class Login extends StatefulWidget {
  @override
  LoginState createState() => LoginState();
}

class LoginState extends State<Login> {
  //TextController to read text entered in text field
  bool emailExists = false;
  TextEditingController email = TextEditingController();
  TextEditingController password = TextEditingController();

  final GlobalKey<FormState> _formkey = GlobalKey<FormState>();

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
          child: Form(
            key: _formkey,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text(
                    "Login",
                    style: new TextStyle(fontSize: 32)
                ),
                SizedBox(
                  height: 30,
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom: 15,left: 10,right: 10),
                  child: TextFormField( //text form for login
                    controller: email,
                    keyboardType: TextInputType.text,
                    decoration:buildInputDecoration(Icons.email,"Email"),
                    validator: (String value){
                      //checking if the email is empty
                      if(value.isEmpty)
                      {
                        return 'Please enter your email';
                      }
                      //checking for valid email
                      if(!RegExp("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+.[a-z]").hasMatch(value)){
                        return 'Please enter a valid email';
                      }
                      return null;
                    },
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom: 15,left: 10,right: 10),
                  child: TextFormField( //text form for password
                    controller: password,
                    obscureText: true,
                    keyboardType: TextInputType.text,
                    decoration:buildInputDecoration(Icons.lock,"Password"),
                    validator: (String value){
                      //checking if the password is empty
                      if(value.isEmpty)
                      {
                        return 'Please enter your password';
                      }
                      return null;
                    },
                  ),
                ),
                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.redAccent,
                    onPressed: (){

                      if(_formkey.currentState.validate())
                      {
                        emailExists = false;
                        LoginSubmit();
                        print("Successful");

                          return;
                      }else{
                        print("Failed");
                      }
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.blue,width: 2)
                    ),
                    textColor:Colors.white,child: Text("Login",
                    style: TextStyle(fontSize: 15),),

                  ),
                ),
              ],
            ),
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

  Future LoginSubmit() async{
    final ioc = new HttpClient();
    ioc.badCertificateCallback =
        (X509Certificate cert, String host, int port) => true;
    final http = new IOClient(ioc);

    SharedPreferences pref = await SharedPreferences.getInstance();

    var mapeddate = {
      'email': email.text,
      'password': password.text
    };
    print("JSON DATA: ${mapeddate}");

    //mb fix
    var body = jsonEncode(mapeddate);

    print("JSON ENCODED DATA: ${body}");

    //String token = await getToken();
    final response = await http.post(Uri.https('10.0.2.2:44322', '/api/account/login'),
        headers: {"Content-Type": "application/json-patch+json"},
        //HttpHeaders.authorizationHeader: "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZW1haWxAdGV4dC5jb20iLCJJZCI6IjFiZTMwN2NmLTVmMTktNGE4OS01MWQyLTA4ZDkyMWJjOTc0NCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkNsaWVudCIsIm5iZiI6MTYyMjE5NDg0MiwiZXhwIjoxNjIyNjI2ODQyLCJpc3MiOiJWaWN0aW1zSGVscCJ9.nAjKD3UsMTGc9kpJCwTgB1vsTJHhPzTFND7dHTnF2kM"},
        body: body);
    //var data = jsonDecode(response.body);


    //print("DATA: ${data}");

    if (response.statusCode == 200)
      {
        MyAppState.token = response.body;
          MyAppState.passwordOriginal = password.text;
          Navigator.push(context, MaterialPageRoute(builder: (context) => NewNavBar()));
      }
    else {
      //new Text("Invalid email or password");
    }
    print("Token: ${MyAppState.token}");
    print(pref.toString());
    print(response.statusCode);

  }
}
