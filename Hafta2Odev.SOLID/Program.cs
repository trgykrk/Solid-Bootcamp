
using Hafta2Odev.SOLID;
using Hafta2Odev.SOLID.SingleResponsibility;
using Hafta2Odev.SOLID.OpenClosed;
using Hafta2Odev.SOLID.Liskov;
using Hafta2Odev.SOLID.InterfaceSegregation;
using Hafta2Odev.SOLID.DependencyInversion;

Console.WriteLine("SOLID Principles:");
var principles = new List<IPrinciple>()
            {
                new SingleResponsibility(),
                new OpenClosed(),
                new Liskov(),
                new InterfaceSegragation(),
                new DependencyInversion()
            };
principles.ForEach(type =>
{
    Console.WriteLine($"- {type.Principle()}");
});
Console.Read();