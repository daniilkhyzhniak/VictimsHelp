import '/models/article.dart';
class ArticleViewModel {
  final Article article;

  ArticleViewModel({this.article});

  String get title {
    return this.article.title;
  }
  String get text {
    return this.article.text;
  }
}