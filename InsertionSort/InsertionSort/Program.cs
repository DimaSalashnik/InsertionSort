using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args) => Process();

        static void Process(){
            Console.Write("Enter array elements: ");
            int[] array = new int[2];
            try{
                var tempArray = Console.ReadLine().Split(new[] { ' ', ',', ';' },
                    StringSplitOptions.RemoveEmptyEntries);
                Array.Resize(ref array, tempArray.Length);
                for (int i = 0; i < array.Length; i++)
                    array[i] = Convert.ToInt32(tempArray[i]);
            }
            catch{
                Console.Clear();
                Console.WriteLine("Try again...");
                Process();
            }
            Console.WriteLine($"Sorted array: {String.Join(", ", InsertionSort(array))}");
            Repeat();
            return;
        }

        static void Repeat(){
            Console.Write("Want to sort another array? (yes/no)   -   ");
            string answer = Console.ReadLine().ToLower().Trim();
            if (answer == "yes") {
                Process();
                answer = "";
                return;
            }
            else if (answer == "no"){
                Console.WriteLine("Shutting down...");
                return;
            }
            else{
                Console.Clear();
                Console.WriteLine("Try again...");
                answer = "";
                Repeat();
                return;
            }
        }

        static void Swap(ref int e1, ref int e2){
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        static int[] InsertionSort(int[] array){
            for (var i = 1; i < array.Length; i++){
                var tempNum = array[i];
                var j = i;
                while((j > 1) && (array[j - 1] > tempNum)){
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }
                array[j] = tempNum;
            }
            return array;
        }
    }
}
