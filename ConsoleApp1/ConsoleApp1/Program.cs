// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
List<awq> ht=new List<awq>();
for (int i=0; i<10;i++)
{
    for (int j = 0; j < 10; j++)
    {
        for (int k = 0; k < 10; k++)
        {
            var G = new awq()
            {
                b = k,
                d = j,
                c=i
            };
            ht.Add(G);

        }
    }


}
var e = ht.GroupBy(x => x.b).ToArray();
var f = e.Where(x => x.Key>3).SelectMany(x => x).ToArray();
Console.WriteLine("this!");
