using Paralimpia;
using System.Text;

List<SportEvent> events = new List<SportEvent>();
using StreamReader sr = new StreamReader(@"../../../src/paralympics.txt", Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    events.Add(new SportEvent(sr.ReadLine()));
}

//foreach (var e in events)
//{
//    Console.WriteLine($"{e.Year} {e.Country} {e.City}");
//    foreach (var medal in e.Medals)
//    {
//        Console.WriteLine($"  {medal.Key}: {medal.Value}");
//    }
//}

var f1 = events.Count();
Console.WriteLine($"1.Feladat: {f1}");

var f2 = events.Sum(e => e.Medals.Values.Sum());
Console.WriteLine($"2.Feladat: {f2}");

var f3 = events.Where(e => e.Medals.Values.All(v => v == 0));
Console.WriteLine("3.Feladat:");
foreach (var e in f3) Console.WriteLine($"\t{e.City}, {e.Year};");

var f4 = events.GroupBy(e => e.Country).Where(g => g.Count() > 1);
Console.WriteLine("4.Feladat:");
foreach (var g in f4) Console.WriteLine($"\t{g.Key}: ({g.Count()} alkalommal)");

Console.Write("5.Feladat: Adjon meg egy évet: ");
bool val = int.TryParse(Console.ReadLine(), out int y);
if (!val)
{
    Console.WriteLine("Hibás adat!");
    return;
}
var f5 = events.SingleOrDefault(e => e.Year == y);
if (f5 is null)
{
    Console.WriteLine($"Nem volt paralimpia {y}-ban-ben");
    return;
}
Console.WriteLine(f5);
