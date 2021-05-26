import 'dart:async';
import 'dart:convert';
import 'models/article.dart';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

Future<Article> fetchArticle() async {
  final response =
  await http.get(Uri.https('localhost:44322', 'api/articles/72fe5af5-2a2f-4292-90c0-03aed8671ff0'));

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return Article.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load Article');
  }
}

void main() => runApp(InfoTab());

class InfoTab extends StatefulWidget {

  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<InfoTab> {
  Future<Article> futureArticle;

  @override
  void initState() {
    super.initState();
    futureArticle = fetchArticle();
  }

  @override
  Widget build(BuildContext context) {
    return new Scaffold(
      body:
      new Column(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: <Widget>[
            new FutureBuilder<Article>(
              future: futureArticle,
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  return Padding(
                      padding: EdgeInsets.all(20),
                      child: Align(
                          alignment: Alignment.topCenter,
                          child: Text(snapshot.data.title,
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

            new FutureBuilder<Article>(
              future: futureArticle,
              builder: (context, snapshot) {
                if (snapshot.hasData) {
                  return Padding(
                      padding: EdgeInsets.all(20),
                      child: Align(
                          alignment: Alignment.topCenter,
                          child: Text("           " + snapshot.data.text,
                          style: new TextStyle(fontSize:24.0,
                              color: const Color(0xFF000000),
                              fontWeight: FontWeight.w200,
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
          ]

      ),

    );
  }
}