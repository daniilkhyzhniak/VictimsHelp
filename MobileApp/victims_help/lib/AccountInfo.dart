import 'dart:convert';

import 'package:http_client/http_client.dart' as http;
import 'package:http/io_client.dart';
import 'dart:io';

import 'package:victims_help/main.dart';
import 'package:victims_help/manageProfile/ChangeEmail.dart';
import 'manageProfile/ChangeName.dart';
import 'manageProfile/ChangePassword.dart';
import 'manageProfile/ChangeSubscription.dart';
import 'manageProfile/DeleteAccount.dart';
import 'models/user.dart';
import 'Registration.dart';
import 'Article_list.dart';
import 'Info.dart';
import 'Chat.dart';
import 'Calendar.dart';
import 'package:victims_help/Login.dart';
import 'package:flutter/services.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:select_form_field/select_form_field.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'InputDeco_design.dart';
import 'package:http/http.dart' as http;

class NewNavBar extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return NewNavBarState();
  }
}
class NewNavBarState extends State<NewNavBar> {
  int _selectedTab = 3;
  List<Widget> _pageOptions = [
    ArticleList(),
    //make chat
    ChatScreen(),
    CalendarTab(),
    AccountInfo(),
  ];

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
          primarySwatch: Colors.blue,
          primaryTextTheme: TextTheme(
            title: TextStyle(color: Colors.white),
          )),
      home: Scaffold(
        appBar: AppBar(
          title: Text('VictimsHelp'),
        ),
        body: _pageOptions[_selectedTab],
        bottomNavigationBar: BottomNavigationBar(
          unselectedItemColor: Colors.black45,
          selectedItemColor: Colors.blueAccent,
          currentIndex: _selectedTab,
          onTap: (int index) {
            setState(() {
              _selectedTab = index;
            });
          },
          items: [
            new BottomNavigationBarItem(
              icon: const Icon(Icons.info_outline),
              title: new Text('Info'),
              //backgroundColor: Colors.black,
            ),
            BottomNavigationBarItem(
              icon: Icon(Icons.forum),
              title: Text('Chat'),
            ),
            BottomNavigationBarItem(
              icon: Icon(Icons.event),
              title: Text('Calendar'),
            ),
            BottomNavigationBarItem(
              icon: Icon(Icons.account_circle),
              title: Text('Account'),
            ),
          ],
        ),
      ),
    );
  }
}

class AccountInfo extends StatefulWidget {
  @override
  AccountInfoState createState() => AccountInfoState();
}

class AccountInfoState extends State<AccountInfo> {
  static Future<User> futureUser;


  @override
  void initState() {
    super.initState();
    futureUser = GetAccountInfo();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: SingleChildScrollView(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
            new FutureBuilder<User>(
            future: futureUser,
                builder: (context, snapshot)
                {
                  if (snapshot.hasData) {
                    MyAppState.firstNameOriginal = snapshot.data.firstName;
                    MyAppState.lastNameOriginal = snapshot.data.lastName;
                    MyAppState.phoneNumberOriginal = snapshot.data.phoneNumber;
                    MyAppState.genderOriginal = snapshot.data.gender;
                    MyAppState.emailOriginal = snapshot.data.email;
                    MyAppState.ageOriginal = snapshot.data.age;
                    MyAppState.psychologistEmailOriginal = snapshot.data.psychologistEmail;
                  }
                  return  SizedBox(
                    height: 30,
                  );
                }
            ),
                new FutureBuilder<User>(
                  future: futureUser,
                  builder: (context, snapshot) {
                    if (snapshot.hasData) {
                      return Padding(
                          padding: EdgeInsets.all(20),
                          child: Align(
                              alignment: Alignment.topCenter,
                              child: Text(snapshot.data.firstName + " " + snapshot.data.lastName,
                                textAlign: TextAlign.center,
                                style: new TextStyle(fontSize:49.0,
                                    color: const Color(0xFF000000),
                                    fontWeight: FontWeight.w400,
                                    letterSpacing: 0.5,
                                    fontFamily: "Roboto"),
                              )
                          )
                      );
                    } else if (snapshot.hasError) {
                      return Text("${snapshot.error}");
                    }
                    // By default, show a loading spinner.
                    return CircularProgressIndicator();
                  },
                ),

                new FutureBuilder<User>(
                  future: futureUser,
                  builder: (context, snapshot) {
                    if (snapshot.hasData) {
                      return Padding(
                          padding: EdgeInsets.all(20),
                          child: Align(
                              alignment: Alignment.topCenter,
                              child: Text(snapshot.data.email,
                                style: new TextStyle(fontSize:24.0,
                                    color: const Color(0xFF000000),
                                    fontWeight: FontWeight.w300,
                                    fontFamily: "Roboto"),
                              )
                          )
                      );
                    } else if (snapshot.hasError) {
                      return Text("${snapshot.error}");
                    }

                    // By default, show a loading spinner.
                    return CircularProgressIndicator();
                  },
                ),

                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.blue,
                    onPressed: (){
                      Navigator.push(context, MaterialPageRoute(builder: (context) => ChangeName()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("Change name",
                    style: TextStyle(fontSize: 15),),

                  ),
                ),
                SizedBox(
                  height: 15,
                ),/*
                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.blue,
                    onPressed: (){
                      Navigator.push(context,  MaterialPageRoute(builder: (context) => ChangeEmail()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("Change email",
                    style: TextStyle(fontSize: 15),),

                  ),
                ),
                SizedBox(
                  height: 15,
                ),*/
                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.blue,
                    onPressed: (){
                      Navigator.push(context,  MaterialPageRoute(builder: (context) => ChangePassword()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("Change password",
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
                      Navigator.push(context,  MaterialPageRoute(builder: (context) => ChangeSubscriptionPlan()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("Change subscription plan",
                    style: TextStyle(fontSize: 15),
                  textAlign: TextAlign.center),

                  ),
                ),
                SizedBox(
                  height: 15,
                ),
                SizedBox(
                  width: 200,
                  height: 50,
                  child: RaisedButton(
                    color: Colors.red,
                    onPressed: (){
                      Navigator.push(context,  MaterialPageRoute(builder: (context) => DeleteAccount()));
                    },
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(50.0),
                        side: BorderSide(color: Colors.black45,width: 2)
                    ),
                    textColor:Colors.white,child: Text("Delete account",
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
                      MyAppState.token = null;
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => MyApp()),
                      );
                    },
                    child: const Text("Log out")
                )
              ],
            ),
          ),
        ),
      );
  }

  Future<User> GetAccountInfo() async {
  final ioc = new HttpClient();
  ioc.badCertificateCallback =
  (X509Certificate cert, String host, int port) => true;
  final http = new IOClient(ioc);

    SharedPreferences pref = await SharedPreferences.getInstance();

    //String token = await getToken();
    final response = await http.get(Uri.https('10.0.2.2:44322', '/api/account/profile'),
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + MyAppState.token
        },
    );

    if (response.statusCode == 200) {/*
      firstName = response.body.firstName;
      lastName = data.lastName;
      phoneNumber = data.phoneNumber;
      gender = data.gender;
      email = data.email;
      age = data.age;*/
      return User.fromJson(jsonDecode(response.body));
    } else {
      // If the server did not return a 200 OK response,
      // then throw an exception.
      throw Exception('Failed to load user');
    }

  }
}