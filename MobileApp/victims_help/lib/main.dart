import 'package:flutter/material.dart';
import 'package:victims_help/Login.dart';
import 'Info.dart';
import 'Chat.dart';
import 'Calendar.dart';
import 'Account.dart';
import 'package:flutter_local_notifications/flutter_local_notifications.dart';

void main() => runApp(new MyApp());
class MyApp extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return MyAppState();
  }
}
class MyAppState extends State<MyApp> {
  FlutterLocalNotificationsPlugin flutterLocalNotificationsPlugin =
  new FlutterLocalNotificationsPlugin();
  var initializationSettingAndroid;
  var initializationSetting;
  void _showNotification(){

  }
  @override
  void initState() {
    super.initState();
    initializationSettingAndroid = new AndroidInitializationSettings('defaultIcon');
  }

  Future onDidReceiveLocalNotification(
      int id, String title, String body, String payload) async{

  }

  int _selectedTab = 0;
  final _pageOptions = [
    InfoTab(),
    ChatScreen(),
    CalendarTab(),
    LoginTab(),
  ];
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
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
  }}