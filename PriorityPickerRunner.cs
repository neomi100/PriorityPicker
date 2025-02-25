class PriorityPickerRunner
{
    static void Main()
    {

        Random random = new Random();

        List<Item> items = new List<Item>();

        for (int i = 0; i < 5; i++) items.Add(new Item($"Item_{i+1}", 1));
        for (int i = 5; i < 10; i++) items.Add(new Item($"Item_{i+1}", 2));
        for (int i = 10; i < 15; i++) items.Add(new Item($"Item_{i+1}", 3));

        for (int run = 1; run <= 7; run++)
        {
            if (items.Count == 0) break; 

            Item selectedItem = SelectItemBasedOnPriority(items, random);
            Console.WriteLine($"Run {run}: Selected {selectedItem.Name} with Priority {selectedItem.Priority}");

            items.Remove(selectedItem); 
        }
    }

    static Item SelectItemBasedOnPriority(List<Item> items, Random random)
    {
        Dictionary<int, double> probabilities = new Dictionary<int, double>
        {
            { 1, 0.60 }, 
            { 2, 0.30 }, 
            { 3, 0.10 }  
        };

        while (true)
        {
            Item candidate = items[random.Next(items.Count)];
            if (random.NextDouble() < probabilities[candidate.Priority])
            {
                return candidate;
            }
        }
    }
}

class Item
{
    public string Name { get; }
    public int Priority { get; }

    public Item(string name, int priority)
    {
        Name = name;
        Priority = priority;
    }
}
