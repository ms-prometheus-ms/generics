using System ;

using System.Collections ;

using System.Collections.Generic;

using System.Diagnostics ;

public static class Program {

    public static void Main()
    {
        ValueTypePerfТest();

        ReferenceTypePerfТest();
    }
    private static void ValueTypePerfТest()
    {
        const Int32 count = 10000000;

        using (new OperationTimer("List<Int32> ")) {
            List<Int32> l = new List<Int32>(count);
            for (Int32 n = 0; n < count; n++)
            {
                l.Add(n);
                Int32 х = l[n];
            }
            l = null; //це повинно видалятися під час garbage collection
        }

        using (new OperationTimer("ArrayList of Int32")) {
            ArrayList a = new ArrayList(count);
            for (Int32 n = 0; n < count; n++)
            {
                a.Add(n);
                Int32 х = (Int32)a[n];
            }
            a = null; //це повинно видалятися під час garbage collection
        }

    }
    private static void ReferenceTypePerfТest()
    {
        const Int32 count = 10000000;

        using (new OperationTimer("List<String> "))
        {
            List<String> l = new List<String>(count);
            for (Int32 n = 0; n < count; n++)
            {
                l.Add("X");
                String х = l[n];
            }
            l = null; //це повинно видалятися під час garbage collection
        }

        using (new OperationTimer("ArrayList of String "))
        {
            ArrayList a = new ArrayList(count);
            for (Int32 n = 0; n < count; n++)
            {
                a.Add("X");
                String х = (String)a[n];
            }
            a = null; //це повинно видалятися під час garbage collection
        }

    }
}

//Корисний спосіб перевірки часу виконаня алгоритму
internal sealed class OperationTimer : IDisposable
{
    private Int64 m_startTime;
    private String m_text;
    private Int32 m_collectionCount;

    public OperationTimer(String text)
    {
        PrepareForOperation();
        m_text = text;
        m_collectionCount = GC.CollectionCount(0);
        m_startTime = Stopwatch.GetTimestamp();
    }
    public void Dispose()
    {
        Console.WriteLine("{0,6:###.00} seconds ( GCs={1,3} ) {2}",
        (Stopwatch.GetTimestamp() - m_startTime) /
        (Double)Stopwatch.Frequency,
        GC.CollectionCount(0) - m_collectionCount, m_text);
    }

    private static void PrepareForOperation()
    {

        GC.Collect();

        GC.WaitForPendingFinalizers();

        GC.Collect();

    }
}
