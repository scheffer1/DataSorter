using System.Diagnostics;

public class SelectionSort
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
        
         void selectionSort(int[] arr)
        {
            int min, aux;
            sw.Start();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j] < arr[min])
                    {
                        min = j;
                        swapCounter++;
                    }
                        

                if (min != i)
                {
                    aux = arr[min];
                    arr[min] = arr[i];
                    arr[i] = aux;
                    swapCounter++;
                }
            }
            sw.Stop();
        }
        Randomize(arr);
        selectionSort(arr);
        Console.WriteLine("foram feitas {0} trocas",swapCounter);
        Console.WriteLine("foram gastos {0} ms",sw.ElapsedMilliseconds);
        
    }
}