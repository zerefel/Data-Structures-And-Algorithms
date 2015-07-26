using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();

        foreach (var childTree in children)
        {
            this.Children.Add(childTree);
            childTree.Parent = this;
        }
    }

    public IList<Tree<T>> Children { get; set; }
    public T Value { get; set; }
    public Tree<T> Parent { get; set; }

    public T FindTreeRoot()
    {
        if (this.Parent == null)
        {
            return this.Value;
        }
        
        return this.Parent.FindTreeRoot();  
    }

    public IList<Tree<T>> FindAllMiddleNodes()
    {
        var middleNodes = new List<Tree<T>>();

        if (this.Parent != null && this.Children.Any())
        {
            middleNodes.Add(this);
        }

        foreach (var child in this.Children)
        {
            middleNodes.AddRange(child.FindAllMiddleNodes());
        }

        if (this.Parent == null)
        {
            middleNodes.Sort();
        }

        return middleNodes;
    }

    public IList<Tree<T>> FindAllLeafNodes()
    {
        var leafNodes = new List<Tree<T>>();

        if (this.Children.Count == 0)
        {
            leafNodes.Add(this);
        }

        foreach (var child in this.Children)
        {
            leafNodes.AddRange(child.FindAllLeafNodes());
        }

        if (this.Parent == null)
        {
            leafNodes.Sort();
        }

        return leafNodes;
    }
}