# Old Phone keypad emulator
A C# library as an emulator for an old phone keypad to translate the input string of digits, spaces, asterisks, and which ends with a route, into a resulting output for sending over a phone.

![Buil and Test](https://github.com/AndrePann/old-phone-keypad-emulator/actions/workflows/dotnet.yml/badge.svg)

## Introduction
First of all, I would like to share my thoughts with them and explain why I chose the following implementation. 

There are several possible and correct solutions for every problem. Which one is the best in each individual case is always a question of preferences. 

The task is relatively simple, as it is a clearly defined data space with a fixed number of control characters.

My first thought was to take an event-oriented approach in order to stay as close as possible to a real device with the implementation. 

But I also didn't want to use an implementation technique just for its own sake. So I decided to use simple method calls. 

Since, as already mentioned, this is a fixed data space with a fixed number of control characters, I have also refrained from an implementation that provides classes derived from a base class for the individual operations. That was just too over sized for me.

I have also refrained from implementing a log output with Log4Net, because every exception is caught and returned as user info in the output.

## System requirements
* Visual Studio 2022
* .Net 7
* NUnit Framework
  * NUnit3TestAdapter
  * Microsoft.NET.Test.sdk

## Architecture
The solution consists of three projects. The OldPhone.Keypad.Emulator, it is an interface dll that contains all the processing logic and is used only via a public method OldPhonePad. The input string is passed to this method as a parameter and it returns the parsed string as the return value for as output.

The second project is a demo application in the form of an interactive console app with a menu navigation in two levels. The first level is for the execution of predefined inputs after selection and the second level is for the input of arbitrary inputs.

The third project contains the test implementation based on NUnit.

## Implementation
The implementation consists of an OldPhone class, which contains the processing logic, and an InputData class, which serves as the data model for the application.

## Application
The actual interface is the public method OldPhonePad, which expects a string as an input parameter and returns the resulting output as a string.

The validity of the input string is checked with a regular expression.

~~~
	var regExRule = @"(^([0-9 \* \#  ]+[\#(1,1)])$)";
~~~

## Description
### Key Pad Dictionary 
According to the specifications, a keypad with 12 keys was implemented. The 10 digit keys were mapped in a dictionary, as key-value pairs.

The 2 additional control keys, asterisk for backspace and route for send, are redirected into function calls. 

The key represents the key on the keypad and each character of the Value corresponds to a possible input value. The position of the character within the value string corresponds to the KeyModifire value.

This means that if a key is entered several times in series, the KeyModifire is incremented with each input.

~~~
        private static void InitKeyPadDictionary()
        {
            _keyPadDictionary = new Dictionary<string, string>();
            _keyPadDictionary.Add("0", "0 ");
            _keyPadDictionary.Add("1", "&'()*,-./1");
            _keyPadDictionary.Add("2", "ABC2");
            _keyPadDictionary.Add("3", "DEF3");
            _keyPadDictionary.Add("4", "GHI4");
            _keyPadDictionary.Add("5", "JKL5");
            _keyPadDictionary.Add("6", "MNO6");
            _keyPadDictionary.Add("7", "PQRS7");
            _keyPadDictionary.Add("8", "TUV8");
            _keyPadDictionary.Add("9", "WXYZ9");
        }
~~~

### Prepare Output Data
The KeyModifire value is incremented during processing of the input string if the CurrentKey == the LastKey.

### Process Backspace Key
If the CurrentKey is an asterisk (backspace control character), the KeyModifire value is decremented, the LastKey is deleted from the OriginInput, and the last key from the OriginInput after deletion is taken over as LastKey.

### Process Send Key
If the CurrentKey is a route (send key), the LastKey is processed and the output is returned.

If the CurrentKey != the LastKey and the LastKey != Space, or the CurrentKey == Space (timeout 1 second), then the value of the KeyModifire is evaluated and the referenced value from the dictionary is determined according to the LastKey and transferred to the output.

In order to determine the position of the required character in the value string, the length of the value string is first determined and the remainder of the division is calculated with the help of the modulo operator with the KeyModifire. If the remainder == 0, the position corresponds to the last character within the value string. Thus, any number of identical digits can be entered in succession, the correct result is always delivered as output.

### Allowed inputs
The input must begin with a digit or a space.
It can contain any number of digits or spaces.
One or more digits may be followed by a maximum of the same number of asterisks.

* Valid input
  * 22 22 22******2#
  * 22 22 ****22**2#
* Invalid input
  * 22 22*****2#
	
The route is only allowed as a final input. Each input must be terminated with a route.

## License
MIT
