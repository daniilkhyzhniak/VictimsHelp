class Event {
  final String summary;
  final String hangoutLink;
  final String start;
  final String end;

  Event({
    this.summary,
    this.hangoutLink,
    this.start,
    this.end,
  });

  factory Event.fromJson(Map<String, dynamic> json) {
    return Event(
      summary: json['summary'],
      hangoutLink: json['hangoutLink'],
      start: json['start'],
      end: json['end'],
    );
  }
}