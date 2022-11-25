using System;
using System.Collections;

namespace SearchAlgo
{
    class MyQueue
    {
        private int[,] queue = new int[10000,2];
        private int rear;
        private int pointer;

        public MyQueue()
        {
            rear = 0;
            pointer = 0;
        }

        public void enque(int Q, int origin)
        {
            queue[rear,0] = Q;
            queue[rear,1] = origin;
            rear++;
        }

        public Boolean contains(int x)
        {
            for (int i = 0; i < rear; i++)
            {
                if (this.queue[i,1] == x)
                    return true;
            }
            return false;
        }

        public void displayQueue()
        {
            Console.WriteLine("Queue: ");
            for (int i = 0; i < rear; i++)
            {
                Console.WriteLine(queue[i,0] + " " + queue[i,1]);
            }
        }

        public int next(int origin)
        {
            origin = queue[pointer++,0];
            return origin;
        }

        public int findPosQ(int path)
        {
            int i = rear - 1;
            int pos = 0;
            while (i >= 0)
            {
                if (queue[i,0] == path)
                {
                    pos = i;
                    break;
                }
                i--;
            }
            return pos;
        }

        public void displayPath(int start, int goal)
        {
            int path = goal;
            Console.WriteLine("Path:");
            while (path != start)
            {
                Console.WriteLine(path);
                path = queue[findPosQ(path),1];
            }
            Console.WriteLine(start);
        }

        public ArrayList getPath(int start, int goal)
        {
            var arr = new ArrayList();
            int path = goal;
            while (path != start)
            {
                arr.Add(path);
                path = queue[findPosQ(path), 1];
            }
            arr.Add(start);

            return arr;
        }
    }
}
