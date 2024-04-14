namespace SharpUtil;

public class DirectoryTreeNode
{
    public string Name { get; set; }
    public List<DirectoryTreeNode> Children { get; set; }

    public DirectoryTreeNode(string name)
    {
        Name = name;
        Children = new List<DirectoryTreeNode>();
    }
    
    public static DirectoryTreeNode BuildDirectoryTree(string rootPath)
    {
        var rootNode = new DirectoryTreeNode(Directory.GetParent(rootPath)?.Name ?? "Root");

        foreach (var directory in Directory.GetDirectories(rootPath, "*", SearchOption.TopDirectoryOnly))
        {
            var childNode = BuildDirectoryTree(directory);
            rootNode.Children.Add(childNode);
        }

        return rootNode;
    }
}