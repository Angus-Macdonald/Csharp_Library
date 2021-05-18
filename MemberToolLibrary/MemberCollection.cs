using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace MemberToolLibrary
{
    public class Node
    {
        private Member member; // value
        private Node lchild; // reference to its left child 
        private Node rchild; // reference to its right child

        public Node(Member item)
        {
            this.member = item;
            lchild = null;
            rchild = null;
        }

        public Member GetMember
        {
            get { return member; }
            set { member = value; }
        }

        public Node LChild
        {
            get { return lchild; }
            set { lchild = value; }
        }

        public Node RChild
        {
            get { return rchild; }
            set { rchild = value; }
        }
    }

    public class MemberCollection : iMemberCollection
    {
        private Node root;
        private int number = 0;
        public int Number => number;

        private List<Member> memberList = new List<Member>();

        public MemberCollection()
        {
            root = null;
        }

        public void add(Member member)
        {
            if (root == null)
            {
                root = new Node(member);
            }
            else
            {
                add(member, root);
            }
        }

        private void add(Member member, Node ptr)
        {
            if (Compare(member, ptr.GetMember) == 0)
            {
                throw new InvalidOperationException("This user already exists.");
            }
            else
            {
                if (Compare(member, ptr.GetMember) < 0)
                {
                    if (ptr.LChild == null)
                    {
                        ptr.LChild = new Node(member);
                    }
                    else
                    {
                        add(member, ptr.LChild);
                    }
                }
                else
                {
                    if (ptr.RChild == null)
                    {
                        ptr.RChild = new Node(member);
                    }
                    else
                    {
                        add(member, ptr.RChild);
                    }
                }
            }
        }

        public void delete(Member aMember)
        {
            Node ptr = root; // search reference
            Node parent = null; // parent of ptr
            while ((ptr != null) && (Compare(aMember, ptr.GetMember) != 0))
            {
                parent = ptr;
                if (Compare(aMember, ptr.GetMember) < 0) // move to the left child of ptr
                    ptr = ptr.LChild;
                else
                    ptr = ptr.RChild;
            }

            if (ptr != null) // if the search was successful
            {
                // case 3: item has two children
                if ((ptr.LChild != null) && (ptr.RChild != null))
                {
                    // find the right-most node in left subtree of ptr
                    if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
                    {
                        ptr.GetMember = ptr.LChild.GetMember;
                        ptr.LChild = ptr.LChild.LChild;
                    }
                    else
                    {
                        Node p = ptr.LChild;
                        Node pp = ptr; // parent of p
                        while (p.RChild != null)
                        {
                            pp = p;
                            p = p.RChild;
                        }
                        // copy the item at p to ptr
                        ptr.GetMember = p.GetMember;
                        pp.RChild = p.LChild;
                    }
                }
                else // cases 1 & 2: item has no or only one child
                {
                    Node c;
                    if (ptr.LChild != null)
                        c = ptr.LChild;
                    else
                        c = ptr.RChild;

                    // remove node ptr
                    if (ptr == root) //need to change root
                        root = c;
                    else
                    {
                        if (ptr == parent.LChild)
                            parent.LChild = c;
                        else
                            parent.RChild = c;
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("This user does not exist.");
            }
        }

        public Member[] toArray()
        {
            if (root != null)
            {
                InOrderTraverse(root.LChild);
                memberList.Add(root.GetMember);
                InOrderTraverse(root.RChild);
            }

            return memberList.ToArray();
        }

        public bool search(Member member)
        {
            return search(member, root);
        }

        private bool search(Member member, Node currentNode)
        {
            if (currentNode != null)
            {
                if (Compare(member, currentNode.GetMember) == 0)
                {
                    return true;
                }

                else
                {
                    if (Compare(member, currentNode.GetMember) < 0)
                    {
                        return search(member, currentNode.LChild);
                    }
                    else
                    {
                        return search(member, currentNode.RChild);
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private void InOrderTraverse(Node root)
        {
            if (root != null)
            {
                InOrderTraverse(root.LChild);
                memberList.Add(root.GetMember);
                InOrderTraverse(root.RChild);
            }
        }

        private int Compare(Member a, Member b)
        {
            if (string.Compare(a.LastName, b.LastName) == 0)
            {
                if (string.Compare(a.FirstName, b.FirstName) == 0)
                {
                    return 0;
                }

                else
                {
                    if (string.Compare(a.FirstName, b.FirstName) < 0)
                    {
                        return -1;
                    }

                    else
                    {
                        return 1;
                    }
                }
            }
            else
            {
                if (string.Compare(a.LastName, b.LastName) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
