using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeDemo
{
    class BinarySearchTree<T> where T: IComparable<T>
    {
        public T NodeData { get; set; }
        public BinarySearchTree<T> leftTree { get; set; }
        public BinarySearchTree<T> rightTree { get; set; }

        public BinarySearchTree(T nodeData)
        {
            this.NodeData = nodeData;
            this.rightTree = null;
            this.leftTree = null;

        }

        int leftCount = 0, rightCount = 0;
        bool resul = false;
        public void Insert(T item)
        {
            T CurrentNodeValue = this.NodeData;
            if((CurrentNodeValue.CompareTo(item))>0)
            {
                if (this.leftTree == null)
                    this.leftTree = new BinarySearchTree<T>(item);
                else
                    this.leftTree.Insert(item);
            }
            else
            {
                if (this.rightTree == null)
                    this.rightTree = new BinarySearchTree<T>(item);
                else
                    this.rightTree.Insert(item);
            }
        }
        public void Display()
        {
            if (this.leftTree != null)
            {
                this.leftCount++;
                this.leftTree.Display();
            }
            Console.WriteLine(this.NodeData.ToString());
            if(this.rightTree != null)
            {
                this.rightCount++;
                this.rightTree.Display();
            }

        }
        public void GetSize()
        {
            Console.WriteLine("Size" + " " + (1 + this.leftCount + this.rightCount));
        }
        public bool IFExists(T element,BinarySearchTree<T> node)
        {
            if(node == null)
            {
                return false;
            }
            if(node.NodeData.Equals(element))
            {
                Console.WriteLine("found the element in BST" + " " + node.NodeData);
                resul = true; 
            }
            else
            {
                Console.WriteLine("Current element in {0} in BST", node.NodeData);
            }
            if(element.CompareTo(node.NodeData)<0)
            {
                IFExists(element, node.leftTree);
            }
            if(element.CompareTo(node.NodeData)>0)
            {
                IFExists(element, node.rightTree);
            }
            return resul;
        }
    }
}
