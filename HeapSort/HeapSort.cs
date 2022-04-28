
using System.Diagnostics;

public class HeapSorter
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
                int temp = v[i];
                v[i] = v[j];
                v[j] = temp;
            }
        }

        void PrintArray(int[] temp) {
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i]);
            }
        }
        void heapSort(int[] arr, int n) {
            ;
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n-1; i>=0; i--) {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
            
        }

         void heapify(int[] arr, int n, int i)
         {
             sw.Start(); //esta função consegue acumular o tempo.
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
                swapCounter++;
            }


            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
                swapCounter++;
            }
                
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                swapCounter++;
                heapify(arr, n, largest);
            }
            sw.Stop();
        }
         Randomize(arr);
         heapSort(arr,length);
        Console.WriteLine("foram feitas {0} trocas",swapCounter);
        Console.WriteLine("foram gastos {0} ms",sw.ElapsedMilliseconds);
    }
}
