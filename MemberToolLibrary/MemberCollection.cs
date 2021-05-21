using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace MemberToolLibrary
{
    /// <summary>
    /// This class creates a Node type object which stores the data of a member,
    /// and 2 nodes within itself. The left child and right child replicate pointer
    /// types of a linked list / binary search tree.
    /// </summary>
    public class Node
    {
        /// A private variable that stores a member.
        private Member member;
        /// A private variable that stores another Node object.
        private Node lchild;
        /// A private variable that stores another Node object.
        private Node rchild;

        /// Constructor object that creates a new Node type object and stores the
        /// param Member object within.
        public Node(Member item)
        {
            this.member = item;
            lchild = null;
            rchild = null;
        }

        /// Returns a member object stored in member, or sets the value of member.
        public Member GetMember
        {
            get { return member; }
            set { member = value; }
        }

        /// Returns a node object stored in lchild, or sets the value of lchild.
        public Node LChild
        {
            get { return lchild; }
            set { lchild = value; }
        }

        /// Returns a node object stores in rchild, or sets the value of rchild.
        public Node RChild
        {
            get { return rchild; }
            set { rchild = value; }
        }
    }

    /// <summary>
    /// A class that creates a collection of Members within a Binary Search Tree.
    /// The class implements a Node object, and stores further members within the nodes left
    /// or right children. These nodes recur within one another to build the tree of nodes.
    /// This class has the ability to add a new Member, remove a Member, search for the existence of
    /// a Member and return an array of Member type objects of Members within the system.
    /// </summary>
    public class MemberCollection : iMemberCollection
    {
        /// A private variable that stores the root Node of the Member system.
        private Node root;
        /// A private variable that store the number of Members within the system.
        private int number = 0;
        /// A function that returns the number of Members within the system.
        public int Number => number;
        /// A private list of Member type objects, used for storing members before converting to an array.
        private List<Member> memberList = new List<Member>();

        /// Constructor for the class, initialising the root node as null.
        public MemberCollection()
        {
            root = null;
        }

        /// <summary>
        /// This fuction adds a Member type object to the root node.
        /// If the node already contains a member, calls the overloaded
        /// add function.
        /// </summary>
        /// <param name="member"> A Member type object. </param>
        public void add(Member member)
        {
            /// If the root Node current is null.
            if (root == null)
            {
                /// Assign a Node to the root that contains the first member.
                root = new Node(member);
            }
            /// If the root already has a Node assigned.
            else
            {
                /// Call the overload method.
                add(member, root);
            }
        }

        /// <summary>
        /// This is the param overload function for adding a member.
        /// Given the root already contains a node, it takes a Member object
        /// and a node to check for comparisons, if the child node is null, will
        /// assign the member to such node, otherwise uses recursion to process
        /// the comparison with the child node. This function uses a comparison
        /// function labeled "Compare" which returns an integer based on the alphabetical
        /// values of the two members names (lastname/firstname ordered).
        /// </summary>
        /// <param name="member"> A Member type object. </param>
        /// <param name="currentNode"> A Node type object. </param>
        private void add(Member member, Node currentNode)
        {
            /// If the member you are trying to add to the system already exists.
            if (Compare(member, currentNode.GetMember) == 0)
            {
                /// Returns an error that the user already exists.
                throw new InvalidOperationException("This user already exists.");
            }
            /// If the added user is not the current node.
            else
            {
                /// If the compared name of the added member is before the current node member (alphabetically, lastname/firstname ordered)
                if (Compare(member, currentNode.GetMember) < 0)
                {
                    /// If the left child node is empty.
                    if (currentNode.LChild == null)
                    {
                        /// Assigns the member to the empty node.
                        currentNode.LChild = new Node(member);
                    }
                    /// If the child node contains a member, recalls this function
                    /// with the child node member.
                    else
                    {
                        /// Calls the function again using the child node.
                        add(member, currentNode.LChild);
                    }
                }
                /// If the compared name of the added member is after the current member alphabetically.
                else
                {
                    /// If the right node is empty
                    if (currentNode.RChild == null)
                    {
                        /// Assign the added member to the right node.
                        currentNode.RChild = new Node(member);
                    }
                    /// If the right node contains a member
                    else
                    {
                        /// Calls the function again processing the child node.
                        add(member, currentNode.RChild);
                    }
                }
            }
        }

        /// <summary>
        /// This function removes a member from the binary search tree.
        /// It then re-organises the search tree by moving the child nodes of the
        /// deleted node into order.
        /// </summary>
        /// <param name="aMember"> A Member type object. </param>
        public void delete(Member aMember)
        {
            /// Assigns a the tree to a new Node for reference.
            Node currentNode = root;
            /// Assigns a null value to a variable that repreents the parents of the current node.
            Node parent = null;

            /// While node isn't null and the comparison between the delete member and current node is not matching.
            /// This function essentially searches the tree for the member to delete, and stores it and its parent into
            /// the two variables.
            while ((currentNode != null) && (Compare(aMember, currentNode.GetMember) != 0))
            {
                /// Assign the current node as the parents
                parent = currentNode;
                /// If the searching member is before the current member, go to the left child of the current node
                if (Compare(aMember, currentNode.GetMember) < 0)
                    currentNode = currentNode.LChild;
                /// If the searching member is after the current member, go to the right child of the current node.
                else
                    currentNode = currentNode.RChild;
            }

            /// If the search is successful
            if (currentNode != null)
            {
                /// If the matching node has both a left and right child
                if ((currentNode.LChild != null) && (currentNode.RChild != null))
                {
                    /// Finds the most far right node in the left sub-tree

                    /// In a special case where the first right-node of the left sub-tree is empty
                    if (currentNode.LChild.RChild == null)
                    {
                        /// Assigns the deleted node as the left child node
                        currentNode.GetMember = currentNode.LChild.GetMember;
                        currentNode.LChild = currentNode.LChild.LChild;
                    }

                    /// If the left sub-tree has a right node with value
                    else
                    {
                        /// Assigns node with the deleted node lchild node.
                        Node lChild = currentNode.LChild;
                        /// Assing node with the parent of lchild node.
                        Node lChildParent = currentNode;
                        /// Moves all the right child nodes up to the current parent.
                        while (lChild.RChild != null)
                        {
                            lChildParent = lChild;
                            lChild = lChild.RChild;
                        }
                        /// Overides the deleted member with the processed nodes
                        currentNode.GetMember = lChild.GetMember;
                        lChildParent.RChild = lChild.LChild;
                    }
                }
                /// If the deleted node has 1 or no child nodes.
                else
                {
                    /// Creates an empty child node.
                    Node child;
                    /// If the left child of the deleted node holds values
                    if (currentNode.LChild != null)
                        /// Assign the left child to the empty node.
                        child = currentNode.LChild;
                    /// If the deleted node has no Left child, it must have a Right child.
                    else
                        /// Assign the right child to the empty node.
                        child = currentNode.RChild;

                    /// Removes the current node

                    /// If the deleted node is the root node
                    if (currentNode == root)
                        /// Make the deleted node the child.
                        root = child;
                    /// Otherwise
                    else
                    {
                        /// If the current node is the parent node left child
                        if (currentNode == parent.LChild)
                            ///Assign the left child as child
                            parent.LChild = child;
                        /// Otherwise it must be the right child node.
                        else
                            /// Assign the right child as child node.
                            parent.RChild = child;
                    }
                }
            }
            /// If the node is not found
            else
            {
                /// Returns an error that the user does not exist.
                throw new InvalidOperationException("This user does not exist.");
            }
        }

        /// <summary>
        /// This function returns all the member type objects as an error.
        /// </summary>
        /// <returns> A Member[] of members within the system. </returns>
        public Member[] toArray()
        {
            /// If there is a member within the system
            if (root != null)
            {
                /// Uses an InOrderTraverse to go through the tree
                InOrderTraverse(root.LChild);
                /// And add the members to the membersList
                memberList.Add(root.GetMember);
                InOrderTraverse(root.RChild);
            }
            /// Returns memberList as an array.
            return memberList.ToArray();
        }

        /// <summary>
        /// This function searches the Binary Search Tree of node for a member.
        /// </summary>
        /// <param name="member"></param>
        /// <returns> Returns a boolean value if the member exists. </returns>
        public bool search(Member member)
        {
            /// Calls the private function with the root Node
            return search(member, root);
        }

        /// <summary>
        /// Overloaded Search Method
        /// </summary>
        /// <param name="member"> Member type object to search. </param>
        /// <param name="currentNode"> A Node type object, starting at root Node. </param>
        /// <returns> Returns a boolean value if the Member is found. </returns>
        private bool search(Member member, Node currentNode)
        {
            /// If the node is not empty
            if (currentNode != null)
            {
                /// If the searched member is the same as the currentNode member
                if (Compare(member, currentNode.GetMember) == 0)
                {
                    /// Return true! The member does exist.
                    return true;
                }

                /// If the member and the currentNode member are not the same
                else
                {
                    /// Compare the two member names, if the searched member is before the currentNode member.
                    if (Compare(member, currentNode.GetMember) < 0)
                    {
                        /// Use recursion to search the left child of the currentNode
                        return search(member, currentNode.LChild);
                    }
                    /// Otherwise, the search member is after the current node member
                    else
                    {
                        /// Search the right child of the currentNode
                        return search(member, currentNode.RChild);
                    }
                }
            }
            /// If the search completes, and member is not found.
            else
            {
                /// Return false, the member does not exist.
                return false;
            }
        }

        /// <summary>
        /// A function that iterates through a binary search tree using the
        /// in order traversal method. 
        /// </summary>
        /// <param name="node"> A node type object. </param>
        private void InOrderTraverse(Node node)
        {
            /// If the current node is not empty
            if (node != null)
            {
                /// Expand the left node, once it returns
                InOrderTraverse(node.LChild);
                /// Add the current node to the list
                memberList.Add(node.GetMember);
                /// Traverse the right node
                InOrderTraverse(node.RChild);
            }
        }


        /// <summary>
        /// A private function that returns an int based on the
        /// comparison between 2 member type objects. If both
        /// params have the same first and last name, it returns 0.
        /// Otherwise, it returns -1 if the first member comes before
        /// the second member alphabetically, or returns 1 if the first
        /// member comes after the second member alphabetically.
        /// </summary>
        /// <param name="a"> A Member Type object </param>
        /// <param name="b"> A Member Type object </param>
        /// <returns> An int that if 0: Members are the same, -1: Member a comes before Member b, 1: Member a comes after Member b.</returns>
        private int Compare(Member a, Member b)
        {
            /// If the Last Name of both members is the same
            if (string.Compare(a.LastName, b.LastName) == 0)
            {
                /// If the First Name of both members is the same
                if (string.Compare(a.FirstName, b.FirstName) == 0)
                {
                    /// Returns 0
                    return 0;
                }

                /// If the First Names are not the same
                else
                {
                    /// If the first member comes before the second member
                    if (string.Compare(a.FirstName, b.FirstName) < 0)
                    {
                        /// Returns -1
                        return -1;
                    }

                    /// Otherwise
                    else
                    {
                        /// Must come after, so return 1.
                        return 1;
                    }
                }
            }
            /// If the Last Names are not the same
            else
            {
                /// If the first members last name comes before the second
                if (string.Compare(a.LastName, b.LastName) < 0)
                {
                    /// Return -1
                    return -1;
                }
                /// Otherwise, must come after
                else
                {
                    /// Return 1
                    return 1;
                }
            }
        }
    }
}
