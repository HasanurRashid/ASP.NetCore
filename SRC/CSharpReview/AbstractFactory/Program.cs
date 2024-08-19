// See https://aka.ms/new-console-template for more information

using AbstractFactory;
using AbstractFactory.BMW;

CarFactory carFactory = new BMWFactory();
IEngine engine = carFactory.CreateEngine();
ITire tire = carFactory.CreateTire();
IHeadLight headLight = carFactory.CreateHeadLight();