import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import 'package:http_client/http_client.dart' as http;
import 'package:http/io_client.dart';
import 'dart:io';

import 'package:victims_help/Info.dart';
import 'models/article.dart';
import 'dart:async';
import 'dart:convert';

class ArticleList extends StatefulWidget {
  @override
  ArticleListState createState() => ArticleListState();
}

Future<Article> fetchArticleList(int index) async {
  final ioc = new HttpClient();
  ioc.badCertificateCallback =
      (X509Certificate cert, String host, int port) => true;
  final http = new IOClient(ioc);

  final response =
  await http.get(Uri.https('10.0.2.2:44322', 'api/articles/'));

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    print(jsonDecode(response.body)[1]);
    return Article.fromJson(jsonDecode(response.body)[index]);
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load article list');
  }
}

Future getArticleListLength() async {
  final ioc = new HttpClient();
  ioc.badCertificateCallback =
      (X509Certificate cert, String host, int port) => true;
  final http = new IOClient(ioc);

  final response =
  await http.get(Uri.https('10.0.2.2:44322', 'api/articles/'));

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    print(jsonDecode(response.body)[1]);
    return response.body.length;
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load article list');
  }
}

class ArticleListState extends State<ArticleList> {
  //final ArticleListType type;
  Future<Article> futureArticle;
  Future articleLength;
  static String ArticleId;
  @override
  void initState() {
    super.initState();
  }


  @override
  Widget build(BuildContext context) {
    print(fetchArticleList(1));
    return Scaffold(
      body: Scrollbar(
        child: ListView(
          restorationId: 'list_demo_list_view',
          padding: const EdgeInsets.symmetric(vertical: 8),
          children: [
            /*
            FutureBuilder(
              future: articleLength = getArticleListLength(),
                builder: (context, snapshot) {
                  if (snapshot.hasData) {
                    articleLength = snapshot.data;
                  }
                  return null;
                }),
            */
            for (int index = 0; index < 10; index++)
              FutureBuilder<Article>(
                future: futureArticle = fetchArticleList(index),
                builder: (context, snapshot) {
                  if (snapshot.hasData) {
                    return Padding(
                        padding: EdgeInsets.all(20),
                        child: Align(
                            alignment: Alignment.topLeft,
                            child: TextButton(
                              style: TextButton.styleFrom(
                                  textStyle: const TextStyle( fontSize:30.0,
                                  color: const Color(0xFF000000),
                                  fontWeight: FontWeight.w400,
                                  letterSpacing: 0.5,
                                  fontFamily: "Roboto"),
                              ),
                              onPressed: () {
                                ArticleId = snapshot.data.id;
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(builder: (context) => InfoTab()),
                                );
                              },
                              child: new Text(snapshot.data.title)
                            )
                        )

                    );
                  } else if (snapshot.hasError) {
                    return Text("");// Text("${snapshot.error}");
                  }

                  // By default, show a loading spinner.
                  return LinearProgressIndicator();
                },
              )

          ],
        ),
      ),
    );
  }
}

