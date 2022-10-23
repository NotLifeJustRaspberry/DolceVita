using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp2;

class Chain
{
    private readonly List<Node> nodes = new();
    private const int MaxSize = 3;

    public Node this[int i] => nodes[i];
    public List<Node> List => nodes;
    public int Count => nodes.Count;
    public bool IsFull => (nodes.Count == MaxSize);

    public static bool operator ==(Chain a, Chain b)
    {
        List<Node>? listA = a.List;
        List<Node>? listB = b.List;

        if (listA.Count != listB.Count)
            return false;

        for (int j = 0; j < listA.Count - 1; j++)
            if (listA[j] != listB[j])
                return false;

        return true;
    }
    public static bool operator !=(Chain a, Chain b)
    {
        return !(a == b);
    }

    public void Add(int operation)
    {
        if (nodes.Count >= MaxSize)
            return;

        if (nodes.Count == 0)
            nodes.Add(new Node(operation, null));
        else
            nodes.Add(new Node(operation, nodes[^1].CurrentHash));
    }
}

class Node
{
    public int Operation { get; }
    public string PreviousHash { get; }
    public string CurrentHash { get; }
    public static bool operator ==(Node a, Node b)
    {
        return a.Operation == b.Operation && a.PreviousHash == b.PreviousHash && a.CurrentHash == a.CurrentHash;
    }
    public static bool operator !=(Node a, Node b)
    {
        return !(a == b);
    }
    public Node(int operation, string previousHash)
    {
        Operation = operation;
        CurrentHash = Hash(operation.ToString());
        PreviousHash = previousHash;
    }

    private static string Hash(string input)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

        StringBuilder sBuilder = new();
        for (int i = 0; i < data.Length; i++)
            sBuilder.Append(data[i].ToString("x2"));
        return sBuilder.ToString();
    }

}

class Program
{
    static void Print(List<Chain> chain, string message = "")
    {
        Console.WriteLine("\n============================\n{0}\n", message);

        for (int i = 0; i < chain.Count; i++)
        {
            Console.Write(i + ":\t");
            foreach (var item in chain[i].List)
                Console.Write(item.Operation + " " + item.PreviousHash + " " + item.CurrentHash + "\n\t ");
            Console.WriteLine();
        }

        Console.WriteLine("\n============================\n");
    }
    static void Feel(List<Chain> chainActive, List<Chain> chainArchived, int ChainActiveSize, int operationAmount, int threadAmount = 1)
    {
        Random rnd = new();
        List<Thread> threadList = new();

        void _feel(object arg)
        {
            //for (int i = 0; i < operationAmount; i++)
            for (int i = (int)arg - 1; i < operationAmount; i += threadAmount)
            {
                int r = rnd.Next(0, ChainActiveSize);
                lock (chainActive[r])
                {
                    chainActive[r].Add(i % 5);

                    if (chainActive[r].IsFull)
                    {
                        chainArchived.Add(chainActive[r]);
                        chainActive.RemoveAt(r);
                        chainActive.Add(new Chain());
                    }
                }
            }
        }


        for (int i = 0; i < threadAmount; i++)
        {
            Thread thread = new(_feel);
            threadList.Add(thread);
            threadList[i].Start(i + 1);
        }

        for (int i = 0; i < threadList.Count; i++)
            threadList[i].Join();
    }

    static void Main(string[] args)
    {
        const int ChainActiveSize = 5;
        const int OperationAmount = 43;
        List<Chain> chainActive = new();
        List<Chain> chainArchived = new();

        for (int i = 0; i < ChainActiveSize; i++)
            chainActive.Add(new Chain());


        Feel(chainActive, chainArchived, ChainActiveSize, OperationAmount);
        Print(chainArchived, "Заполненые");
        Print(chainActive, "Не заполненые");

    }
}