using System.Drawing;
using System.Text.RegularExpressions;

namespace Questions.Interviews_CSharp; 
public class Exercises {
    #region BinarySearch
    static public bool BinarySearch(int[] ints, int k)
    {
        return Array.BinarySearch(ints, k) >= 0;
    }
    #endregion

    #region FilterWords
    static public string[] FilterWords(string[] words, string letters) {
        return words.Where(w => w.Contains(letters)).ToArray();
    }
    #endregion

    #region LuckyMoney
    static public int LuckyMoney(int money, int giftees) {
        if (money == 4) throw new Exception("You cannot give 4");
        if (money >= giftees * 8) return giftees;
        if (money < 8 + giftees - 1 || money == 12) return 0;
        return 1 + LuckyMoney(money - 8, giftees - 1);
    }
    #endregion

    #region MyRegion

    public static int ComputeDayGains(int nbSeats, int[] payinGuests, int[] guestMovements)
    {
        // Calculer le nombre total d'invités présents à la fin de la journée
        int totalGuests = payinGuests.Length;
        for (int i = 0; i < guestMovements.Length; i++)
        {
            totalGuests += guestMovements[i];
            if (totalGuests > nbSeats)
            {
                totalGuests = nbSeats;
            }
        }

        // Calculer le prix par siège
        int pricePerSeat = 0;
        if (nbSeats > 0)
        {
            int totalMoneyEarned = payinGuests.Sum();
            pricePerSeat = totalMoneyEarned / nbSeats;
        }

        // Calculer les gains réels de la journée
        int dayGains = totalGuests * pricePerSeat - payinGuests.Sum();

        return dayGains;
    }


    #endregion

    #region FrequencySort
    public static void FrequencySort(int[] nums)
    {
        // Comptage des occurrences de chaque élément
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (!count.ContainsKey(num))
            {
                count[num] = 0;
            }
            count[num]++;
        }

        // Tri par fréquence décroissante
        Array.Sort(nums, (x, y) => count[y] - count[x]);

