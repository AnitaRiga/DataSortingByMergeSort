using System.Diagnostics;

Console.ForegroundColor = ConsoleColor.White;
List<int> unsorted = new List<int>();
List<int> sorted;
Random random = new Random();

Console.Write("Original array elements: " + "\t");

for (int i = 0; i < 100; i++)
{
    unsorted.Add(random.Next(-10000, 10000));
    Console.Write(unsorted[i] + "  ");
}

Stopwatch sw = new Stopwatch();
sw.Start();

sorted = MergeSort(unsorted);

Console.Write("\n\n" + "Sorted array elements: " + "\t\t");
foreach (int x in sorted)
{
    Console.Write(x + "  ");
}

sw.Stop();

Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Write("\n\n" + $"Execution Time: {sw.ElapsedMilliseconds} ms." + "\n");

static List<int> MergeSort(List<int> unsorted)
{
    if (unsorted.Count <= 1)
    {
        return unsorted;
    }

    List<int> left = new List<int>();
    List<int> right = new List<int>();

    int middle = unsorted.Count / 2;
    for (int i = 0; i < middle; i++) //Dividing the unsorted list
    {
        left.Add(unsorted[i]);
    }

    for (int i = middle; i < unsorted.Count; i++)
    {
        right.Add(unsorted[i]);
    }

    left = MergeSort(left);
    right = MergeSort(right);
    return Merge(left, right);
}


static List<int> Merge(List<int> left, List<int> right)
{
    List<int> result = new List<int>();

    while (left.Count > 0 || right.Count > 0)
    {
        if (left.Count > 0 && right.Count > 0)
        {
            if (left.First() <= right.First())  // Comparing First two elements to see which is smaller.
            {
                result.Add(left.First());
                left.Remove(left.First());      //Rest of the list minus the first element.
            }
            else
            {
                result.Add(right.First());
                right.Remove(right.First());
            }
        }
        else if (left.Count > 0)
        {
            result.Add(left.First());
            left.Remove(left.First());
        }
        else if (right.Count > 0)
        {
            result.Add(right.First());
            right.Remove(right.First());
        }
    }
    return result;
}