using System.Collections.Generic;

public class PlayerCharacterSimpleInventory
{
    /// <summary>
    /// Key: ItemID, Value: Count
    /// </summary>
    private readonly Dictionary<int, int> inventory = new();

    public void Add(int itemID)
    {
        if (inventory.ContainsKey(itemID))
        {
            inventory[itemID]++;
        }
        else
        {
            inventory.Add(itemID, 1);
        }
    }

    public void Subtract(int itemID)
    {
        if (inventory.ContainsKey(itemID))
        {
            inventory[itemID]--;

            if (inventory[itemID] <= 0)
            {
                inventory.Remove(itemID);
            }
        }
    }
}
