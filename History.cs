using System;
using System.Collections.Generic;
using System.Text;

namespace Helpdesk
{
    class History
    {
        protected HistLLNode prev;
        protected HistLLNode futur;

        protected class HistLLNode
        {
            public string Data;
            public HistLLNode Next;

            public HistLLNode(string data)
            {
                Data = data;
            }

            public HistLLNode(string data, HistLLNode next): this(data)
            {
                Next = next;
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("History:");
            Console.WriteLine("Previously visited pages:");
            HistLLNode tempprev = prev;
            while (tempprev != null)
            {
                Console.WriteLine(tempprev.Data);
                tempprev = tempprev.Next;
            }
            Console.WriteLine("Pages in your 'future':");
            HistLLNode tempfutur = futur;
            while (tempfutur != null)
            {
                Console.WriteLine(tempfutur.Data);
                tempfutur = tempfutur.Next;
            }
        }

        public void MoveBackwards()
        {
            if ( prev != null)
            {
                HistLLNode bleh = prev;
                prev = prev.Next;

                bleh.Next = futur;
                futur = bleh;
            }
        }

        public void MoveForwards()
        {
            
            if ( futur != null)
            {
                HistLLNode bleh = futur;
                futur = futur.Next;
                
                bleh.Next = prev;
                prev = bleh;
            }
        }
        
        public void VisitPage(string desc)
        {
            if (futur != null)
                futur = null;
            HistLLNode temp = new HistLLNode(desc);
            temp.Next = prev;
            prev = temp;
        }
    }
}
