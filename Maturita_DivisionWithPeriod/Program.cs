FunkyCalculator c = new FunkyCalculator();

Console.WriteLine("0.(3) =\t" + c.DivideWithPeriod(1,3));
Console.WriteLine("1.(285714) =\t" + c.DivideWithPeriod(9,7));
Console.WriteLine("0.9(7826086956521739130434) =\t" + c.DivideWithPeriod(45,46));
Console.WriteLine("4.4 =\t" + c.DivideWithPeriod(22,5));
Console.WriteLine(c.DivideWithPeriod(79115,6842));
//79115 / 6842

