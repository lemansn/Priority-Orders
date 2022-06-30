namespace YeniProje
{
    //Mahalle tipinde elemanları kendinde tutan Yığit(Stack) sınıfı yazılmıştır.
    //Ekleme, silme, bosmu metotları yazılmıştır.
    public class Stack
    {

        private int maxSize;

        private Mahalle[] stackArray;

        private int top;

        public Stack(int s)
        {
            maxSize = s;
            stackArray = new Mahalle[maxSize]; 
            top = -1;
        }

        public void push(Mahalle j)
        {
            stackArray[++top] = j;
        }

        public Mahalle pop()
        {
            return stackArray[top--]; 
        }


        public bool isEmpty()
        {
            return (top == -1);
        }


    }
}