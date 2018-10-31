using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace extended.Iteration
{
    [SuppressMessage("ReSharper", "UnusedParameter.Local")]
    [SuppressMessage("ReSharper", "RedundantOverriddenMember")]
    public class TreeNode
    {
        public TreeNode Parent { get; set; }
        public TreeNode[] Child { get; set; }
        public string Name { get; set; }
        public int Layer { get; set; }


        public StringBuilder NameToString = new StringBuilder();
        
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

        public void GetLayer()
        {
            if (this.Parent == null)
            {
                this.Layer = 0;
            }

            foreach (TreeNode child in this.Child)
            {
                child.Layer = this.Layer + 2;
                child.GetLayer();
            }
        }

        public override string ToString()
        {
            GetLayer();

            StringBuilder childrenName = new StringBuilder();

            foreach (TreeNode childNode in Child)
            {
                childrenName.Append( childNode.ToString());
            }

            return new StringBuilder().Append(' ', Layer) + Name + "\n" + childrenName;
        }
    }
}