using System.Text;

public class AddRemoveCollection : AddCollection, IAddableCollection, IRemovableCollection
{
    public StringBuilder CollectionRemoved = new StringBuilder();

    public override void Add(string item)
    {
        this.Collection.Insert(0, item);
        int addIndex = 0;
        CollectionAdded.Append($"{addIndex} ");
    }

    public virtual void Remove()
    {
        var removedItem = this.Collection[Collection.Count-1];
        this.Collection.RemoveAt(Collection.Count-1);
        CollectionRemoved.Append($"{removedItem} ");
    }
}