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