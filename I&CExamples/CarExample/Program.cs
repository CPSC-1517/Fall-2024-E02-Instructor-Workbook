// See https://aka.ms/new-console-template for more information

using I_CExamples;

Car myCar = new Car();
Motorcycle myRide = new Motorcycle();

Console.WriteLine($"Car Cylinders: {myCar.Cylinders}");

//
Console.WriteLine($"Car Wheels: {myCar.Wheels}");

Console.WriteLine($"Motorcycle Wheels: {myRide.Wheels}");

//Cannot access Cylinder from Motorcycle
Console.WriteLine($"Motorcycle Cylinders: {myRide.Make}");

Console.ReadLine();
