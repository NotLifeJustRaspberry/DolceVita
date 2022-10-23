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