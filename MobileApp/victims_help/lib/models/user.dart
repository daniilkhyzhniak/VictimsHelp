class User {
  String firstName;
  String lastName;
  String phoneNumber;
  int age;
  String gender;
  String psychologistEmail;
  String email;
  String password;
  String confirmPassword;

  User({this.firstName, this.lastName, this.phoneNumber, this.age, this.gender, this.psychologistEmail, this.email, this.password, this.confirmPassword});

  factory User.fromJson(Map<String, dynamic> responseData) {
    return User(
        firstName: responseData['firstName'],
        lastName: responseData['lastName'],
        phoneNumber: responseData['phoneNumber'],
        age: responseData['age'],
        gender: responseData['gender'],
        psychologistEmail: responseData['psychologistEmail'],
        email: responseData['email'],
        password: responseData['password'],
        confirmPassword: responseData['confirmPassword'],
    );
  }
}