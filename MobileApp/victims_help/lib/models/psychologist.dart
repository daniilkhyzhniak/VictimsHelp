class Psychologist {
  String email;
  String firstName;
  String lastName;
  String phoneNumber;
  int age;
  String gender;


  Psychologist({this.firstName, this.lastName, this.phoneNumber, this.age, this.gender, this.email});

  factory Psychologist.fromJson(Map<String, dynamic> responseData) {
    return Psychologist(
      email: responseData['email'],
      firstName: responseData['firstName'],
      lastName: responseData['lastName'],
      phoneNumber: responseData['phoneNumber'],
      age: responseData['age'],
      gender: responseData['gender']
    );
  }
}