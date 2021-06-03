class Message{
  String id;
  String senderEmail;
  String receiverEmail;
  String senderName;
  String text;
  String dateTime;

  Message({this.id, this.senderEmail, this.receiverEmail, this.senderName, this.text, this.dateTime});

  factory Message.fromJson(Map<String, dynamic> responseData) {
    return Message(
      id: responseData['id'],
      senderEmail: responseData['senderEmail'],
      receiverEmail: responseData['receiverEmail'],
      senderName: responseData['senderName'],
      text: responseData['text'],
      dateTime: responseData['dateTime']
    );
  }
}