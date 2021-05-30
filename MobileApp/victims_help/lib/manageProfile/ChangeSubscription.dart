import 'dart:convert';
import 'dart:io';

import 'package:victims_help/manageProfile/ChangeSubscriptionSubmitWindow.dart';
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

class ChangeSubscriptionPlan extends StatefulWidget {
  @override
  ChangeSubscriptionPlanState createState() => ChangeSubscriptionPlanState();
}

class ChangeSubscriptionPlanState extends State<ChangeSubscriptionPlan> {
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
                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.blue,
                    onPressed: (){
                      Navigator.push(context, MaterialPageRoute(builder: (context) => ChangeSubscriptionSubmitWindow()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("5\$ for 1 month",
                    style: TextStyle(fontSize: 15),),

                  ),
                ),
                SizedBox(
                  height: 15,
                ),
                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.blue,
                    onPressed: (){
                      Navigator.push(context, MaterialPageRoute(builder: (context) => ChangeSubscriptionSubmitWindow()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("12\$ for 3 months",
                    style: TextStyle(fontSize: 15),),

                  ),
                ),
                SizedBox(
                  height: 15,
                ),
                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.blue,
                    onPressed: (){
                      Navigator.push(context, MaterialPageRoute(builder: (context) => ChangeSubscriptionSubmitWindow()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("20\$ for 6 months",
                    style: TextStyle(fontSize: 15),),

                  ),
                ),
                SizedBox(
                  height: 15,
                ),
                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.blue,
                    onPressed: (){
                      Navigator.push(context, MaterialPageRoute(builder: (context) => ChangeSubscriptionSubmitWindow()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("35\$ for 6 months",
                    style: TextStyle(fontSize: 15),),

                  ),
                ),
                SizedBox(
                  height: 15,
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

}
