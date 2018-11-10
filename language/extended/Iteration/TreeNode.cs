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
        readonly TreeNode[] children;
        readonly string name;

        public TreeNode(string name, params TreeNode[] children)
        {
            if (name == null || name == "")
            {
                throw new ArgumentException("Empty Tree");
            }

            this.name = name;
            this.children = children ?? Array.Empty<TreeNode>();
        }

        public override string ToString()
        {
            return ToStringForLayer(0, this);
        }

        string ToStringForLayer(int layer, TreeNode node)
        {
            var finalResult = new StringBuilder();

            finalResult.Append(ToStringForSingleLayer(layer, node));

            foreach (TreeNode child in node.children)
            {
                finalResult.Append(ToStringForLayer(layer + 1, child));
            }

            return finalResult.ToString();
        }

        static string ToStringForSingleLayer(int layer, TreeNode node)
        {
            return new StringBuilder()
                .Append(' ', layer * 2)
                .Append(node.name)
                .Append('\n')
                .ToString();
        }
    }
}