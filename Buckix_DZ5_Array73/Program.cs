// Array73. Дан массив A размера N и целые числа K и L (1 <= K < L <= N). Переставить в обратном порядке элементы массива,
// расположенные между элементами AK и AL, не включая эти элементы.
namespace Buckix_DZ5_Array73
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int N = 0, K = 0, L = 0;
            int[] A;
            bool cycle = true;
            string[] message = { "Введите размерность массива: ", "Введите число K: ", "Введите число L: " };

            Console.WriteLine("Дан массив A размера N и целые числа K и L (1 <= K < L <= N).\nПереставить в обратном порядке элементы массива, расположенные между элементами AK и AL, не включая эти элементы.");
            // Цикл запроса данных от пользователя.
            while (cycle)
            {
                cycle = false;
                try
                {
                    N = InputText(message[0]);
                    K = InputText(message[1]);
                    L = InputText(message[2]);

                    if (!(1 <= K && K < L && L <= N))
                    {
                        cycle = true;
                        throw new Exception("Введеные вами числа не удовлетворяют условие (1 <= K < L <= N), Повторите ввод");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            // Создаем массив
            A = new int[N];
            // Заполняем его рандомными числами.
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rnd.Next(1, 100);
            }

            Console.WriteLine("Массив: " + string.Join(" ", A));

            int start = K ;
            int end = L - 2;

            while (start < end)
            {
                Swap(ref A[start], ref A[end]);
                start++;
                end--;
            }

            Console.WriteLine("Массив: " + string.Join(" ", A));
        }

        static int InputText(string msg)
        {
            int a = 0;
            bool cycle = true;
            while (cycle)
            {
                try
                {
                    Console.Write(msg);
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a > 0)
                        cycle = false;
                    else
                        throw new Exception("Введеное число не может быть меньше 1.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            return a;
        }

        /// <summary>
        /// Метод перестановки чисел.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
