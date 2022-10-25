using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

public class Chain
{
    // Поля класса (данные цепи).
    private readonly List<Node> nodes = new();
    private const int MaxSize = 100;

    public Node this[int i] => nodes[i]; // Перегрузка индексатора
    public List<Node> List => nodes; // Возвращает копию листа, где хранятся данные.
    public int Count => nodes.Count; // Выводит количество Node в Chain.
    public bool IsFull => (nodes.Count == MaxSize); // Проверяет досстигло ли количество нодов максимального значения.

    public static bool operator ==(Chain a, Chain b)
    {
        // Вспомогательные переменные, в которых храняться листы экземпляров a и b.
        List<Node>? listA = a.List;
        List<Node>? listB = b.List;

        // Если у них разный размер, значит они не равны между собой.
        if (listA.Count != listB.Count)
            return false;

        // Поэлементно сравниваются Node двух листов.
        for (int j = 0; j < listA.Count - 1; j++)
            if (listA[j] != listB[j])
                return false;

        return true;
    }// Сравнение двух экземпляров класса Node.
    public static bool operator !=(Chain a, Chain b)
    {
        return !(a == b);
    }// Сравнение двух экземпляров класса Node.

    public void Add(int operation)
    {
        // Проверка заполнена ли цепь.
        if (nodes.Count >= MaxSize)
            return;

        // Если это первый элемент в цепи, добавляет операцию и деалает значение PreviousHash равное null.
        if (nodes.Count == 0)
            nodes.Add(new Node(operation, null));
        // В остальных случаях добавляет операцию и берет значение для PreviousHash из предыдущего элемента.
        else
            nodes.Add(new Node(operation, nodes[^1].CurrentHash));
    }// Добавление цепочки в Blockchain.
} // Класс цепочка блокчейна, сюда записываются транзакции.

public class Node
{
    // Поля класса (данные в узле).
    public long Operation { get; }
    public string PreviousHash { get; }
    public string CurrentHash { get; }

    public static bool operator ==(Node a, Node b)
    {
        // Если все данные совпадают возвращает true.
        return a.Operation == b.Operation && a.PreviousHash == b.PreviousHash && a.CurrentHash == a.CurrentHash;
    }// Сравнение двух экземпляров класса Node.
    public static bool operator !=(Node a, Node b)
    {
        return !(a == b);
    }// Сравнение двух экземпляров класса Node.

    public Node(long operation, string previousHash)
    {
        Operation = operation;
        CurrentHash = Hash(operation.ToString());
        PreviousHash = previousHash;
    }// Инициализация Node.

    private static string Hash(string input)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

        StringBuilder sBuilder = new();
        for (int i = 0; i < data.Length; i++)
            sBuilder.Append(data[i].ToString("x2"));
        return sBuilder.ToString();
    }// Метод хеширования данных.
}// Класс Node, нужен для хранения данных класса Chain.

public class Program
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
    }// Метод для вывода данных в консоль.
    static void Feel(List<Chain> chainActive, List<Chain> chainArchived, int ChainActiveSize, int operationAmount, int threadAmount = 1)
    {
        // Переменные.
        Random rnd = new(); // Для выбора рандомной активной цепи.
        List<Thread> threadList = new(); // Лист для хранения потоков

        void _feel(object arg)
        {
            for (int i = (int)arg - 1; i < operationAmount; i += threadAmount)
            {
                int r = rnd.Next(0, ChainActiveSize); // Выбор цепи.
                lock (chainActive[r])
                {
                    chainActive[r].Add(i % 5);

                    // Если цепь заполнена, архивируется.
                    if (chainActive[r].IsFull)
                    {
                        chainArchived.Add(chainActive[r]);
                        chainActive.RemoveAt(r);
                        chainActive.Add(new Chain());
                    }
                }
            }
        } // Метод как именно будут заполняться цепи, и какой распределяются потоки.

        // Запуск потоков.
        for (int i = 0; i < threadAmount; i++)
        {
            Thread thread = new(_feel);
            threadList.Add(thread);
            threadList[i].Start(i + 1);
        }

        // Проверка закончили ли потоки выполнение.
        for (int i = 0; i < threadList.Count; i++)
            threadList[i].Join();
    } // Метод заполнение цепей.

    static void Main(string[] args)
    {
        // Переменные.
        const int ChainActiveSize = 10; // Размер активной цепи.
        const int OperationAmount = 1000000; // Количество транзакций.

        // Инициализация активной и архивированный цепей.
        List<Chain> chainArchived = new();
        List<Chain> chainActive = new();
        for (int i = 0; i < ChainActiveSize; i++)
            chainActive.Add(new Chain());

        // Основная часть программы.
        Feel(chainActive, chainArchived, ChainActiveSize, OperationAmount);

        // Вывод данных в цепях.
        Print(chainArchived, "Заполненые");
        Print(chainActive, "Не заполненые");
    }
}