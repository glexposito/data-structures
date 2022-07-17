namespace DataStructures.Collections
{
    public class MyStack<T>
    {
        private Queue<T> _queue;
        private Queue<T> _auxQueue;

        public MyStack()
        {
            _queue = new Queue<T>();
            _auxQueue = new Queue<T>();
        }

        public bool IsEmpty()
        {
            return !_queue.Any();
        }

        public void Push(T item)
        {
            _auxQueue.Enqueue(item);
            
            while (_queue.Any())
            {
                _auxQueue.Enqueue(_queue.Dequeue());
            }

            (_queue, _auxQueue) = (_auxQueue, _queue);
        }

        public T Pop()
        {
            return _queue.Dequeue();
        }

        public T Top()
        {
            return _queue.Peek();
        }
    }
}
