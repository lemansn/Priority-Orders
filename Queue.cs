namespace YeniProje
{
    //Kuyruk classı, yapılandırıcı metotu ve bize gerekli olan ekleme silme bosMu metotları yazılmıştır.
    //!!!Bu class’ı hem Mahalle hem de İnt tipinde kullanabilmek için hocadan onay alarak Generic yazdım. 
    public class Queue<T>
    {

        public int maxSize;
        public T[] queArray;
        public int front;
        public int rear;
        public int nItems;

        public Queue(int s)
        {
            maxSize = s;
            queArray = new T[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }

        public void insert(T j)
        {
            if (rear == maxSize - 1)
                rear = -1;
            queArray[++rear] = j;
            nItems++;
        }

        public T remove()
        {
            T temp = queArray[front++];
            if (front == maxSize)
                front = 0;
            nItems--;
            return temp;
        }

        public bool isEmpty()
        {
            return (nItems == 0);
        }


    }
} 
     