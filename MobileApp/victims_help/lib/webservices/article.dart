import 'dart:convert';
import '/models/article.dart';
import 'package:http/http.dart' as http;

class Webservice {

  Future<List<Article>> fetchArticles(String id) async {

    final response = await http.get(Uri.https('localhost:44322', 'api/articles/$id'));
    if(response.statusCode == 200) {

      final body = jsonDecode(response.body);
      final Iterable json = body["Search"];
      return json.map((article) => Article.fromJson(article)).toList();

    } else {
      throw Exception("Unable to perform request!");
    }
  }
}