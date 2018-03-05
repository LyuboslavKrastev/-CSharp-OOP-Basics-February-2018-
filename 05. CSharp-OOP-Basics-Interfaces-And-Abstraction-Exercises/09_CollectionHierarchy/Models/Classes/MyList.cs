using System.Text;

public class MyList : AddRemoveCollection, IAddableCollection, IRemovableCollection, IMyList
{
    public int Used => base.Collection.Count;

    public override void Remove()
    {
        var firstElement = base.Collection[0];
        base.Collection.RemoveAt(0);
        CollectionRemoved.Append($"{firstElement} ");
    }
}