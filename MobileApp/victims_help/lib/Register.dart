/*
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:http/http.dart' as http;
import 'package:select_form_field/select_form_field.dart';


class RegisterForm extends StatefulWidget {
  const RegisterForm({Key key}) : super(key: key);

  @override
  _RegisterFormState createState() => _RegisterFormState();
}

class _RegisterFormState extends State<RegisterForm> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  bool _agreedToTOS = true;

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          TextFormField(
            decoration: const InputDecoration(
              labelText: 'First name',
            ),
            validator: (String value) {
              if (value.trim().isEmpty) {
                return 'First Name is required';
              }
            },
          ),
          TextFormField(
            decoration: const InputDecoration(
              labelText: 'Last name',
            ),
            validator: (String value) {
              if (value.trim().isEmpty) {
                return 'Last name is required';
              }
            },
          ),
          const SizedBox(height: 16.0),
          TextFormField(
            inputFormatters: [FilteringTextInputFormatter.digitsOnly],
            decoration: const InputDecoration(
              labelText: 'Phone number',
            ),
            validator: (String value) {
              if (value.trim().isEmpty) {
                return 'Phone number is required';
              }
            },
          ),
          TextFormField(
            inputFormatters: [FilteringTextInputFormatter.digitsOnly],
            decoration: const InputDecoration(
              labelText: 'Age',
            ),
            validator: (String value) {
              if (value.trim().isEmpty) {
                return 'Age is required';
              }
            },
          ),
          SelectFormField(
            type: SelectFormFieldType.dropdown,
            items: genders,
            decoration: const InputDecoration(
              labelText: 'Gender',
            ),
            validator: (String value) {
              if (value.trim().isEmpty) {
                return 'Gender is required';
              }
            },
          ),
          TextFormField(
            decoration: const InputDecoration(
              labelText: 'Email',
            ),
            validator: (String value) {
              if (value.trim().isEmpty) {
                return 'Email is required';
              }
            },
          ),
          TextFormField(
            decoration: const InputDecoration(
              labelText: 'Password',
            ),
            validator: (String value) {
              if (value.trim().isEmpty) {
                return 'Password is required';
              }
            },
          ),
          TextFormField(
            decoration: const InputDecoration(
              labelText: 'Confirm password',
            ),
            validator: (String value) {
              if (value.trim().isEmpty) {
                return 'Confirm password is required';
              }
            },
          ),
          Row(
            children: <Widget>[
              const Spacer(),
              OutlineButton(
                highlightedBorderColor: Colors.black,
                onPressed: _submit,
                child: const Text('Register'),
              ),
            ],
          ),
        ],
      ),
    );
  }

  void _submit() {
    _formKey.currentState.validate();
    print('Form submitted');
  }
}

final List<Map<String, dynamic>> genders = [
  {
    'value': 'M',
    'label': 'Male',
  },
  {
    'value': 'F',
    'label': 'Female',
  },
];

Map<String, String> params = {
  "first_name": v,
  "last_name": widget.mUserDetailsInputmodel.lastName,
  "email": widget.mUserDetailsInputmodel.emailAddress,
};

Future<String> multipartRequest({var url, var partParams}) async {
  Map<String, String> headers = {
    "X-API-KEY": X_API_KEY,
    "Accept": "application/json",
    "User-Auth-Token": authToken };
  var request = http.MultipartRequest("POST", Uri.parse(url));
  request.headers.addAll(headers);

  if (partParams != null) request.fields.addAll(partParams);// add part params if not null

  var response = await request.send();
  var responseData = await response.stream.toBytes();
  var responseString = String.fromCharCodes(responseData);
  print("responseBody " + responseString);
  if (response.statusCode == 200) return responseString;
 */