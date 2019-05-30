using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                Console.WriteLine("\n1. Однонаправленный список: удаление из списка первого элемента с четным информационным полем.");
                Console.WriteLine("2. Двунаправленный список: добавление в список элемента с заданным номером");
                Console.WriteLine("3. Работа с деревом: найти минимальный элемент в дереве");
                Console.WriteLine("4. Выход");
                Console.WriteLine("\nВыберите команду");
                string WorkWith = Console.ReadLine();
                switch (WorkWith)
                {
                    case "1":   //однонаправленный список
                        ForPoint.WorkWithPoint();
                        break;
                    case "2":   //двунаправленный список
                        ForPoint2.WorkWithPoint2();
                        break;
                    case "3":   //деревья
                        ForTree.WorkWithTree();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный номер команды. Повторите ввод ");
                        break;
                }
            } while (!exit);
        }

        //Проверка введенного числа, целое ли оно
        public static int InputNumber()
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
                if (!ok)
                    Console.WriteLine("Целое число введено неверно. Повторите ввод.");
            } while (!ok);
            return n;
        }

        //Проверка введенного числа, натуральное ли оно
        public static int InputNatNumber()
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
                if ((!ok) || (n <= 0))
                    Console.WriteLine("Натуральное число введено неверно. Повторите ввод.");
            } while ((!ok) || (n <= 0));
            return n;
        }

        public class ForPoint
        {
            public class Point
            {
                //Инициализация класса Point
                public int data;        //информационное поле
                public Point next;      //адресное поле
                public Point()       //конструктор без параметров
                {
                    data = 0;
                    next = null;
                }
                public Point(int d)  //конструктор с параметром
                {
                    data = d;
                    next = null;
                }
                public override string ToString()
                {
                    return data + " ";
                }
            }
            
            //Создание элемента списка
            public static Point MakePoint(int d)           
            {
                Point p = new Point(d);
                return p;
            }

            //Добавление в конец рандомно
            public static Point MakeListRnd(int size)
            {
                Random rnd = new Random();
                int info = rnd.Next(-100, 100);
                Point beg = MakePoint(info);//первый элемент
                Point r = beg;              //переменная хранит адрес конца списка
                for (int i = 1; i < size; i++)
                {
                    info = rnd.Next(-100, 100);
                    Point p = MakePoint(info); //создаем элемент и добавляем в конец списка
                    r.next = p;
                    r = p;
                }
                return beg;
            }

            //Добавление в конец с клавиатуры
            public static Point MakeListByHands(int size)
            {
                Console.WriteLine("Введите 1 элемент");
                int info = InputNumber();
                Point beg = MakePoint(info);    //первый элемент
                Point r = beg;                  //переменная хранит адрес конца списка
                for (int i = 1; i < size; i++)
                {
                    Console.WriteLine("Введите {0} элемент", i + 1);
                    info = InputNumber();
                    Point p = MakePoint(info); //создаем элемент и добавляем в конец списка
                    r.next = p;
                    r = p;
                }
                return beg;
            }

            //Заполнение списка с выбором
            public static Point FormList(int size)
            {
                Point beg = null;
                bool ok = false;
                do
                {
                    Console.WriteLine("\nКак будем заполнять список?" +
                                      "\n1. Ввод с клавиатуры" +
                                      "\n2. Автозаполнение с помощью random");
                    string MakeList = Console.ReadLine();
                    switch (MakeList)
                    {
                        case "1":
                            beg = MakeListByHands(size); //Создание списка данного размера
                            ok = true;
                            break;
                        case "2":
                            beg = MakeListRnd(size);
                            ok = true;
                            break;
                        default:
                            Console.WriteLine("Неверный номер команды. Повторите ввод ");
                            break;
                    }
                } while (!ok);
                PrintList(beg);
                return beg;
            }

            // удаление четного элемента
            public static Point DelElement(Point beg)
            {
                if (beg == null)  //если список пустой
                {
                    return null;
                }
                
                while (beg != null)
                {
                    if (beg.data % 2 == 0)
                    {                      
                        beg = beg.next;
                    }
                    beg = beg.next;                   
                }
                 
                
                return beg;
            }
            
            // Печать списка
            public static void PrintList(Point beg)
            
            {
                if (beg == null)
                {
                    Console.WriteLine("Список пуст");
                    return;
                }
                Console.WriteLine("Список: ");
                Point p = beg;
                while (p != null)
                {
                    Console.Write(p + "\t");
                    p = p.next;
                }

                Console.WriteLine();
            }

            public static void WorkWithPoint()
            {
                int oper;
                Point beg = null;

                do
                {
                    Console.WriteLine("1.Создать список");
                    Console.WriteLine("2.Напечатать список");
                    Console.WriteLine("3.Обработать список");
                    Console.WriteLine("4.Назад");

                    oper = InputNatNumber();

                    switch (oper)
                    {
                        case 1:
                            {
                                Console.WriteLine("Введите размер списка");
                                int size = InputNatNumber();
                                beg = FormList(size);
                                break;
                            }
                        case 2:
                            {
                                PrintList(beg);
                                break;
                            }
                        case 3:
                            {
                                if (beg == null)
                                {
                                    Console.WriteLine("Список пуст");
                                    break;
                                }
                                Console.WriteLine("Массив обработан");
                                beg = DelElement(beg);
                                break;
                            }
                        case 4: break;
                        default:
                            Console.WriteLine("Введенного пункта не существует"); break;
                    }
                }
                while (oper!= 4);
            }
        }

        public class ForPoint2
        {
            //инициализация двунаправленного списка
            public class Point
            {
                public string data;
                public Point next,  //адрес следующего элемента 
                             pred;  //адрес предыдущего элемента 
                public Point()
                {
                    data = null;
                    next = null;
                    pred = null;
                }
                public Point(string d)
                {
                    data = d;
                    next = null;
                    pred = null;
                }
                public override string ToString()
                {
                    return data + " ";
                }
            }

            //Создание элемента списка
            public static Point MakePoint(string d)
            {
                Point p = new Point(d);
                return p;
            }

            public static Point MakeListRnd(int size) //добавление в конец 
                                                      //формирование двунаправленного списка рандомно
            {
                string chars = "abcdefghijklmnopqrstuvwxyz1234567890,;:ABCDEFGHIJKLMNOPQRSRUVWXYZ.!?" +
                               "абвгдеёжзийклмнопрстуфхцчшщъыьэюя_АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                Random rnd = new Random();
                int length = rnd.Next(1, 4);
                char[] symbols = new char[length];
                for (int i = 0; i < length; i++)
                    symbols[i] = chars[rnd.Next(0, chars.Length - 1)];   //формирование случайного набора символов длины от 1 до 4 для первого элемента
                string info = new string(symbols);
                Point beg = MakePoint(info);
                Point r = beg;
                for (int i = 1; i < size; i++)
                {
                    length = rnd.Next(1, 4);
                    symbols = new char[length];
                    for (int j = 0; j < length; j++)
                        symbols[j] = chars[rnd.Next(0, chars.Length - 1)]; // формирование остальных элементов списка
                    info = new string(symbols);
                    Point p = MakePoint(info);
                    r.next = p;
                    p.pred = r;
                    r = p;
                }
                return beg;
            }

            private static string ReadString()
            {
                string s;
                bool success = false;
                do
                {
                    s = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(s))
                    {
                        Console.WriteLine("Пустая строка. Повторите ввод");
                    }
                    else 
                    {
                        success = true;
                    }
                } while (success == false);

                return s;
            }

            //формирование двунаправленного списка вручную
            public static Point MakeListByHands(int size)
            {
                Console.WriteLine("Введите 1 элемент");
                string info = ReadString();
                Point beg = MakePoint(info);
                Point r = beg;
                for (int i = 1; i < size; i++)
                {
                    Console.WriteLine("Введите {0} элемент", i + 1);
                    info = ReadString();
                    Point p = MakePoint(info);
                    r.next = p;
                    p.pred = r;
                    r = p;
                }
                return beg;
            }

            //Заполнение списка с выбором
            public static Point FormList(int size)
            {
                Point beg = null;
                bool ok = false;
                do
                {
                    Console.WriteLine("\nКак будем заполнять список?" +
                                      "\n1. Ввод с клавиатуры" +
                                      "\n2. Автозаполнение с помощью random");
                    string MakeList = Console.ReadLine();
                    switch (MakeList)
                    {
                        case "1":
                            beg = MakeListByHands(size); //Создание 2напр списка данного размера
                            ok = true;
                            break;
                        case "2":
                            beg = MakeListRnd(size);
                            ok = true;
                            break;
                        default:
                            Console.WriteLine("Неверный номер команды. Повторите ввод ");
                            break;
                    }
                } while (!ok);
                PrintList(beg);
                return beg;
            }

            // Печать списка
            public static void PrintList(Point beg)
            {
                if (beg == null)
                {
                    Console.WriteLine("Список пуст");
                    return;
                }
                Console.WriteLine("Список: ");
                Point p = beg;
                while (p != null)
                {
                    Console.Write(p + "\t");
                    p = p.next;
                }
                Console.WriteLine();
            }

            //Добавление элемента на заданную позицию
            public static Point AddElem(Point beg, int size, int pos, Point NewEl)
            {
                if (beg == null)    //если список пустой
                {
                    Console.WriteLine("Список пуст. Элемент был добавлен, в начало списка");
                    return NewEl;
                }

                if (pos == 1)   //добавление в начало списка
                {
                    NewEl.next = beg;
                    beg.pred = NewEl;
                    return NewEl;
                }
                Point cur = beg; //добавление в конец списка
                int count = 0;
                if (pos > size)
                {
                    Console.WriteLine("\nРазмер списка меньше позиции добавляемого элемента. Элемент будет добавлен в конец списка");
                    while (count++ != size - 1) // доходим до конца
                        cur = cur.next;

                    cur.next = NewEl;
                    NewEl.pred = cur;
                    NewEl = cur;
                    return beg;
                }

                //добавление на любую позицию
                cur = beg;
                count = 0;
                while (count++ != pos - 1)
                    cur = cur.next; // доходим до нужной позиции

                cur.pred.next = NewEl; // ставим новый элемент на позицию перед cur 
                NewEl.pred = cur.pred; // связываем ссылки
                cur.pred = NewEl;
                NewEl.next = cur;

                return beg;
            }

            public static void WorkWithPoint2()
            {
                int oper;
                int size_ = 0;
                Point beg = null;

                do
                {
                    Console.WriteLine("1.Создать список");
                    Console.WriteLine("2.Напечатать список");
                    Console.WriteLine("3.Обработать список");
                    Console.WriteLine("4.Назад");

                    oper = InputNatNumber();

                    switch (oper)
                    {
                        case 1:
                            {
                                Console.WriteLine("Введите размер списка");
                                int size = InputNatNumber();
                                size_ = size;
                                beg = FormList(size);
                                break;
                            }
                        case 2:
                            {
                                PrintList(beg);
                                break;
                            }
                        case 3:
                            {
                                if (beg == null)
                                {
                                    Console.WriteLine("Список пуст");
                                    break;                               
                                }
                                Console.WriteLine("\nВведите позицию добавляемого элемента: ");
                                int pos = InputNatNumber();
                                Console.WriteLine("\nВведите значение элемента: ");
                                string info = Console.ReadLine();
                                Point NewEl = MakePoint(info);
                                beg = AddElem(beg, size_, pos, NewEl);
                                Console.WriteLine("Список обработан");
                                break;
                            }
                        case 4: break;
                        default:
                            Console.WriteLine("Введенного пункта не существует"); break;
                    }
                }
                while (oper != 4);
            }
        }

        public class ForTree
        {
            // Инициализация бинарного дерева
            public class Tree
            {
                public double data;
                public Tree left,     //адрес левого поддерева  
                            right;    //адрес правого поддерева 
                public Tree()
                {
                    data = '0';
                    left = null;
                    right = null;
                }
                public Tree(double d)
                {
                    data = d;
                    left = null;
                    right = null;
                }
                public override string ToString()
                {
                    return data + " ";
                }

            }

            //Создание элемента типа Tree
            static Tree MakeTree(double value)
            {
                Tree p = new Tree(value);
                return p;
            }

            // Создание элемента типа double, ввод с клавиатуры
            static double GetValue()
            {
                double info = Checkdouble();
                return info;
            }

            // Создание элемента типа double с помощью ДСЧ
            static double GetValue(Random rnd)
            {
                int k = rnd.Next(33, 122); double n = Math.Round(rnd.NextDouble(), 2);
                double info = k + n; //Явное преобразование типов
                return info;
            }

            //Проверка элемента для добавления в дерево(вручную)
            static double Checkdouble()
            {
                Console.WriteLine("Введите элемент (тип double)"); ;
                bool ok;
                double info;
                do
                {
                    string buf = Console.ReadLine();
                    ok = double.TryParse(buf, out info);
                    if (!ok)
                        Console.WriteLine("Символ double введен неверно. Повторите ввод.");
                } while (!ok);
                return info;
            }

            // Формирование идеально сбалансированного дерева 
            // Заполнение с клавиатуры
            public static Tree IdealTree(int size)
            {
                if (size == 0) return null;
                int nl = size / 2;
                int nr = size - nl - 1;
                double number = GetValue();
                Tree r = MakeTree(number);
                r.left = IdealTree(nl);
                r.right = IdealTree(nr);
                return r;
            }

            // Формирование идеально сбалансированного дерева 
            // Заполнение random
            public static Tree IdealTree(int size, Random rnd)
            {
                if (size == 0) return null;
                int nl = size / 2;
                int nr = size - nl - 1;
                double number = GetValue(rnd);
                Tree root = MakeTree(number);
                root.left = IdealTree(nl, rnd);
                root.right = IdealTree(nr, rnd);
                return root;
            }

            // Заполнение бинарного дерева с выбором
            public static Tree FormTree()
            {
                Console.WriteLine("Введите размер дерева");
                int size = InputNatNumber();
                Tree idTree = null;
                Random rnd = new Random();
                bool ok = false;
                do
                {
                    Console.WriteLine("\nКак будем заполнять дерево?" +
                                      "\n1. Ввод с клавиатуры" +
                                      "\n2. Автозаполнение с помощью random");
                    string MakeTree = Console.ReadLine();
                    switch (MakeTree)
                    {
                        case "1":
                            idTree = IdealTree(size);
                            ok = true;
                            break;
                        case "2":
                            idTree = IdealTree(size, rnd);
                            ok = true;
                            break;
                        default:
                            Console.WriteLine("Неверный номер команды. Повторите ввод ");
                            break;
                    }
                } while (!ok);
                return idTree;
            }

            // Добавление элемента в дерево поиска 
            public static Tree Add(Tree root, double info)
            {
                if (root == null || root.data == '0')
                    return MakeTree(info);
                Tree tek = root;
                Tree anc = null;
                while (tek != null) //спускаемся "вниз" дерева
                {
                    anc = tek;
                    if (info == tek.data)
                    {
                        Console.WriteLine("Элемент {0} уже существует в дереве", info);
                        return root;
                    }
                    else if (info > tek.data) //если элемент больше текущего
                        tek = tek.right; //идем вправо
                    else
                        tek = tek.left;  //идем влево
                }
                tek = MakeTree(info);
                if (tek.data > anc.data)
                    anc.right = tek; //добавление в правую часть
                else
                    anc.left = tek; //добавление в левую часть
                return root;
            }

            //Построение дерева поиска
            public static void BuildSearchTree(Tree idTree, ref Tree srch)
            {
                srch = Add(srch, idTree.data);
                if (idTree.left != null)
                    BuildSearchTree(idTree.left, ref srch);
                if (idTree.right != null)
                    BuildSearchTree(idTree.right, ref srch);
            }

            //Нахождение минимального элемента
            public static void MinimElems(Tree root, ref double min)
            {
                if (root != null)
                {
                    MinimElems(root.left, ref min);     //переход к левому поддереву 
                                                         //формирование отступа 
                    if (root.data < min)
                        min = root.data;

                    MinimElems(root.right, ref min);    //переход к правому поддереву 
                }
            }

            public static void WorkWithTree()
            {
                int oper;
                Tree idTree = null;

                do
                {
                    Console.WriteLine("1.Создать идеально сбалансированное дерево");
                    Console.WriteLine("2.Напечатать дерево");
                    Console.WriteLine("3.Обработать идеально сбалансированное дерево");
                    Console.WriteLine("4.Преобразовать идеально сбалансированное дерево в дерево поиска");
                    Console.WriteLine("5.Назад");

                    oper = InputNatNumber();

                    switch (oper)
                    {
                        case 1:
                            {
                                idTree = FormTree();
                                ShowTree(idTree, 20);
                                break;
                            }
                        case 2:
                            {
                                if (idTree == null)
                                {
                                    Console.WriteLine("Дерево пустое");
                                    break;                                  
                                }
                                ShowTree(idTree, 20);
                                break;
                            }
                        case 3:
                            {
                                if (idTree == null)
                                {
                                    Console.WriteLine("Дерево пустое");
                                    break;
                                }
                                Console.WriteLine("Минимальный элемент = ");
                                double min = int.MaxValue;
                                MinimElems(idTree, ref min);
                                Console.WriteLine(min);
                                break;
                            }
                        case 4:
                            {
                                if (idTree == null)
                                {
                                    Console.WriteLine("Дерево пустое");
                                    break;
                                }
                                Tree SearchTree = new Tree();
                                BuildSearchTree(idTree, ref SearchTree);
                                idTree = SearchTree;
                                Console.WriteLine("Дерево преобразовано");
                                break;
                            }
                        case 5: break;
                        default:
                            Console.WriteLine("Введенного пункта не существует"); break;
                    }
                }
                while (oper != 5);
            }

            // Печать дерева
            public static void ShowTree(Tree root, int l)
            {
                if (root != null)
                {
                    ShowTree(root.right, l + 3);     //переход к левому поддереву 
                                                     //формирование отступа 
                    for (int i = 0; i < l; i++) Console.Write(" ");
                    Console.WriteLine(root.data);   //печать узла 
                    ShowTree(root.left, l + 3);      //переход к правому поддереву 
                }
            }
        }
    }
}
