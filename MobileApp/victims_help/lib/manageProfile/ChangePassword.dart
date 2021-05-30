import 'dart:convert';
import 'dart:io';

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

class ChangePassword extends StatefulWidget {
  @override
  ChangePasswordState createState() => ChangePasswordState();
}

class ChangePasswordState extends State<ChangePassword> {
  //TextController to read text entered in text field
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
                    "Change password",
                    style: new TextStyle(fontSize: 32)
                ),
                SizedBox(
                  height: 30,
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom:15,left: 10,right: 10),
                  child: TextFormField(
                    controller: password,
                    keyboardType: TextInputType.text,
                    decoration: buildInputDecoration(Icons.person, "New password"),
                    validator: (String value){
                      if(value.isEmpty)
                      {
                        return 'Please enter your new password';
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
                        ChangeNameSubmit();
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
                    textColor:Colors.white,child: Text("Change password",
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

  Future ChangeNameSubmit() async{
    SharedPreferences pref = await SharedPreferences.getInstance();

    var mapeddate = {
      'email': MyAppState.emailOriginal,
      'firstName': MyAppState.firstNameOriginal,
      'lastName': MyAppState.lastNameOriginal,
      'phoneNumber': MyAppState.phoneNumberOriginal,
      'age': MyAppState.ageOriginal,
      'gender': MyAppState.genderOriginal,
      'psychologistEmail': MyAppState.psychologistEmailOriginal,
      'password': password.text
    };
    print("JSON DATA: ${mapeddate}");

    //mb fix
    var body = jsonEncode(mapeddate);

    print("JSON ENCODED DATA: ${body}");

    //String token = await getToken();
    http.Response response = await http.put(Uri.https('localhost:44322', '/api/account/profile/update'),
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

    if (response.statusCode == 200 || response.statusCode == 405)
    {
      MyAppState.passwordOriginal = password.text;
      Navigator.pop(context);
      Navigator.pop(context);
      Navigator.push(context, MaterialPageRoute(builder: (context) => NewNavBar()));
    }
    else {
      //new Text("Invalid email or password");
    }


  }
}
