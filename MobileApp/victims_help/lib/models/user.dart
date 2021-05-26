class User {
  int userId;
  String firstName;
  String lastName;
  String phone;
  String age;
  String gender;
  String email;
  String type;
  String token;
  String renewalToken;

  User({this.userId, this.firstName, this.lastName, this.phone, this.age, this.gender, this.email, this.type, this.token, this.renewalToken});

  factory User.fromJson(Map<String, dynamic> responseData) {
    return User(
        userId: responseData['id'],
        firstName: responseData['firstName'],
        lastName: responseData['lastName'],
        phone: responseData['phone'],
        age: responseData['age'],
        gender: responseData['gender'],
        email: responseData['email'],
        type: responseData['type'],
        token: responseData['access_token'],
        renewalToken: responseData['renewal_token']
    );
  }
}