// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

public class QuickSort
{
    public static void Main(string[] args)
    {
        int length = 10000;
        Random rnd = new Random();
        Stopwatch sw = new Stopwatch();
        int[] arr = CreateArray();
        int swapCounter = 0;
        
        
        
        int[] CreateArray()
        {
            int[] temp = new int[length];
            for (var i = 0; i < length; i++)
            {
                temp[i] = i;
            }
            return temp;
        }
        void Randomize(int [] v) {
            for (int i=0; i < (v.Length - 1); i++) {

                //sorteia um índice
                int j = rnd.Next(v.Length);

                //troca o conteúdo dos índices i e j do vetor
                (v[i], v[j]) = (v[j], v[i]);
            }
        }
        
        void PrintArray(int[] temp)
        {
            foreach (var t in temp)
            {
                Console.Write(t);
            }
        }
        
          int[] quickSort(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;

            quickSorter(arr, start, end);

            return arr;
        }

         void quickSorter(int[] arr, int start, int end)
        { 
            sw.Start();
            if (start < end)
            {
                int p = arr[start];
                int i = start + 1;
                int f = end;

                while (i <= f)
                {
                    if (arr[i] <= p)
                    {
                        i++;
                    }
                    else if (p < arr[f])
                    {
                        f--;
                    }
                    else
                    {
                        swapCounter++;
                        (arr[i], arr[f]) = (arr[f], arr[i]);
                        i++;
                        f--;
                    }
                }
                arr[start] = arr[f];
                arr[f] = p;
                swapCounter++;
                quickSorter(arr, start, f - 1);
                quickSorter(arr, f + 1, end);
            }
            sw.Stop();
        }
         Randomize(arr);
         quickSort(arr);
         Console.WriteLine("foram feitas {0} trocas",swapCounter);
         Console.WriteLine("foram gastos {0} ms",sw.ElapsedMilliseconds);
    }
}