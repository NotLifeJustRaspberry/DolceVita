using ClosedXML.Excel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

// 22.Банк
// В банке в течение небольшого промежутка времени проводят операции миллион клиентов,
// каждый клиент выполняет операцию со своим счетом – либо кладет N монет, либо снимает K монет. 
// Каждая операция дописывается в одну случайную из 10 цепочек блокчейна, однако если
// цепочка содержит 100 транзакций, она архивируется, и создается новая цепочка.

public class Chain
{
    // Поля класса (данные цепи).
    private List<Node> nodes = new();
    private const int MaxSize = 100;

    public Node this[int i] => nodes[i]; // Перегрузка индексатора
    public List<Node> List => nodes; // Возвращает копию листа, где хранятся данные.
    public int Count => nodes.Count; // Выводит количество Node в Chain.
    public bool IsFull => (nodes.Count == MaxSize); // Проверяет досстигло ли количество нодов максимального значения.
    public void Clear() => nodes.Clear(); // Чистит ноду.

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

    public void Add(long? operation)
    {
        // Проверка на ноль.
        if (operation == 0) return;

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

    public Chain Clone()
    {
        Chain clone = new Chain();
        foreach (var item in nodes)
            clone.Add(item.Operation);
        return clone;
    }

} // Класс цепочка блокчейна, сюда записываются транзакции.
public class Node
{
    // Поля класса (данные в узле).
    public long? Operation { get; }
    public string? PreviousHash { get; }
    public string? CurrentHash { get; }

    public static bool operator ==(Node a, Node b)
    {
        // Если все данные совпадают возвращает true.
        return a.Operation == b.Operation && a.PreviousHash == b.PreviousHash && a.CurrentHash == a.CurrentHash;
    }// Сравнение двух экземпляров класса Node.
    public static bool operator !=(Node a, Node b)
    {
        return !(a == b);
    }// Сравнение двух экземпляров класса Node.

    public Node(long? operation, string? previousHash)
    {
        if (operation == 0) return;

        Operation = operation;
        CurrentHash = Hash(operation.ToString());
        PreviousHash = previousHash;
    }// Инициализация Node.

    public static string Hash(string input)
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
    static void PrintConsole(List<Chain> chain, string message = "")
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
    static void PrintExcel(List<Chain> chains, string name)
    {

        string? path = Path.Combine(Environment.CurrentDirectory, name);
        XLWorkbook? wb = new();
        IXLWorksheet? sh = wb.Worksheets.Add("1");
        sh.Cell(1, 1).SetValue("Номер цепи");
        sh.Cell(1, 2).SetValue("Операция");
        sh.Cell(1, 3).SetValue("Текущий хеш");
        sh.Cell(1, 4).SetValue("Предыдущий хеш");

        for (int i = 0; i < chains.Count; i++)
        {
            List<Node> nodes = chains[i].List;
            for (int j = 0; j < nodes.Count; j++)
            {
                sh.Cell(i * nodes.Count + j + 2, 1).SetValue(i);
                sh.Cell(i * nodes.Count + j + 2, 2).SetValue(nodes[j].Operation);
                sh.Cell(i * nodes.Count + j + 2, 3).SetValue(nodes[j].CurrentHash);
                sh.Cell(i * nodes.Count + j + 2, 4).SetValue(nodes[j].PreviousHash);
            }

        }

        wb.SaveAs(path + ".xlsx");
    }// Метод для вывода данных в Excel.
    static void PrintCSV(List<Chain> chain, string message = "")
    {
        StreamWriter sw = new("Output.csv");
        sw.WriteLine(message + "\n");
        sw.WriteLine("Operation;" + "Prev hash;" + "Current hash;"+ "\n");
        for (int i = 0; i < chain.Count; i++)
        {
            sw.WriteLine("Chain " + i + ":\t");
            foreach (var item in chain[i].List)
                sw.WriteLine(item.Operation + ";" + item.PreviousHash + ";" + item.CurrentHash + ",");
            sw.WriteLine();
        }

        sw.Close();
    }// Метод для вывода данных в csv.

    static void Feel(List<Chain> chainActive, List<Chain> chainArchived, int ChainActiveSize, int operationAmount, int threadAmount = 1)
    {
        // Переменные.
        Random rnd = new(); // Для выбора рандомной активной цепи.
        List<Thread> threadList = new(); // Лист для хранения потоков

        void _feel(object arg)
        {
            for (int i = (int)arg - 1; i < operationAmount; i += threadAmount)
            {
                int rndChain = rnd.Next(0, ChainActiveSize); // Выбор цепи.
                // Выбор значения операции. Если 0 перерандом.
                int rndOperation;
                do
                {
                    rndOperation = rnd.Next(-10000, 10000);
                } while (rndOperation == 0);

                lock (chainActive[rndChain])
                {
                    // Добавление в цепь.
                    chainActive[rndChain].Add(rndOperation);

                    // Если цепь заполнена, архивируется.
                    if (chainActive[rndChain].IsFull)
                    {
                        chainArchived.Add(chainActive[rndChain].Clone());
                        chainActive[rndChain].Clear();
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
        PrintCSV(chainActive, "Unfilled");
        PrintCSV(chainArchived, "Filled");
    }
}