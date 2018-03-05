using System.Collections.Generic;
using System.Text;

public class AddCollection : IAddableCollection
{
    protected IList<string> Collection = new List<string>();

    public StringBuilder CollectionAdded = new StringBuilder();

    public virtual void Add(string item)
    {
        this.Collection.Add(item);
        int addIndex = this.Collection.Count - 1;
        CollectionAdded.Append($"{addIndex} ");
    }
}