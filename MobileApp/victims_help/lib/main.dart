import 'package:flutter/material.dart';
import 'package:victims_help/Article_list.dart';
import 'package:victims_help/Registration.dart';
import 'package:victims_help/Login.dart';
import 'Info.dart';
import 'Chat.dart';
import 'Calendar.dart';
import 'AccountInfo.dart';
import 'package:provider/provider.dart';
//import 'package:flutter_local_notifications/flutter_local_notifications.dart';
import 'package:http/http.dart' as http;

void main() => runApp(new MyApp());



class MyApp extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return MyAppState();
  }
}
class MyAppState extends State<MyApp> {
  static String token;
  static String firstNameOriginal;
  static String lastNameOriginal;
  static String phoneNumberOriginal;
  static String genderOriginal;
  static String emailOriginal;
  static int ageOriginal;
  static String psychologistEmailOriginal;
  static String passwordOriginal;

  static void getInfo() {
    print("Token: " + MyAppState.token);
    print("First name: " + MyAppState.firstNameOriginal);
    print("Last name: " + MyAppState.lastNameOriginal);
    print("Phone number: " + MyAppState.phoneNumberOriginal);
    print("Gender: " + MyAppState.genderOriginal);
    print("Email: " + MyAppState.emailOriginal);
    print("Age: " + MyAppState.ageOriginal.toString());
    print("Psy email: " + MyAppState.psychologistEmailOriginal.toString());
    print("Password: " + MyAppState.passwordOriginal);
  }

  int _selectedTab = 3;
  List<Widget> _pageOptions = [
    ArticleList(),
    //make chat
    ChatScreen(),
    CalendarTab(),
    Registration(),
  ];

  void changeToAccountInfo() {
    _pageOptions[3] = AccountInfo();
  }

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
        //name of the app at the top
        appBar: AppBar(
          title: Text('VictimsHelp'),
        ),
        //array for switching between pages
        body: _pageOptions[_selectedTab],
        bottomNavigationBar: BottomNavigationBar(
          unselectedItemColor: Colors.black45,
          selectedItemColor: Colors.blueAccent,
          currentIndex: _selectedTab,
          onTap: (int index) {
            setState(() {
              //changing the tab when the user taps on the icons
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