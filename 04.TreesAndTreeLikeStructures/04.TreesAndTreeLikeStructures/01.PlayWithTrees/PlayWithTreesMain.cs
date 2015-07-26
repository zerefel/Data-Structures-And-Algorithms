using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayWithTreesMain
{
    static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>(); 

    static void Main()
    {
        int nodes = int.Parse(Console.ReadLine());

        for (int i = 0; i < nodes; i++)
        {
            string[] edge = Console.ReadLine().Split(' ');
            int parentValue = int.Parse(edge[0]);
            Tree<int> parentNode = GetTreeNodeByValue(parentValue);
            int childValue = int.Parse(edge[1]);
            Tree<int> childNode = GetTreeNodeByValue(childValue);
            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        var rootNode = nodeByValue.Where(n => n.Value.Parent == null).Select(n => n.Value.Value).First();
        var leafNodes = nodeByValue.Where(n => n.Value.Children.Count == 0).Select(n => n.Value).OrderBy(n => n.Value);
        var middleNodes = nodeByValue.Where(n => n.Value.Parent != null && n.Value.Children.Count > 0).Select(n => n.Value).OrderBy(n => n.Value);
        string leafNodesString = string.Join(", ", leafNodes.Select(n => n.Value));
        string middleNodesString = string.Join(", ", middleNodes.Select(n => n.Value));

        Console.WriteLine("Root Node: {0}", rootNode);
        Console.WriteLine("Leaf Nodes: {0}", leafNodesString);
        Console.WriteLine("Middle Nodes: {0}", middleNodesString);
    }

    static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }
}


