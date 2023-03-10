void Main()
{
    while (true)
	{
		int task = ReadInt("номер задания");

		switch (task)
		{
			case 47: Task47(); break;
			case 50: Task50(); break;
			case 52: Task52(); break;
		}
	}
}

void Task47() // Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
{
    double[,] array = CreateTwoDimensionRealArray(ReadDimensionInt("первое"), ReadDimensionInt("второе"));
	Console.WriteLine(TwoDimensionRealArrayToString(array));

    double[,] CreateTwoDimensionRealArray(int firstLength, int secondLength)
    {
	    double[,] result = new double[firstLength, secondLength];
	    Random rnd = new Random();

	    for (int i = 0; i < result.GetLength(0); i++)
	    {
		    for (int j = 0; j < result.GetLength(1); j++)
		    {
			    result[i, j] = Math.Round((rnd.Next(-5, 10) + rnd.NextDouble()),1);
		    }
	    }

	return result;
    }

    string TwoDimensionRealArrayToString(double[,] array)
    {
	    string result = string.Empty;

	    for (int i = 0; i < array.GetLength(0); i++)
	    {
		    for (int j = 0; j < array.GetLength(1); j++)
		    {
			    result += $"{array[i, j]} ";
		    }

		    result += Environment.NewLine;
        }

	return result;
    }
}

void Task50() // Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
{
    int[,] array = CreateTwoDimensionIntArray(ReadDimensionInt("первое"), ReadDimensionInt("второе"));
    int coord1 = ReadInt("первую координату требуемого элемента");
    int coord2 = ReadInt("вторую координату требуемого элемента");
	Console.WriteLine();
	Console.WriteLine(TwoDimensionIntArrayToString(array));
    FindElement(coord1, coord2, array);

    void FindElement(int coord1, int coord2, int[,] array)
    {
        if (coord1 < array.GetLength(0) && coord2 < array.GetLength(1))
        {
            for (int i = 0; i < array.GetLength(0); i++)
	        {
		        for (int j = 0; j < array.GetLength(1); j++)
		        {
			        if (i == coord1 && j == coord2)
                    Console.WriteLine ($"Искомый элемент: {array[i,j]}");
		        }
	        }
        }
        else
        Console.WriteLine("Такого элемента не существует");
    }
}

void Task52() // Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
{
    int[,] array = CreateTwoDimensionIntArray(ReadDimensionInt("первое"), ReadDimensionInt("второе"));
    int columnNumber = 0;
	Console.WriteLine(TwoDimensionIntArrayToString(array));
    Console.WriteLine(ColumnAverageSum(columnNumber, array));

    string ColumnAverageSum(int columnNumber, int[,] array)
    {
        double sum = 0;

        if (columnNumber < array.GetLength(1))
        {
            for (int i = 0; i < array.GetLength(0); i++)
	        {
                sum = sum + array[i,columnNumber];
            }

            sum = sum/(array.GetLength(0));
            columnNumber = columnNumber + 1;
            Console.WriteLine($"Среднее арифметическое элементов в колонке номер {columnNumber} равен {sum}");

            return ColumnAverageSum(columnNumber, array);
        }
        else

        return string.Empty;
    }
}

int ReadInt(string argument)
{
	int number;
	Console.Write($"Введите {argument}: ");

	while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
	{
		Console.WriteLine("Ошибка ввода, пожалуйста, введите неотрицательное число");
    }

    return number;
}

int ReadDimensionInt(string argument)
{
	int number;
	Console.Write($"Введите {argument} измерение массива: ");

	while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
	{
		Console.WriteLine("Ошибка ввода, пожалуйста, введите положительное число");
    }

    return number;
}

int[,] CreateTwoDimensionIntArray(int firstLength, int secondLength)
{
	int[,] result = new int[firstLength, secondLength];
	Random rnd = new Random();

	for (int i = 0; i < result.GetLength(0); i++)
	{
		for (int j = 0; j < result.GetLength(1); j++)
		{
			result[i, j] = rnd.Next(0, 10);
		}
	}

	return result;
}

string TwoDimensionIntArrayToString(int[,] array)
{
	string result = string.Empty;

	for (int i = 0; i < array.GetLength(0); i++)
	{
		for (int j = 0; j < array.GetLength(1); j++)
		{
			result += $"{array[i, j]} ";
		}

		result += Environment.NewLine;
    }

	return result;
}