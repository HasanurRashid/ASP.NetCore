// See https://aka.ms/new-console-template for more information

using FactoryPattern;

CarFactory carFactory = new BMWFactory();

ICar car = carFactory.Create("White","XR00024",2000);
