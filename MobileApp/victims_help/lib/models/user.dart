class User {
  int userId;
  String firstName;
  String lastName;
  String phoneNumber;
  int age;
  String gender;
  String email;
  String password;
  String confirmPassword;
  String token;
  String renewalToken;

  User({this.userId, this.firstName, this.lastName, this.phoneNumber, this.age, this.gender, this.email, this.password, this.confirmPassword, this.token, this.renewalToken});

  factory User.fromJson(Map<String, dynamic> responseData) {
    return User(
        userId: responseData['id'],
        firstName: responseData['firstName'],
        lastName: responseData['lastName'],
        phoneNumber: responseData['phoneNumber'],
        age: responseData['age'],
        gender: responseData['gender'],
        email: responseData['email'],
        password: responseData['password'],
        confirmPassword: responseData['confirmPassword'],
        token: responseData['access_token'],
        renewalToken: responseData['renewal_token']
    );
  }
}