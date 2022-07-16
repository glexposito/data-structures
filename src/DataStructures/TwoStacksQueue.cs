namespace DataStructures.Queues
{
    public class TwoStacksQueue<T>
    {
        private readonly Stack<T> _input;
        private readonly Stack<T> _output;

        public TwoStacksQueue()
        {
            _input = new Stack<T>();
            _output = new Stack<T>();
        }

        public bool IsEmpty()
        {
            return !_output.Any() && !_input.Any();
        }

        public void Enqueue(T iten)
        {
            _input.Push(iten);
        }

        public T Dequeue()
        {
            PushItemsToOutput();

            return _output.Pop();
        }

        public T Peek()
        {
            PushItemsToOutput();

            return _output.Peek();
        }

        private void PushItemsToOutput()
        {
            if (!_output.Any())
            {
                while (_input.Any())
                {
                    _output.Push(_input.Pop());
                }
            }
        }
    }
}
