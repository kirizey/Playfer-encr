using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYFER_7LABA
{
    class Program
    {
        static void Main(string[] args)
        {
            int dey = 0;
            char[] alph = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };

            while (dey != 5)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Шифр Плейфера (КИРИЛЛИЦА)");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Шифрование двойным квадратом");
                Console.WriteLine("2. Дешифровка двойным квадратом");
                Console.WriteLine("\n");
                dey = Convert.ToInt32(Console.ReadLine());
                switch (dey)
                {
                    case 1:
                        {
                            Console.Write("Введите ключ 1-ой матрицы: ");
                            string key = Console.ReadLine();
                            key = key.ToUpper();
                            int z = key.Length;
                            char[] keychar = key.ToCharArray(0, z);
                            for (int p = 0; p < z; p++)
                            {
                                if (keychar[p] == 'Ё')
                                    keychar[p] = 'Е';
                                if (keychar[p] == 'Й')
                                    keychar[p] = 'И';
                                if (keychar[p] == 'Ъ')
                                    keychar[p] = 'Ь';
                            }
                            key = "";
                            for (int p = 0; p < z; p++)
                            {
                                key = key + keychar[p];
                            }
                            string tmp = "";
                            foreach (char c in key)
                                if (!tmp.Contains(c))
                                    tmp += c;
                            key = tmp;

                            tmp = "";
                            foreach (char q in alph)
                                if (!key.Contains(q))
                                    key += q;
                            int x = 0;
                            char[,] encriptionMatrix = new char[6, 5];
                            string text;
                            for (int i = 0; i < 6; i++)
                                for (int j = 0; j < 5; j++)
                                {
                                    encriptionMatrix[i, j] = key[x];
                                    x++;
                                }
                            for (int i = 0; i < 6; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                    Console.Write(encriptionMatrix[i, j]);
                                Console.WriteLine();
                            }
                            Console.Write("Введите ключ 2-ой матрицы: ");
                            string key2 = Console.ReadLine();
                            key2 = key2.ToUpper();
                            int m = key2.Length;
                            char[] keychar2 = key2.ToCharArray(0, m);
                            for (int p = 0; p < m; p++)
                            {
                                if (keychar2[p] == 'Ё')
                                    keychar2[p] = 'Е';
                                if (keychar2[p] == 'Й')
                                    keychar2[p] = 'И';
                                if (keychar2[p] == 'Ъ')
                                    keychar2[p] = 'Ь';
                            }
                            key2 = "";
                            for (int p = 0; p < m; p++)
                            {
                                key2 = key2 + keychar2[p];
                            }
                            string tmp2 = "";
                            foreach (char v in key2)
                                if (!tmp2.Contains(v))
                                    tmp2 += v;
                            key2 = tmp2;
                            tmp2 = "";
                            foreach (char n in alph)
                                if (!key2.Contains(n))
                                    key2 += n;
                            int y = 0;
                            char[,] encriptionMatrix2 = new char[6, 5];
                            for (int i = 0; i < 6; i++)
                                for (int j = 0; j < 5; j++)
                                {
                                    encriptionMatrix2[i, j] = key2[y];
                                    y++;
                                }
                            for (int i = 0; i < 6; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                    Console.Write(encriptionMatrix2[i, j]);
                                Console.WriteLine();
                            }
                            int i_first = 0, j_first = 0;
                            int i_second = 0, j_second = 0;
                            string s1 = "", s2 = "";
                            Console.Write("Введите сообщение: ");
                            text = Console.ReadLine();
                            text = text.ToUpper();
                        ppoint:
                            int t = text.Length;
                            int a = 0;
                            int b = 0;
                            int tmplen = text.Length;
                            for (int i = 1; i < tmplen; i++)
                            {
                                if (text[i] == text[i - 1])
                                {
                                    text = text.Insert(i, "Х");
                                    tmplen++;
                                }
                            }
                            int temp = t % 2;
                            if (temp != 0)
                            {
                                if (text[t - 1] == 'Х')
                                    text = text.PadRight((t + 1), 'А');
                                else
                                    text = text.PadRight((t + 1), 'Х');
                            }
                            int len = text.Length / 2;
                            if (text.Length % 2 == 1)
                                len++;
                            string[] str = new string[len];
                            int l = -1;
                            if (text.Length % 2 == 1)
                            {
                                text += "Х";
                                t++;
                            }
                            for (a = 0; a <= t; a += 2)
                            {
                                l++;
                                if (l < len)
                                {
                                    str[l] = Convert.ToString(text[a]) + Convert.ToString(text[a + 1]);
                                }
                            }
                            int r = 0;
                            foreach (string both in str)
                            {
                                r = r + 2;
                                if (both[0] == both[1])
                                {
                                    text = text.Insert(r - 1, "Х");
                                    goto ppoint;
                                }
                            }
                            foreach (string both in str)
                            {
                                for (a = 0; a < 6; a++)
                                {
                                    for (b = 0; b < 5; b++)
                                    {
                                        if (both[0] == Convert.ToChar(encriptionMatrix[a, b]))
                                        {
                                            i_first = a;
                                            j_first = b;
                                        }
                                        if (both[1] == Convert.ToChar(encriptionMatrix2[a, b]))
                                        {
                                            i_second = a;
                                            j_second = b;
                                        }
                                    }
                                }
                                if (i_first == i_second)
                                {
                                    if (j_first == 4)
                                    {
                                        s1 = Convert.ToString(encriptionMatrix[i_first, 0]);
                                    }
                                    else
                                    {
                                        s1 = Convert.ToString(encriptionMatrix[i_first, j_first + 1]);
                                    }
                                    if (j_second == 4)
                                    {
                                        s2 = Convert.ToString(encriptionMatrix[i_second, 0]);
                                    }
                                    else
                                    {
                                        s2 = Convert.ToString(encriptionMatrix[i_second, j_second + 1]);
                                    }
                                }
                                if (j_first == j_second)
                                {
                                    if (i_first == 5)
                                    {
                                        s1 = Convert.ToString(encriptionMatrix[0, j_first]);
                                    }
                                    else
                                    {
                                        s1 = Convert.ToString(encriptionMatrix[i_first + 1, j_first]);
                                    }
                                    if (i_second == 5)
                                    {
                                        s2 = Convert.ToString(encriptionMatrix[0, j_second]);
                                    }
                                    else
                                    {
                                        s2 = Convert.ToString(encriptionMatrix[i_second + 1, j_second]);
                                    }
                                }
                                if (i_first != i_second && j_first != j_second)
                                {
                                    s1 = Convert.ToString(encriptionMatrix[i_first, j_second]);
                                    s2 = Convert.ToString(encriptionMatrix[i_second, j_first]);
                                }
                                if (i_first == i_second && j_first == j_second)
                                {
                                    s1 = Convert.ToString(encriptionMatrix[i_first, j_first]);
                                    s2 = "X";
                                }
                                if (s1 == s2)
                                {
                                    Console.Write(s1 + "Х");
                                }
                                Console.Write(s1 + s2);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Введите ключ 1-ой матрицы: ");
                            string key = Console.ReadLine();
                            key = key.ToUpper();
                            int z = key.Length;
                            char[] keychar = key.ToCharArray(0, z);
                            for (int p = 0; p < z; p++)
                            {
                                if (keychar[p] == 'Ё')
                                    keychar[p] = 'Е';
                                if (keychar[p] == 'Й')
                                    keychar[p] = 'И';
                                if (keychar[p] == 'Ъ')
                                    keychar[p] = 'Ь';
                            }
                            key = "";
                            for (int p = 0; p < z; p++)
                            {
                                key = key + keychar[p];
                            }
                            string tmp = "";
                            foreach (char c in key)
                                if (!tmp.Contains(c))
                                    tmp += c;
                            key = tmp;
                            tmp = "";
                            foreach (char q in alph)
                                if (!key.Contains(q))
                                    key += q;
                            int x = 0;
                            char[,] encriptionMatrix = new char[6, 5];
                            string text;
                            for (int i = 0; i < 6; i++)
                                for (int j = 0; j < 5; j++)
                                {
                                    encriptionMatrix[i, j] = key[x];
                                    x++;
                                }
                            for (int i = 0; i < 6; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                    Console.Write(encriptionMatrix[i, j]);
                                Console.WriteLine();
                            }
                            Console.Write("Введите ключ 2-ой матрицы: ");
                            string key2 = Console.ReadLine();
                            key2 = key2.ToUpper();
                            int m = key2.Length;
                            char[] keychar2 = key2.ToCharArray(0, m);
                            for (int p = 0; p < m; p++)
                            {
                                if (keychar2[p] == 'Ё')
                                    keychar2[p] = 'Е';
                                if (keychar2[p] == 'Й')
                                    keychar2[p] = 'И';
                                if (keychar2[p] == 'Ъ')
                                    keychar2[p] = 'Ь';
                            }
                            key2 = "";
                            for (int p = 0; p < m; p++)
                            {
                                key2 = key2 + keychar2[p];
                            }
                            string tmp2 = "";
                            foreach (char v in key2)
                                if (!tmp2.Contains(v))
                                    tmp2 += v;
                            key2 = tmp2;
                            tmp2 = "";
                            foreach (char n in alph)
                                if (!key2.Contains(n))
                                    key2 += n;
                            int y = 0;
                            char[,] encriptionMatrix2 = new char[6, 5];
                            for (int i = 0; i < 6; i++)
                                for (int j = 0; j < 5; j++)
                                {
                                    encriptionMatrix2[i, j] = key2[y];
                                    y++;
                                }
                            for (int i = 0; i < 6; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                    Console.Write(encriptionMatrix2[i, j]);
                                Console.WriteLine();
                            }
                            int i_first = 0, j_first = 0;
                            int i_second = 0, j_second = 0;
                            string s1 = "", s2 = "";
                            Console.Write("Зашифрованное сообщение: ");
                            text = Console.ReadLine();
                            text = text.ToUpper();
                            int t = text.Length;
                            int a = 0;
                            int b = 0;
                            int len = text.Length / 2;
                            string[] str = new string[len];
                            int l = -1;
                            for (a = 0; a < t; a += 2)
                            {
                                l++;
                                if (l < len)
                                {
                                    str[l] = Convert.ToString(text[a]) + Convert.ToString(text[a + 1]);
                                }
                            }
                            foreach (string both in str)
                            {
                                for (a = 0; a < 6; a++)
                                {
                                    for (b = 0; b < 5; b++)
                                    {
                                        if (both[0] == Convert.ToChar(encriptionMatrix[a, b]))
                                        {
                                            i_first = a;
                                            j_first = b;
                                        }
                                        if (both[1] == Convert.ToChar(encriptionMatrix[a, b]))
                                        {
                                            i_second = a;
                                            j_second = b;
                                        }
                                    }
                                }
                                if (i_first == i_second)
                                {
                                    if (j_first == 0)
                                    {
                                        s1 = Convert.ToString(encriptionMatrix[i_first, 4]);
                                    }
                                    else
                                    {
                                        s1 = Convert.ToString(encriptionMatrix[i_first, j_first - 1]);
                                    }
                                    if (j_second == 0)
                                    {
                                        s2 = Convert.ToString(encriptionMatrix2[i_second, 4]);
                                    }
                                    else
                                    {
                                        s2 = Convert.ToString(encriptionMatrix2[i_second, j_second - 1]);
                                    }
                                }
                                if (j_first == j_second)
                                {
                                    if (i_first == 0)
                                    {
                                        s1 = Convert.ToString(encriptionMatrix[5, j_first]);
                                    }
                                    else
                                    {
                                        s1 = Convert.ToString(encriptionMatrix[i_first - 1, j_first]);
                                    }
                                    if (i_second == 0)
                                    {
                                        s2 = Convert.ToString(encriptionMatrix2[5, j_second]);
                                    }
                                    else
                                    {
                                        s2 = Convert.ToString(encriptionMatrix2[i_second - 1, j_second]);
                                    }
                                }
                                if (i_first != i_second && j_first != j_second)
                                {
                                    s1 = Convert.ToString(encriptionMatrix[i_first, j_second]);
                                    s2 = Convert.ToString(encriptionMatrix2[i_second, j_first]);
                                }
                                if (s1 == s2)
                                {
                                    Console.Write(s1);
                                }
                                Console.Write(s1 + s2);
                            }
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Выберите пункт меню");
                            break;
                        }
                }
            }
        }
    }
}

