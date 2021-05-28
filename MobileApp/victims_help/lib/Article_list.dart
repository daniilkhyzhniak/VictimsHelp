import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'models/article.dart';
import 'dart:async';
import 'dart:convert';

class ArticleList extends StatefulWidget {
  @override
  _ArticleListState createState() => _ArticleListState();
}

Future<Article> fetchArticleList(int index) async {
  final response =
  await http.get(Uri.https('localhost:44322', 'api/articles/'));

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    print(jsonDecode(response.body[1]));
    return Article.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load article list');
  }
}

class _ArticleListState extends State<ArticleList> {
  //final ArticleListType type;
  Future<Article> futureArticle;

  @override
  Widget build(BuildContext context) {
    print(fetchArticleList(1));
    return Scaffold(
      body: Scrollbar(
        child: ListView(
          restorationId: 'list_demo_list_view',
          padding: const EdgeInsets.symmetric(vertical: 8),
          children: [
            for (int index = 0; index < 1; index++)
              FutureBuilder<Article>(
                future: futureArticle = fetchArticleList(index),
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
              )

          ],
        ),
      ),
    );
  }
}

