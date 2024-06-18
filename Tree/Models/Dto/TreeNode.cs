namespace Tree.Models.Dto
{
    public class TreeNode
    {
        public int id { get; set; }
        public List<TreeNode> children { get; set; }
        public string text { get; set; }
        //public List<TreeNode>? children { get; set; }
    }

    public class Node:TreeNode
    {
        public int parent { get; set; }
    }

    public class Root
    {
        public int NodeId { get; set; }
        public int Level { get; set; }
    }
}
