namespace Numbers_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // Error Message if exception occurs
            }
            finally
            {
                Console.WriteLine("Program is complete."); // Program Complete
            }
            Console.ReadLine();
        }

        static void StartSequence()
        {
            Console.WriteLine("Welcome to my game! Let's do some math!"); // Print Welcome message
            Console.WriteLine("Enter a number greater than zero:"); // Print Enter Number message

            int size = Convert.ToInt32(Console.ReadLine()); // Reads input and converts it to an integer

            if (size <= 0)
                throw new Exception("Number must be greater than zero."); // Throw an exception if the number is not greater than zero

            int[] numbers = new int[size]; // Create an array with the specified size
            numbers = Populate(numbers); // Populate the array with user values
            int sum = GetSum(numbers); // Calculate the sum of the numbers in the array
            int index = GetRandomIndex(); // Get a random index within the valid range
            int product = GetProduct(numbers, sum, index); // Calculate the product of the sum and the number at the random index
            decimal quotient = GetQuotient(product); // Calculate the quotient of the product

            Console.WriteLine($"Your array is size: {size}"); // Print array size
            Console.WriteLine($"The numbers in the array are: {string.Join(",", numbers)}"); // Prints the ints in the array with commas 
            Console.WriteLine($"The sum of the array is: {sum}"); // Print array sum
            Console.WriteLine($"{sum} * {numbers[index]} = {product}"); // Print the equation for the product calculation
            Console.WriteLine($"{product} / {quotient} = {product / quotient}"); // Print the equation for the quotient calculation
        }

        static int[] Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Please enter number: {i + 1} of {numbers.Length}"); // Has the user put a number for each slot in the array
                string input = Console.ReadLine(); // Reads the user input as a string
                numbers[i] = Convert.ToInt32(input); // Converts the input to an int, stores it in the array
            }

            return numbers; // Return the populated array
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0; // Initialize a variable to store the sum

            foreach (int num in numbers)
            {
                sum += num; // Add each number in the array to the sum
            }

            if (sum < 20)
                throw new Exception($"Value of {sum} is too low."); // Throw an exception if the sum is less than 20

            return sum; // Return the sum
        }

        static int GetRandomIndex()
        {
            Console.WriteLine("Please select a random number between 1 and 6:"); // Prompt the user to select a random number
            int index = Convert.ToInt32(Console.ReadLine()) - 1; // Read the user's input, subtract 1 to convert to zero-based index

            return index; // Return the random index
        }

        static int GetProduct(int[] numbers, int sum, int index)
        {
            if (index < 0 || index >= numbers.Length)
                throw new IndexOutOfRangeException("Invalid index."); // Throw an exception if the index is out of range

            int product = sum * numbers[index]; // Calculate the product of the sum and the number at the specified index

            return product; // Return the product
        }


        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product {product} by"); // Prompt the user to enter a number to divide the product by
            decimal dividend = Convert.ToDecimal(Console.ReadLine()); // Reads the input and converts it to a decimal

            try
            {
                decimal quotient = decimal.Divide(product, dividend); // Calculates quotient
                return quotient; // Return quotient
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero."); // Print an error message if the user attempts to divide by zero
                return 0; // Return zero 
            }
        }
    }
}
