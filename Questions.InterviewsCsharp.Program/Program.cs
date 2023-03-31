// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using Questions.Interviews_CSharp;
using Questions.Interviews_CSharp.DesignPatterns.Creation;


var webServiceHelper = WebServiceHelper.Instance;

WebServiceHelper.ConnectToServer();

// Test
//Console.WriteLine("A.Test(1, 5) " + Exercises.Test(1, 5) );
//Console.WriteLine("A.Test(2, 3) " + Exercises.Test(2, 3) );
//Console.WriteLine("A.Test(-3, 4) " + Exercises.Test(-3, 4) );

// GetPositionAt
//Console.WriteLine("GetPositionAt(3) " + Exercises.GetPositionAt(3));
//Console.WriteLine("GetPositionAt(100000) " + Exercises.GetPositionAt(100000));
//Console.WriteLine("GetPositionAt(2147483647) " + Exercises.GetPositionAt(2147483647));

//string[] data = new string[]{ "Ab", "bc", "cd", "oz"}; // Abcz
//string[] data2 = new string[] { "*====#", "X-+-+-+-+-+-Z", "#______X", "A.......*" };

////A.......*====#______X______JX-+-+-+-+-+-Z
//string[] data3 = new string[] { "*====#", "X-+-+-+-+-+-Z", "#______X" , "A.......*" };

//A.......*====#______X-+-+-+-+-+-Z
//Console.WriteLine("FindSmallestInterval() " + Exercises.StringPalindrome("a man"));
//Console.WriteLine("FindSmallestInterval() " + Exercises.RebuildMessage2(data2));
//Console.WriteLine("FindSmallestInterval() " + Exercises.RebuildMessage2(data3));

/*Console.WriteLine("StringPalindrome() " + Exercises.FilterDuplicate("Kayak"));*/



//var isParsed = int.TryParse("1", out int _);
//var isParsed2 = int.TryParse("1", out int unused);
//var isParsed3 = int.TryParse("1" _ out); // BAD
//var isParsed4 = int.TryParse("a", out _);
//var isParsed5 = int.TryParse("1", _);//BAD

//Console.WriteLine("isParsed "+ isParsed);
//Console.WriteLine("isParsed2 " + isParsed2);
//Console.WriteLine("isParsed4 " + isParsed4);

//Console.WriteLine('A' == 'a' ? "Equal": "Not Equal");

//int[,] pile = new int[3, 3] { { 1, 1, 1 }, { 1, 3, 1 }, { 1, 1, 1 } };
//int n = 1;

//int[] fromIds = { 1, 7, 3, 4, 2, 6, 9 };
//int[] toIds = { 3, 3, 4, 6, 6, 9, 5 };

//int result = Exercises.FindNetworkEndpoint(0, fromIds, toIds);

/*int[] data = { 1, 2, 1}; // 1
int[] data2 = { 1, 1, 5 }; // 2

int result = Exercises.Magic(data.ToList());
int result2 = Exercises.Magic(data2.ToList());
int result3 = Exercises.Magic(data3.ToList());
*/
//int[] data3 = { 1, 1, 3, 2, 3, 2 }; // 3


/*
foreach (var item in Exercises.FilterDuplicate(data3))
{
    Console.WriteLine(item);
}*/

// Afficher le tableau résultant
//for (int i = 0; i < result.GetLength(0); i++)
//{
//    for (int j = 0; j < result.GetLength(1); j++)
//    {
//        Console.Write(result[i, j] + " ");
//    }
//    Console.WriteLine();
//}

//int[,] pile = new int[3,3] { { 1, 1, 1 }, { 1, 3, 1 }, { 1, 1, 1 } };
//Console.WriteLine("" + Exercises.ComputeDayGains(new int[] { 1,1,2,2,2,3}));
//Exercises.SandPile(pile, 1);
//Console.WriteLine("" + Exercises.ComputeJoinPoint(480));


// Une classe doit implementer des méthodes 


//Console.WriteLine("Join point " + Exercises.ComputeJoinPoint(471, 480));

Console.ReadKey();