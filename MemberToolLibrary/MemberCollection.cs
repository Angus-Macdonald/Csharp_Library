using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace MemberToolLibrary
{
    public class Node
    {
        private Member item; // value
        private Node lchild; // reference to its left child 
        private Node rchild; // reference to its right child

        public Node(Member item)
        {
            this.item = item;
            lchild = null;
            rchild = null;
        }

        public Member Item
        {
            get { return item; }
            set { item = value; }
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
        public List<Member> memberList = new List<Member>();

        public MemberCollection()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public int Com(Member a, Member b)
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

        public int memberLogin(Member item)
        {
            return memberLogin(item, root);
        }

        public int memberLogin(Member item, Node r)
        {
            if (r != null)
            {
                if (Com(item, r.Item) == 0)
                {
                    if(item.PIN == r.Item.PIN)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                else
                {
                    if (Com(item, r.Item) < 0)
                    {
                        return memberLogin(item, r.LChild);
                    }
                    else
                    {
                        return memberLogin(item, r.RChild);
                    }
                }
            }
            else
            {
                return -1;
            }
        }

        public bool search(Member item)
        {
            return search(item, root);
        }

        private bool search(Member item, Node r)
        {
            if (r != null)
            {
                if (Com(item, r.Item) == 0)
                {
                    return true;
                }

                else
                {
                    if (Com(item, r.Item) < 0)
                    {
                        return search(item, r.LChild);
                    }
                    else
                    {
                        return search(item, r.RChild);
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public void add(Member item)
        {
            if (root == null)
            {
                root = new Node(item);
                memberList.Add(item);
            }
            else
            {
                add(item, root);
            }
        }

        // pre: ptr != null
        // post: item is inserted to the binary search tree rooted at ptr
        private void add(Member item, Node ptr)
        {
            if (Com(item, ptr.Item) == 0)
            {
                throw new InvalidOperationException("This user already exists.");
            }
            else
            {
                if (Com(item, ptr.Item) < 0)
                {
                    if (ptr.LChild == null)
                    {
                        ptr.LChild = new Node(item);
                        memberList.Add(item);
                    }
                    else
                    {
                        add(item, ptr.LChild);
                    }
                }
                else
                {
                    if (ptr.RChild == null)
                    {
                        ptr.RChild = new Node(item);
                        memberList.Add(item);
                    }
                    else
                    {
                        add(item, ptr.RChild);
                    }
                }
            }
        }

        public void delete(Member aMember)
        {
            Node ptr = root; // search reference
            Node parent = null; // parent of ptr
            while ((ptr != null) && (Com(aMember,ptr.Item) != 0))
            {
                parent = ptr;
                if (Com(aMember,ptr.Item) < 0) // move to the left child of ptr
                    ptr = ptr.LChild;
                else
                    ptr = ptr.RChild;
            }

            if (ptr != null) // if the search was successful
            {
                memberList.Remove(ptr.Item);
                // case 3: item has two children
                if ((ptr.LChild != null) && (ptr.RChild != null))
                {
                    // find the right-most node in left subtree of ptr
                    if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
                    {
                        ptr.Item = ptr.LChild.Item;
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
                        ptr.Item = p.Item;
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
                Console.WriteLine("This user does not exist.");
            }
        }

        public void addToolToMember(Member member, Tool aTool)
        {
            if(root == null)
            {
                Console.WriteLine("No members exist");
            }
            else
            {
                addToolToMember(member, aTool, root);
            }
        }

        public void addToolToMember(Member member, Tool aTool, Node r)
        {
            if (r != null)
            {
                if (Com(member, r.Item) == 0)
                {
                    r.Item.addTool(aTool);
                }

                else
                {
                    if (Com(member, r.Item) < 0)
                    {
                        addToolToMember(member, aTool, r.LChild);
                    }
                    else
                    {
                        addToolToMember(member, aTool, r.RChild);
                    }
                }
            }
            else
            {
                Console.WriteLine("This user could not be found");
            }
        }

        public Member getMember(Member item)
        {
            return getMember(item, root);
        }

       private Member getMember(Member item, Node r)
        {
            
            if (search(item))
            {
                if (Com(item, r.Item) == 0)
                {
                    return r.Item;
                }

                else
                {
                    if (Com(item, r.Item) < 0)
                    {
                        return getMember(item, r.LChild);
                    }
                    else
                    {
                        return getMember(item, r.RChild);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public Member[] toArray()
        {
            return memberList.ToArray();
        }
    }
}
