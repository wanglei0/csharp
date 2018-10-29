using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace extended.Iteration
{
    [SuppressMessage("ReSharper", "UnusedParameter.Local")]
    [SuppressMessage("ReSharper", "RedundantOverriddenMember")]
    public class TreeNode
    {
        public TreeNode Parent { get; set; }
        public TreeNode[] Child { get; set; }
        public string Name { get; set; }
        
        public TreeNode(string rootNode, params TreeNode[] children)
        {
            if (rootNode == null || rootNode == "")
            {
                throw new ArgumentException("Empty Tree");
            }

            this.Name = rootNode;
            
            foreach(TreeNode c in children)
            {
                c.Parent = this;
            }

            this.Child = children;
        }

        public override string ToString()
        {

            StringBuilder childrenName = new StringBuilder();

            foreach(TreeNode c in Child)
            {
                childrenName.Append("  " + c.ToString() );
            }

            return this.Name + "\n" + childrenName;
        }
    }
}