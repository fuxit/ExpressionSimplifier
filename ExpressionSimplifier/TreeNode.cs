﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionSimplifier
{
    internal abstract class TreeNode
    {
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        /// <summary>
        /// Calculates the resulting dimensions of the node recursively.
        /// </summary>
        /// <returns></returns>
        public abstract Dimension GetDimensions();

        /// <summary>
        /// Returns the depth of the tree starting from this node.
        /// </summary>
        /// <returns></returns>
        public int Depth()
        {
            int depthLeft = 0;
            int depthRight = 0;

            if (this.LeftChild != null)
            {
                depthLeft = this.LeftChild.Depth();
            }
            if (this.RightChild != null)
            {
                depthRight = this.RightChild.Depth();
            }

            return Math.Max(depthLeft, depthRight) + 1;
        }

        /// <summary>
        /// Collects the nodes on level i in the original tree into a list.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="sameLevelNodes"></param>
        public void GetLevelNodes(int i, List<TreeNode> sameLevelNodes)
        {
            if (i == 1)
            {
                sameLevelNodes.Add(this);
            }
            else
            {
                if (this.LeftChild != null)
                {
                    this.LeftChild.GetLevelNodes(i - 1, sameLevelNodes); 
                }
                if (this.RightChild != null)
                {
                    this.RightChild.GetLevelNodes(i - 1, sameLevelNodes); 
                }
            }
        }
    }
}