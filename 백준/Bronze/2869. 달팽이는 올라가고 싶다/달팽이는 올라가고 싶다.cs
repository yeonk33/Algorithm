string[] inputStr = Console.ReadLine().Split(' ');
double climb = Convert.ToDouble(inputStr[0]);
double slip = Convert.ToDouble(inputStr[1]);
double height = Convert.ToDouble(inputStr[2]);
int day = 0;

day = (int)Math.Ceiling((height-slip)/(climb-slip));
System.Console.WriteLine(day);