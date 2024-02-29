public class Item
{
    /*
    
    categories:
    categoryFood
    categoryAmmo
    categoryEquipment
    categoryTool
    categoryMaterial
    categoryNone
        
    */

    public enum ItemCategory
    {
        categoryNone = 0,
        categoryFood,
        categoryAmmo,
        categoryEquipment,
        categoryTool,
        categoryMaterial,
    }

    public int Id = -1;
    public string Name = null;
    public ItemCategory Category = 0;
    public bool IsSpecial = false;

    // public readonly int StackSize = 127;

    public Item(int id = -1, string name = "nameNone", ItemCategory category = 0)
    {
        Id = id;
        Name = name;
        Category = category;
    }

    public virtual void Use() { }

    public override string ToString()
    {
        return $"name: {Name} id: {Id} category: {Category}";
    }
}
