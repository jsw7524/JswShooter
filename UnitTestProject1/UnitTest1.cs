using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WindowsFormsApp1;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Make_KD_Tree_1()
        {
            DataStructure ds = new DataStructure();
            ds.Points.Add(new Point(100, 100));

            var root = ds.Make_KD_Tree(ds.Points, 0, 0, 1000, 1000, DataStructure.Axis.X);

            var ans = JsonConvert.SerializeObject(root);
            Assert.AreEqual(ans,"{\"ThePoint\":{\"X\":100,\"Y\":100},\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null}");
        }
        [TestMethod]
        public void Make_KD_Tree_2()
        {
            DataStructure ds = new DataStructure();
            ds.Points.Add(new Point(100, 100));
            ds.Points.Add(new Point(200, 150));
            var root=ds.Make_KD_Tree(ds.Points,0,0,1000,1000,DataStructure.Axis.X);

            var ans=JsonConvert.SerializeObject(root);
            Assert.AreEqual(ans,"{\"ThePoint\":null,\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":{\"X\":100,\"Y\":100},\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":100,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null},\"RightSubTree\":{\"ThePoint\":{\"X\":200,\"Y\":150},\"TopLeftX\":200,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null}}");
        }

        [TestMethod]
        public void Make_KD_Tree_3()
        {
            DataStructure ds = new DataStructure();
            ds.Points.Add(new Point(100, 100));
            ds.Points.Add(new Point(200, 150));
            ds.Points.Add(new Point(200, 350));
            var root = ds.Make_KD_Tree(ds.Points, 0, 0, 1000, 1000, DataStructure.Axis.X);

            var ans = JsonConvert.SerializeObject(root);
            Assert.AreEqual(ans, "{\"ThePoint\":null,\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":{\"X\":100,\"Y\":100},\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":100,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null},\"RightSubTree\":{\"ThePoint\":null,\"TopLeftX\":200,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":{\"X\":200,\"Y\":150},\"TopLeftX\":200,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":350,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null},\"RightSubTree\":{\"ThePoint\":{\"X\":200,\"Y\":350},\"TopLeftX\":200,\"TopLeftY\":350,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null}}}");
        }

        [TestMethod]
        public void Make_KD_Tree_4()
        {
            DataStructure ds = new DataStructure();
            ds.Points.Add(new Point(200, 150));
            ds.Points.Add(new Point(100, 100));
            ds.Points.Add(new Point(600, 350));
            ds.Points.Add(new Point(200, 350));
            var root = ds.Make_KD_Tree(ds.Points, 0, 0, 1000, 1000, DataStructure.Axis.X);

            var ans = JsonConvert.SerializeObject(root);
            Assert.AreEqual(ans, "{\"ThePoint\":null,\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":null,\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":200,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":{\"X\":100,\"Y\":100},\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":200,\"BottomRightY\":150,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null},\"RightSubTree\":{\"ThePoint\":{\"X\":200,\"Y\":150},\"TopLeftX\":0,\"TopLeftY\":150,\"BottomRightX\":200,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null}},\"RightSubTree\":{\"ThePoint\":null,\"TopLeftX\":200,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":{\"X\":200,\"Y\":350},\"TopLeftX\":200,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":350,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null},\"RightSubTree\":{\"ThePoint\":{\"X\":600,\"Y\":350},\"TopLeftX\":200,\"TopLeftY\":350,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null}}}");
        }

        [TestMethod]
        public void Make_KD_Tree_5()
        {
            DataStructure ds = new DataStructure();
            ds.Points.Add(new Point(800, 100));
            ds.Points.Add(new Point(200, 150));
            ds.Points.Add(new Point(100, 100));
            ds.Points.Add(new Point(600, 350));
            ds.Points.Add(new Point(200, 350));
            var root = ds.Make_KD_Tree(ds.Points, 0, 0, 1000, 1000, DataStructure.Axis.X);

            var ans = JsonConvert.SerializeObject(root);
            Assert.AreEqual(ans, "{\"ThePoint\":null,\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":null,\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":200,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":{\"X\":100,\"Y\":100},\"TopLeftX\":0,\"TopLeftY\":0,\"BottomRightX\":200,\"BottomRightY\":150,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null},\"RightSubTree\":{\"ThePoint\":{\"X\":200,\"Y\":150},\"TopLeftX\":0,\"TopLeftY\":150,\"BottomRightX\":200,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null}},\"RightSubTree\":{\"ThePoint\":null,\"TopLeftX\":200,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":{\"X\":800,\"Y\":100},\"TopLeftX\":200,\"TopLeftY\":0,\"BottomRightX\":1000,\"BottomRightY\":350,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null},\"RightSubTree\":{\"ThePoint\":null,\"TopLeftX\":200,\"TopLeftY\":350,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":false,\"LeftSubTree\":{\"ThePoint\":{\"X\":200,\"Y\":350},\"TopLeftX\":200,\"TopLeftY\":350,\"BottomRightX\":200,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null},\"RightSubTree\":{\"ThePoint\":{\"X\":600,\"Y\":350},\"TopLeftX\":600,\"TopLeftY\":350,\"BottomRightX\":1000,\"BottomRightY\":1000,\"IsLeaf\":true,\"LeftSubTree\":null,\"RightSubTree\":null}}}}");
        }


        [TestMethod]
        public void SearchKdTree_1()
        {
            DataStructure ds = new DataStructure();
            ds.Points.Add(new Point(100, 100));
            ds.Points.Add(new Point(200, 150));
            ds.Points.Add(new Point(200, 350));
            var root = ds.Make_KD_Tree(ds.Points, 0, 0, 1000, 1000, DataStructure.Axis.X);

            var ans = ds.Search_KD_Tree(root, 0, 0, 1000, 1000);
            Assert.AreEqual(ans.Count, 3);
        }

        [TestMethod]
        public void SearchKdTree_2()
        {
            DataStructure ds = new DataStructure();
            ds.Points.Add(new Point(100, 100));
            ds.Points.Add(new Point(200, 200));
            ds.Points.Add(new Point(300, 300));
            ds.Points.Add(new Point(400, 400));
            ds.Points.Add(new Point(500, 500));
            var root = ds.Make_KD_Tree(ds.Points, 0, 0, 1000, 1000, DataStructure.Axis.X);

            var ans = ds.Search_KD_Tree(root, 150, 150, 350, 350);
            Assert.AreEqual(ans.Count, 2);
        }

        [TestMethod]
        public void SearchKdTree_3()
        {
            DataStructure ds = new DataStructure();
            ds.Points.Add(new Point(100, 100));
            ds.Points.Add(new Point(200, 200));
            ds.Points.Add(new Point(300, 300));
            ds.Points.Add(new Point(400, 400));
            ds.Points.Add(new Point(500, 500));
            var root = ds.Make_KD_Tree(ds.Points, 0, 0, 1000, 1000, DataStructure.Axis.X);

            var ans = ds.Search_KD_Tree(root, 150, 150, 450, 450);
            Assert.AreEqual(ans.Count, 3);
        }
    }
}
