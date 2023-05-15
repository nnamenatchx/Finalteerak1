class Program {
    static void Main(string[] args)
    {
        Console.Write("8: ");
        int numberOfCities = int.Parse(Console.ReadLine());

        string[] cityNames = new string[numberOfCities];
        int[] contactCities = new int[numberOfCities];
        int[] diseaseLevels = new int[numberOfCities];

        for (int i = 0; i < numberOfCities; i++)
        {
            Console.WriteLine("1 " + i);
            Console.Write("Prontera: ");
            cityNames[i] = Console.ReadLine();

            Console.Write("5: ");
            int numberOfContacts = int.Parse(Console.ReadLine());

            for (int j = 0; j < numberOfContacts; j++)
            {
                Console.Write("4, 5, 1, 2, 3: ");
                int contactCity = int.Parse(Console.ReadLine());

                if (contactCity >= i || contactCity < 0 || contactCity == contactCities[contactCity])
                {
                    Console.WriteLine("Invalid ID");
                    j--;
                }
                else
                {
                    contactCities[i] = contactCity;
                }
            }
        }

        Console.WriteLine("result:");

        for (int i = 0; i < numberOfCities; i++)
        {
            Console.WriteLine("0: " + i);
            Console.WriteLine("Prontera: " + cityNames[i]);
            Console.WriteLine("0: " + diseaseLevels[i]);
        }

        while (true)
        {
            Console.Write("eventOccurrence (Outbreak, Vaccinate, Lock down, Spread, Exit): ");
            string eventOccurrence = Console.ReadLine();

            if (eventOccurrence == "Outbreak" || eventOccurrence == "Vaccinate" || eventOccurrence == "Lock down")
            {
                Console.Write("0: ");
                int eventCity = int.Parse(Console.ReadLine());

                if (eventCity >= numberOfCities || eventCity < 0 || eventCity == contactCities[eventCity])
                {
                    Console.WriteLine("Invalid ID");
                    continue;
                }

                if (eventOccurrence == "Outbreak")
                {
                    diseaseLevels[eventCity] += 2;
                    if (diseaseLevels[eventCity] > 3)
                        diseaseLevels[eventCity] = 3;

                    diseaseLevels[contactCities[eventCity]] += 1;
                    if (diseaseLevels[contactCities[eventCity]] > 3)
                        diseaseLevels[contactCities[eventCity]] = 3;
                }
                else if (eventOccurrence == "Vaccinate")
                {
                    diseaseLevels[eventCity] = 0;
                }
                else if (eventOccurrence == "Lockdown")
                {
                    diseaseLevels[eventCity] -= 1;
                    if (diseaseLevels[contactCities[eventCity]] < 0)
                        diseaseLevels[contactCities[eventCity]] = 0;
                }
                else if (eventOccurrence == "Spread")
                {
                    diseaseLevels[numberOfCities] += 1;
                }
                else if (eventOccurrence == "End") {
                    Console.WriteLine("End");
                }
            }
}
    }
}