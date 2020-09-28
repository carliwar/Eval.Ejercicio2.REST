# Eval.Ejercicio2.REST

This project is built in:
 - .Net Framework 4.7.2
 - REST Web API. 
 - MSTESTS with NSubstitute for mocking interfaces
 - Client uses RESTSHARP to consume exposed method.

REST method to process Personas and return only whose are Females and have at least 18 years old.
To run the program you have to set these two projects to start when debugging:
- Eval.Ejercicio2.REST
- Eval.Ejercicio2.Client

Client has 5 covered test cases on the Main call.
