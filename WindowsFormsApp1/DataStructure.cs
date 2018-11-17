using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class DataStructure
    {
        public enum Axis
        {
            X,
            Y
        }

        public List<Point> Points { get; set; }


        public DataStructure()
        {
            Points = new List<Point>();
        }

        public class KD_Node
        {
            public Point ThePoint { get; set; }
            public int TopLeftX { get; set; }
            public int TopLeftY { get; set; }
            public int BottomRightX { get; set; }
            public int BottomRightY { get; set; }
            public bool IsLeaf { get; set; }
            public KD_Node LeftSubTree { get; set; }
            public KD_Node RightSubTree { get; set; }
        }

        public List<Point> Search_KD_Tree(KD_Node root, int topLeftX, int topLeftY, int bottomRightX, int bottomRightY )
        {
            var tmpList = new List<Point>();
            if (true ==root.IsLeaf)
            {
                if (topLeftX <= root.ThePoint.X && topLeftY <= root.ThePoint.Y && root.ThePoint.X <= bottomRightX && root.ThePoint.Y <= bottomRightY)
                {
                    tmpList.Add(root.ThePoint);
                }
            }
            else
            {
                if (root.LeftSubTree.TopLeftX < bottomRightX && root.LeftSubTree.BottomRightX > topLeftX &&
                    root.LeftSubTree.TopLeftY < bottomRightY && root.LeftSubTree.BottomRightY > topLeftY)
                {
                    tmpList.AddRange(
                        Search_KD_Tree(root.LeftSubTree,
                        Math.Max(root.LeftSubTree.TopLeftX, topLeftX),
                        Math.Max(root.LeftSubTree.TopLeftY, topLeftY),
                        Math.Min(root.LeftSubTree.BottomRightX, bottomRightX),
                        Math.Min(root.LeftSubTree.BottomRightY, bottomRightY))
                        );
                }
                if (root.RightSubTree.TopLeftX < bottomRightX && root.RightSubTree.BottomRightX > topLeftX &&
                    root.RightSubTree.TopLeftY < bottomRightY && root.RightSubTree.BottomRightY > topLeftY)
                {
                    tmpList.AddRange(
                        Search_KD_Tree(root.RightSubTree,
                        Math.Max(root.RightSubTree.TopLeftX, topLeftX),
                        Math.Max(root.RightSubTree.TopLeftY, topLeftY),
                        Math.Min(root.RightSubTree.BottomRightX, bottomRightX),
                        Math.Min(root.RightSubTree.BottomRightY, bottomRightY))
                        );
                }
                
            }
            return tmpList;
        }

        public KD_Node Make_KD_Tree(List<Point> points, int topLeftX, int topLeftY, int bottomRightX, int bottomRightY, Axis axis)
        {
            if (points.Count <= 1)
            {
                return new KD_Node { ThePoint = points.FirstOrDefault(), TopLeftX = topLeftX, TopLeftY = topLeftY, BottomRightX = bottomRightX, BottomRightY = bottomRightY, IsLeaf = true };
            }
            else
            {
                KD_Node TreeNode = new KD_Node() {  TopLeftX = topLeftX, TopLeftY = topLeftY, BottomRightX = bottomRightX, BottomRightY = bottomRightY, IsLeaf = false }; ;
                List<Point> orderPoints;
                if (axis == Axis.X)
                {
                    orderPoints = points.OrderBy(p => p.X).ToList();
                }
                else
                {
                    orderPoints = points.OrderBy(p => p.Y).ToList();
                }
                /////////////////////////////////////
                int pLength = points.Count();
                List<Point> leftOrderPoints = new List<Point>();
                List<Point> rightOrderPoints = new List<Point>();
                int c = 0;
                while (c < pLength / 2)
                {
                    leftOrderPoints.Add(orderPoints[c]);
                    c++;
                }
                while (c < pLength)
                {
                    rightOrderPoints.Add(orderPoints[c]);
                    c++;
                }
                //////////////////////////////////
                if (axis == Axis.X)
                {
                    TreeNode.LeftSubTree = Make_KD_Tree(leftOrderPoints, topLeftX, topLeftY, leftOrderPoints.Last().X, bottomRightY, Axis.Y);
                    TreeNode.RightSubTree = Make_KD_Tree(rightOrderPoints, rightOrderPoints.First().X, topLeftY, bottomRightX, bottomRightY, Axis.Y);
                }
                else
                {
                    TreeNode.LeftSubTree = Make_KD_Tree(leftOrderPoints, topLeftX, topLeftY, bottomRightX, rightOrderPoints.Last().Y, Axis.X);
                    TreeNode.RightSubTree = Make_KD_Tree(rightOrderPoints, topLeftX, rightOrderPoints.First().Y, bottomRightX, bottomRightY, Axis.X);
                }
                return TreeNode;
            }
        }
    }

}

