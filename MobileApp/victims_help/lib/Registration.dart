import 'dart:convert';
import 'dart:io';

import 'AccountInfo.dart';
import 'main.dart';
import 'package:victims_help/Login.dart';
import 'package:flutter/services.dart';
import 'package:flutter/material.dart';
import 'package:select_form_field/select_form_field.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'InputDeco_design.dart';
import 'package:http/http.dart' as http;

class Registration extends StatefulWidget {
  @override
  RegistrationState createState() => RegistrationState();
}

class RegistrationState extends State<Registration> {
    //String firstName, lastName, phoneNumber, gender, email;
    //int age;


  //TextController to read text entered in text field
  TextEditingController firstName = TextEditingController();
  TextEditingController lastName = TextEditingController();
  TextEditingController phoneNumber = TextEditingController();
  TextEditingController age = TextEditingController();
  TextEditingController gender = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController password = TextEditingController();
  TextEditingController confirmpassword = TextEditingController();

  //TextEditingController get firstName => this.firstName;

  final GlobalKey<FormState> _formkey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: SingleChildScrollView(
          child: Form(
            key: _formkey,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text(
                  "Registration",
                  style: new TextStyle(fontSize: 32)
                ),
                SizedBox(
                  height: 30,
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom:15,left: 10,right: 10),
                  child: TextFormField(
                    controller: firstName,
                    keyboardType: TextInputType.text,
                    decoration: buildInputDecoration(Icons.person,"First name"),
                    validator: (String value){
                      if(value.isEmpty)
                      {
                        return 'Please enter your first name';
                      }
                      return null;
                    },/*
                    onSaved: (String value){
                      firstName.text = value;
                    },*/
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom:15,left: 10,right: 10),
                  child: TextFormField(
                    controller: lastName,
                    keyboardType: TextInputType.text,
                    decoration: buildInputDecoration(Icons.person,"Last name"),
                    validator: (String value){
                      if(value.isEmpty)
                      {
                        return 'Please enter your last name';
                      }
                      return null;
                    },/*
                    onSaved: (String value){
                      lastName.text = value;
                    },*/
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom: 15,left: 10,right: 10),
                  child: TextFormField(
                    controller: phoneNumber,
                    keyboardType: TextInputType.number,
                    inputFormatters: [FilteringTextInputFormatter.digitsOnly],
                    decoration:buildInputDecoration(Icons.phone,"Phone number"),
                    validator: (String value){
                      if(value.isEmpty)
                      {
                        return 'Please enter your phone number';
                      }
                      return null;
                    },/*
                    onSaved: (String value){
                      phoneNumber.text = value;
                    },*/
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom: 15,left: 10,right: 10),
                  child: TextFormField(
                    controller: age,
                    keyboardType: TextInputType.number,
                    inputFormatters: [FilteringTextInputFormatter.digitsOnly],
                    decoration:buildInputDecoration(Icons.access_time,"Age"),
                    validator: (String value){
                      if(value.isEmpty)
                      {
                        return 'Please enter your age';
                      }
                      if(int.parse(value) < 0)
                      {
                        return 'Please enter a valid age';
                      }
                      return null;
                    },/*
                    onSaved: (String value){
                      age = int.parse(value);
                    },*/
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom: 15,left: 10,right: 10),
                  child: SelectFormField(
                    controller: gender,
                    type: SelectFormFieldType.dropdown,
                    items: genders,
                    decoration:buildInputDecoration(Icons.wc,"Gender"),
                    validator: (String value){
                      if (value.isEmpty)
                      {
                        return 'Gender is required';
                      }
                      return null;
                    },/*
                    onSaved: (String value){
                      gender.text = value;
                    },*/
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom: 15,left: 10,right: 10),
                  child: TextFormField(
                    controller: email,
                    keyboardType: TextInputType.text,
                    decoration:buildInputDecoration(Icons.email,"Email"),
                    validator: (String value){
                      if(value.isEmpty)
                      {
                        return 'Please enter your email';
                      }
                      if(!RegExp("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+.[a-z]").hasMatch(value)){
                        return 'Please enter a valid email';
                      }
                      return null;
                    },/*
                    onSaved: (String value){
                      email.text = value;
                    },*/
                  ),
                ),

                Padding(
                  padding: const EdgeInsets.only(bottom: 15,left: 10,right: 10),
                  child: TextFormField(
                    controller: password,
                    obscureText: true,
                    keyboardType: TextInputType.text,
                    decoration:buildInputDecoration(Icons.lock,"Password"),
                    validator: (String value){
                      if(value.isEmpty)
                      {
                        return 'Please enter your password';
                      }
                      return null;
                    },

                  ),
                ),
                Padding(
                  padding: const EdgeInsets.only(bottom: 15,left: 10,right: 10),
                  child: TextFormField(
                    controller: confirmpassword,
                    obscureText: true,
                    keyboardType: TextInputType.text,
                    decoration:buildInputDecoration(Icons.lock,"Confirm password"),
                    validator: (String value){
                      if(value.isEmpty)
                      {
                        return 'Please re-enter your password';
                      }
                      print(password.text);

                      print(confirmpassword.text);

                      if(password.text!=confirmpassword.text){
                        return "Passwords do not match";
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
                        Registration();
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
                    textColor:Colors.white,child: Text("Register",
                  style: TextStyle(fontSize: 15),),

                  ),
                ),
                SizedBox(
                  height: 15,
                ),
                TextButton(
                  style: TextButton.styleFrom(
                    textStyle: const TextStyle(
                        fontSize:20.0,
                        color: Colors.blue,
                        fontWeight: FontWeight.w400,
                        letterSpacing: 0.5,
                        fontFamily: "Roboto"
                    ),

                ),
                  onPressed: () {
                    //builder: (context) => LoginState();
                    Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => Login()),
                    );
                  },
                  child: const Text("Already have an account? Log in here")
                )
              ],
            ),
          ),
        ),
      ),
    );
  }

    final List<Map<String, dynamic>> genders = [
      {
        'value': 'M',
        'label': 'Male',
      },
      {
        'value': 'F',
        'label': 'Female',
      },
    ];

  Future Registration() async{
    SharedPreferences pref = await SharedPreferences.getInstance();

      var mapeddate = {
        'firstName': firstName.text,
        'lastName': lastName.text,
        'phoneNumber': phoneNumber.text,
        'age': int.parse(age.text),
        'gender': gender.text,
        'email': email.text,
        'password': password.text,
        'confirmPassword': confirmpassword.text
      };
      print("JSON DATA: ${mapeddate}");

      //mb fix
      var body = jsonEncode(mapeddate);

      print("JSON ENCODED DATA: ${body}");

      //String token = await getToken();
        http.Response response = await http.post(Uri.https('localhost:44322', '/api/account/register'),
            headers: {"Content-Type": "application/json-patch+json"},
            //HttpHeaders.authorizationHeader: "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZW1haWxAdGV4dC5jb20iLCJJZCI6IjFiZTMwN2NmLTVmMTktNGE4OS01MWQyLTA4ZDkyMWJjOTc0NCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkNsaWVudCIsIm5iZiI6MTYyMjE5NDg0MiwiZXhwIjoxNjIyNjI2ODQyLCJpc3MiOiJWaWN0aW1zSGVscCJ9.nAjKD3UsMTGc9kpJCwTgB1vsTJHhPzTFND7dHTnF2kM"},
            body: body);
        //var data = jsonDecode(response.body);
        MyAppState.token = response.body;

    if (response.statusCode == 200)
    {
      MyAppState.passwordOriginal = password.text;
      Navigator.push(context, MaterialPageRoute(builder: (context) => NewNavBar()));
    }
        print(MyAppState.token);
        print(pref.toString());
        print(response.statusCode);
        //print("DATA: ${data}");




  }
}