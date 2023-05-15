using AdapterPattern;

var detector = new Detector(new InternetThermometerAdapter(new InternetThermometer()));
Console.WriteLine(detector.GetDecision());

//var detector = new Detector(new MercuryThermometer());

//for (var i = 0; i < 10; i++)
//{
//    Console.WriteLine(detector.GetDecision());
//}