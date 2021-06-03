import 'dart:async';
import 'dart:convert';
import 'models/article.dart';

import 'package:http_client/http_client.dart' as http;
import 'package:http/io_client.dart';
import 'dart:io';

import 'Article_list.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

Future<Article> fetchArticle(String id) async {
  final ioc = new HttpClient();
  ioc.badCertificateCallback =
      (X509Certificate cert, String host, int port) => true;
  final http = new IOClient(ioc);

  final response =
  await http.get(Uri.https('10.0.2.2:44322', 'api/articles/' + id));

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

void main() => runApp(MaterialApp(home:InfoTab()));

class InfoTab extends StatefulWidget {

  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<InfoTab> {
  Future<Article> futureArticle;

  @override
  void initState() {
    super.initState();
    futureArticle = fetchArticle(ArticleListState.ArticleId);
  }

  @override
  Widget build(BuildContext context) {
    return new Scaffold(
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
          ]

      ),
    )
      )

    );
  }
}