        // Affichage du tableau trié
        foreach (int num in nums)
        {
            Console.Write(num + " ");
        }
    }
    #endregion

    #region ClosestToZero
    static public int ClosesToZero(int[] numbers) {
        if (numbers.Length == 0) return 0;
        return numbers.OrderBy(t => Math.Abs(t)).ThenBy(t => -t).First();
    }
    #endregion

    #region FindSumPair
    static public int[] FindSumPair(int[] numbers, int k) {
        Array.Sort(numbers);
        return numbers.Where(x => numbers.Any(y => x + y == k)).ToArray();
    }
    #endregion

    #region FilterDuplicate
    static public int[] FilterDuplicate(int[] ts) {
       return ts.ToHashSet().ToArray();
       //return ts.DistinctBy(t => t).ToArray();
    }
    #endregion

    #region FindLargestSquare
    public static int FindLargestSquare(int[,] matrix)
    {
        var rows = Enumerable.Range(0, matrix.GetLength(0)).ToList();
        var cols = Enumerable.Range(0, matrix.GetLength(1)).ToList();

        var squares = rows.SelectMany(row => cols.Select(col =>
        {
            var size = 1;
            while (rows.Contains(row + size) && cols.Contains(col + size) &&
                    Enumerable.Range(col, size + 1).All(c => matrix[row + size, c] == 1) &&
                    Enumerable.Range(row, size + 1).All(r => matrix[r, col + size] == 1))
            {
                size++;
            }

            return size;
        }));

        return squares.Max();
    }
    #endregion

    #region MyRegion

    public static int ApplyFunction2(string quadraticFunction, int x)
    {
        // Extraire les coefficients a, b et c de la chaîne de caractères quadraticFunction
        Match match = Regex.Match(quadraticFunction, @"([+-]?\d*)x\^2([+-]?\d*)x([+-]?\d*)");
        if (match.Success)
        {
            int a = match.Groups[1].Value != "" ? int.Parse(match.Groups[1].Value) : 0;
            int b = match.Groups[2].Value != "" ? int.Parse(match.Groups[2].Value) : 0;
            int c = match.Groups[3].Value != "" ? int.Parse(match.Groups[3].Value) : 0;
            // Calculer la valeur de la fonction polynôme pour la valeur x donnée
            int result = a * x * x + b * x + c;
            return result;
        }
        else
        {
            return 0; // La chaîne de caractères ne correspond pas à une fonction polynôme valide
        }
    }
    #endregion

    #region MyRegion

    public static int ApplyFunction3(string quadraticFunction, int x)
    {
        // Séparer les coefficients de la fonction sous forme de chaîne de caractères
        string[] tokens = quadraticFunction.Split(new char[] { 'x', '^', '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

        // Analyser les coefficients de la fonction
        int a = tokens.Where((t, i) => t == "" && i < tokens.Length - 2).Select(_ => 1).Concat(
            tokens.Where((t, i) => t != "" && i < tokens.Length - 2).Select(int.Parse)).DefaultIfEmpty(0).First();

        int b = tokens.Where((t, i) => t == "" && i < tokens.Length - 1 && i > 0).Select(_ => 1).Concat(
            tokens.Where((t, i) => t != "" && i < tokens.Length - 1 && i > 0).Select(int.Parse)).DefaultIfEmpty(0).First();

        int c = tokens.Where((t, i) => t == "" && i == tokens.Length - 1).Select(_ => 1).Concat(
            tokens.Where((t, i) => t != "" && i == tokens.Length - 1).Select(int.Parse)).DefaultIfEmpty(0).First();

        // Calculer la valeur de la fonction pour la valeur de x donnée
        int resultat = a * x * x + b * x + c;

        return resultat;
    }


    public static int ApplyFunction(string quadraticFunction, int x)
    {
        // Séparer les coefficients de la fonction sous forme de chaîne de caractères
        string[] tokens = quadraticFunction.Split(new char[] { 'x', '^', '+', '-' }, StringSplitOptions.RemoveEmptyEntries);

        // Analyser les coefficients de la fonction
        int a = tokens.Where((t, i) => t == "" && i < tokens.Length - 2).Select(_ => 1).Concat(
            tokens.Where((t, i) => t != "" && i < tokens.Length - 2).Select(int.Parse)).DefaultIfEmpty(0).First();

        int b = tokens.Where((t, i) => t == "" && i < tokens.Length - 1 && i > 0).Select(_ => 1).Concat(
            tokens.Where((t, i) => t != "" && i < tokens.Length - 1 && i > 0).Select(int.Parse)).DefaultIfEmpty(0).First();

        int c = tokens.Where((t, i) => t == "" && i == tokens.Length - 1).Select(_ => 1).Concat(
            tokens.Where((t, i) => t != "" && i == tokens.Length - 1).Select(int.Parse)).DefaultIfEmpty(0).First();

        // Calculer la valeur de la fonction pour la valeur de x donnée
        int resultat = a * x * x + b * x + c;

        return resultat;
    }


    #endregion

    #region ComputeJoinPoint
    public static int ComputeJoinPoint(int s1, int s2)
    {
        var s1digitsSum = (s1 + "").Select(c => (int)c).Aggregate(new List<int>(), (acc, d) => { acc.Add(acc.DefaultIfEmpty().Last() + d); return acc; });
        var s2digitsSum = (s2 + "").Select(c => (int)c).Aggregate(new List<int>(), (acc, d) => { acc.Add(acc.DefaultIfEmpty().Last() + d); return acc; });

        return s1digitsSum.Intersect(s2digitsSum).DefaultIfEmpty(-1).First();
    }
    #endregion

    #region Calc
    static public int Calc(int[] array, int n1, int n2){
        return array.Where(x => x >= n1 && x <= n2).Sum();
    }
    #endregion

    #region LocateUniverseFormula
    public static string locateSubDir(string baseDir)
    {

        string result = string.Empty;
        string[] files = Directory.GetFileSystemEntries(baseDir);

        foreach (string file in files) {

            if (Directory.Exists(file))
            {
                result = locateSubDir(file);
                if (result != null)
                    return result;
            }
            else
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Name == "universe-formula")
                    return file;
                
            }
        }
        return result;
    }

    public static string LocateUniverseFormula() {
        return locateSubDir("/tmp/documents");
    }
    #endregion

    #region MyAtoi
    public static int MyAtoi(string s)
    {
        int result = 0;
        int sign = 1;
        int i = 0;

        // Élimination des espaces
        while (i < s.Length && s[i] == ' ')
        {
            i++;
        }

        // Gestion du signe
        if (i < s.Length && (s[i] == '+' || s[i] == '-'))
        {
            sign = (s[i++] == '+') ? 1 : -1;
        }

        // Conversion en entier
        while (i < s.Length && s[i] >= '0' && s[i] <= '9')
        {
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && s[i] - '0' > 7))
            {
                return (sign == 1) ? int.MaxValue : int.MinValue;
            }
            result = result * 10 + (s[i++] - '0');
        }

        return sign * result;
    }
    #endregion

    #region FindSmallestInterval
    public static int FindSmallestInterval(int[] numbers)
    {
        if (numbers == null || numbers.Length < 2) {
            throw new ArgumentException("Le tableau doit contenir au moins deux éléments.");
        }

        Array.Sort(numbers);
        int minInterval = int.MaxValue;
        for (int i = 1; i < numbers.Length; i++) {
            int interval = numbers[i] - numbers[i - 1];
            if (interval < minInterval) {
                minInterval = interval;
            }
        }

        return minInterval;
    }
    #endregion

    #region CountFrequencies
    public static int[] CountFrequencies(string[] words) {
        Dictionary<string, int> wordsDictionary = new();

        Array.Sort(words);
        foreach (string word in words) {
            if (wordsDictionary.ContainsKey(word)) wordsDictionary[word] += 1;
            else wordsDictionary[word] = 1;
        }

        return wordsDictionary.Values.ToArray();
    }
    #endregion

    #region TreeNode
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static int SumEvenGrandparent(TreeNode root){
        return DFS(root, null, null);
    }

    public static int DFS(TreeNode node, TreeNode parent, TreeNode grandparent)
    {
        if (node == null) return 0;
        int sum = 0;
        if (grandparent != null && grandparent.val % 2 == 0) sum += node.val;

        sum += DFS(node.left, node, parent);
        sum += DFS(node.right, node, parent);
        return sum;
    }
    #endregion

    #region FirstOccurence
    public static int FirstOccurence(string s, string x) {
        if (s == null || x == null) return -1;
     
        int wildcardIndex = x.IndexOf('*');
        if (wildcardIndex == -1) return s.IndexOf(x);
        
        string prefix = x.Substring(0, wildcardIndex);
        int prefixIndexInS = s.IndexOf(prefix);

        var wildcardValue = s[prefixIndexInS + prefix.Length] + "";
        return s.IndexOf(x.Replace("*", wildcardValue));
    }
    #endregion

    #region CountPrime
    public static int CountPrime(int n) {
        return Enumerable.Range(2, n-1)
            .Where(x => IsPrime(x))
            .Count();
    }

    private static bool IsPrime(int n) {
        if (n <= 1) return false;
        return !Enumerable
            .Range(2, (int)Math.Sqrt(n))
            .Any(i => n % i == 0);
    }
    #endregion

    #region RebuildMessage
    public static string RebuildMessage(string[] parts) {
        return parts.OrderBy(p => p[0])
            .Aggregate("", (currentMessage, part) =>
                currentMessage.EndsWith(part[0])
                    ? currentMessage + part.Substring(1)
                    : currentMessage + part)
            .Trim();
    }
    #endregion

    #region DailyCodingProblem
    public static int ComputeSumNumber(int[] lists, int k) {
        return lists.Aggregate((acc, cur) => acc + cur == k ? acc + cur : acc);
    }

    public static int[] ComputeProduct(int[] lists) {
        return lists.Select((el, i) =>
            lists.Where((x, index) => index != i)
            .Aggregate((a,b) => a*b)
        ).ToArray();
    }

    #endregion

    #region StringPalindrome
    public static bool StringPalindrome(string word) {
        string reverse = new (word.Reverse().ToArray());
        return word.Equals(reverse, StringComparison.InvariantCultureIgnoreCase);
    }
    #endregion

    #region Scanchar
    static public char Scanchar(string s)
    {
        return (char)Enumerable.Range('A', 'Z').FirstOrDefault(c => s.CompareTo(c.ToString()) == 0);

    }
    #endregion

    #region A.Test
    public static bool Test(int i, int j)
    {
        return i == 1 || j == 1 || (i + j) == 1;
    }
    #endregion

    #region GetPositionAt
    public static int GetPositionAt(int n)
    {
        int[] position = { 0, 1, -1, -4, -5, -3 };
        return position[n % 6];
    }
    #endregion

    #region FibonacciSeries
    public static void FibonacciSeries()
    {
        // Demande à l'utilisateur d'entrer son numéro cible
        Console.WriteLine("Combien de nombres voulez-vous dans la série de fibonacci");
        // Lit l'entrée utilisateur depuis la console et la convertit en entier
        int Target = int.Parse(Console.ReadLine());
        // Crée des variables entières pour contenir les nombres précédents et suivants
        int PreviousNumber = -1, NextNumber = 1;
        // Cette boucle for contrôle le nombre d'éléments de la série de Fibonacci
        for (int i = 0; i < Target; i++)
        {
            // Logic to compute fibonacci series numbers
            int Sum = PreviousNumber + NextNumber; PreviousNumber = NextNumber; NextNumber = Sum;
            Console.Write(NextNumber + " ");
        }
        Console.ReadLine();
    }
    #endregion

    #region MyRegion

    public static int Solution(string[] tab)
    {
        List<int> list = tab.Select(int.Parse).OrderBy(x => x).ToList();
        while (list.Select((x, i) => new { Index = i, Value = x }).Any(x => x.Index < list.Count - 1 && x.Value == list[x.Index + 1]))
        {
            list = list.Select((x, i) => new { Index = i, Value = x }).GroupBy(x => x.Value)
                       .SelectMany(g => g.Aggregate(new List<int>(), (acc, x) => acc.Concat(Enumerable.Repeat(x.Value, x.Index - acc.Count + 1)).ToList()))
                       .ToList();
        }
        return list.Count;
    }
    #endregion

    #region Magic Stones
    public static int Magic(List<int> stones)
    {
        stones.Sort();
        int i = 0;
        while (i < stones.Count - 1)
        {
            if (stones[i] == stones[i + 1])
            {
                stones.RemoveAt(i + 1);
                int a = stones[i];
                stones.RemoveAt(i);
                stones.Add(a + 1);
                stones.Sort();
                i = 0;
            }
            else i++;
        }
        return stones.Count;
    }
    #endregion

    #region MyRegion
    public static int[,] SandPile2(int[,] pile, int n)
    {
        int sizeX = pile.GetLength(0);
        int sizeY = pile.GetLength(1);

        while (n > 0)
        {
            n--;

            // Trouver les cases qui ont une valeur supérieure à 3
            List<(int, int)> unstable = new List<(int, int)>();
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (pile[x, y] > 3)
                    {
                        unstable.Add((x, y));
                    }
                }
            }

            // Appliquer la règle de cascade à chaque case instable
            foreach (var cell in unstable)
            {
                int x = cell.Item1;
                int y = cell.Item2;
                pile[x, y] -= 4;
                if (x > 0) pile[x - 1, y]++;
                if (x < sizeX - 1) pile[x + 1, y]++;
                if (y > 0) pile[x, y - 1]++;
                if (y < sizeY - 1) pile[x, y + 1]++;
            }
        }

        // Retourner le tableau modifié
        return pile;
    }

    public static int[,] SandPile4(int[,] pile, int maxIterations)
    {
        int sizeX = pile.GetLength(0);
        int sizeY = pile.GetLength(1);

        bool stable = false;
        int iterations = 0;

        while (!stable && iterations < maxIterations)
        {
            stable = true;
            iterations++;

            // Trouver les cases qui ont une valeur supérieure à 3
            var unstable = Enumerable.Range(0, sizeX)
                .SelectMany(x => Enumerable.Range(0, sizeY)
                    .Where(y => pile[x, y] > 3)
                    .Select(y => (x, y)))
                .ToList();

            // Appliquer la règle de cascade à chaque case instable
            foreach (var (x, y) in unstable)
            {
                stable = false;
                pile[x, y] -= 4;
                if (x > 0) pile[x - 1, y]++;
                if (x < sizeX - 1) pile[x + 1, y]++;
                if (y > 0) pile[x, y - 1]++;
                if (y < sizeY - 1) pile[x, y + 1]++;
            }
        }

        // Retourner le tableau modifié
        return pile;
    }

    public static int[,] SandPile(int[,] pile, int n)
    {
        int sizeX = pile.GetLength(0);
        int sizeY = pile.GetLength(1);

        while (n > 0)
        {
            n--;

            // Trouver les cases qui ont une valeur supérieure à 3
            var unstable = Enumerable.Range(0, sizeX)
                .SelectMany(x => Enumerable.Range(0, sizeY)
                    .Where(y => pile[x, y] > 3)
                    .Select(y => (x, y)))
                .ToList();

            // Appliquer la règle de cascade à chaque case instable
            foreach (var (x, y) in unstable)
            {
                pile[x, y] -= 4;
                if (x > 0) pile[x - 1, y]++;
                if (x < sizeX - 1) pile[x + 1, y]++;
                if (y > 0) pile[x, y - 1]++;
                if (y < sizeY - 1) pile[x, y + 1]++;
            }
        }

        // Retourner le tableau modifié
        return pile;
    }
    #endregion

    #region FizzBuzz
    public static string FizzBuzz(int number, Dictionary<int, string> map)
    {
        var query =
            from i in Enumerable.Range(1, number)
            let output = string.Concat(map.Where(pair => i % pair.Key == 0).Select(pair => pair.Value))
            select output == "" ? i.ToString() : output;

        return string.Join(" ", query);
    }

    #endregion

    #region Reshape
    public static string Reshape(int n, string str)
    {
        // Supprimer tous les espaces de la chaîne
        string strNoSpaces = new string(str.Where(c => !Char.IsWhiteSpace(c)).ToArray());

        // Générer une séquence de sous-chaînes de longueur maximale n
        IEnumerable<string> substrings = (IEnumerable<string>)Enumerable.Range(0, strNoSpaces.Length / n + 1)
            .Select(i => strNoSpaces.Skip(i * n).Take(n))
            .Where(s => s.Any());

        // Concaténer les sous-chaînes avec des retours à la ligne
        string result = string.Join(Environment.NewLine, substrings);

        // Retourner la chaîne formatée
        return result;
    }
    #endregion

    #region Approx
    public static double Approx_V1(Point[] pts)
    {
        int into = 0;
        for (int i = 0; i < pts.Length; i++)
        {
            Point p = pts[i];
            if (p.x * p.x + p.y * p.y <= 1) into++;
        }
        // pi / 4 = into / n
        return (double)into / pts.Length * 4;
    }

    public class Point {
        public double x, y;
    }
    #endregion

    #region Next
    public static int Next(int n)
    {
        // Vérifier que n est inférieur à 2^31 et strictement positif
        if (n <= 0 || n >= 2147483647)
        {
            throw new ArgumentException("n doit être strictement positif et inférieur à 2^31.");
        }

        // Convertir l'entier n en une chaîne de caractères
        string nString = n.ToString();

        // Trouver le plus petit entier supérieur à n ayant des chiffres différents de n
        for (int i = n + 1; i <= 2147483647; i++)
        {
            bool hasUniqueDigits = true;
            string iString = i.ToString();

            // Vérifier que chaque chiffre de i n'apparaît pas dans n
            foreach (char c in iString)
            {
                if (nString.Contains(c))
                {
                    hasUniqueDigits = false;
                    break;
                }
            }

            // Si i a des chiffres différents de n, retourner i
            if (hasUniqueDigits)
            {
                return i;
            }
        }

        // Si aucun entier supérieur à n avec des chiffres différents n'a été trouvé, retourner -1
        return -1;
    }


    #endregion

    #region FindNetworkEndpoint
    public static int FindNetworkEndpoint(int startNodeId, int[] fromIds, int[] toIds)
    {
        int current = startNodeId;
        bool found = false;

        // Boucler jusqu'à ce que le nœud final soit trouvé
        while (!found)
        {
            found = true;

            // Chercher le lien qui contient le nœud courant
            for (int i = 0; i < fromIds.Length; i++)
            {
                if (fromIds[i] == current)
                {
                    current = toIds[i];
                    found = false;
                    break;
                }
            }
        }

        return current;
    }

    #endregion

    #region Armstrong Number
    public static void ArmstrongExample()
    {
        int n, r, sum = 0, temp;
        Console.Write("Enter the Number= ");
        n = int.Parse(Console.ReadLine()); temp = n;
        while (n > 0)
        {
            r = n % 10;
            sum += (r);
            n /= 10;
        }
        if (temp == sum) Console.Write("Armstrong Number.");
        else Console.Write("Not Armstrong Number.");
    }
    #endregion

    #region Reverse
    public static void Reverse()
    {
        int n, reverse = 0, rem;
        Console.Write("Enter a number: ");
        n = int.Parse(Console.ReadLine());
        while (n != 0)
        {
            rem = n % 10; reverse = reverse * 10 + rem; n /= 10;
        }
        Console.Write("Reversed Number: " + reverse);
        Console.ReadLine();
    }
    #endregion

    #region ReverseCharacters
    static public void ReverseCharacters()
    {
        // Prompt the user to enter the string
        Console.WriteLine("Please enter your string");
        // Read the user string from console
        string UserString = Console.ReadLine();
        // The simple way to reverse a string is to use
        // the built-in .net framework Reverse() function
        List<char> StringCharacters = UserString.Reverse().ToList();
        // Finally print each character from the collection
        foreach (char c in StringCharacters)
        {
            Console.Write(c);
        }
        Console.ReadLine();
    }
    #endregion
}

