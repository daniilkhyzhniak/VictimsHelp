class Article {
  final String id;
  final String title;
  final String text;

  Article({
    this.id,
    this.title,
    this.text,
  });

  factory Article.fromJson(Map<String, dynamic> json) {
    return Article(
        id: json['id'],
        title: json['title'],
        text: json['text'],
    );
  }
}