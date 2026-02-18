bool flag = true;
while (flag)
{
    Console.WriteLine("Benvenuto!");
    Console.WriteLine("1. Stringhe");
    Console.WriteLine("2. Interi");  
    Console.WriteLine("3. Esci");
    int scelta = int.Parse(Console.ReadLine()!);   
    if (scelta == 1) {
        Console.Clear();
        Console.Write("Specifica la dimensione del contenitore (int): ");
        int dimensione = int.Parse(Console.ReadLine()!);
        string[] strings = new string[dimensione];
        Console.Clear();
        for (int i = 0; i < strings.Length; i++) {
            Console.WriteLine($"Inserire {i+1} stringa: ");
            strings[i] = Console.ReadLine()!;
            Console.Clear();
        }
        int counter = 1;
        foreach (string stringa in strings) {
            Console.WriteLine($"{counter}° Stringa: {stringa}");
            counter++;
        }
        Console.WriteLine();
    }  else if (scelta == 2) {
        Console.Clear();
        Console.Write("Specifica la dimensione del contenitore (int): ");
        int dimensione = int.Parse(Console.ReadLine()!);
        int[] nums = new int[dimensione];
        Console.Clear();
        for (int i = 0; i < nums.Length; i++) {
            Console.WriteLine($"Inserire {i+1} numero: ");
            nums[i] = int.Parse(Console.ReadLine()!);
            Console.Clear();
        }
        int counter = 1;
        foreach (int num in nums) {
            Console.WriteLine($"{counter}° Numero: {num}");
            counter++;
        }
        Console.WriteLine();
    } else if (scelta == 3) {
        flag = false;
        Console.Clear();
        Console.WriteLine("Sessione conclusa, arrivederci!");
        Console.WriteLine();
    } else {
        Console.Clear();
        Console.WriteLine("Errore, scelta non disponibile.");
        Console.WriteLine();
    }
}