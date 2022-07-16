using DataStructures.Queues;
using System.Reflection;

namespace DataStructures.UnitTests
{
    public class TwoStacksQueueTest
    {
        private readonly TwoStacksQueue<int> _twoStacksQueue;
        private Stack<int> _inputStack;
        private Stack<int> _outputStack;

        public TwoStacksQueueTest()
        {
            _inputStack = new Stack<int>();
            _outputStack = new Stack<int>();

            _twoStacksQueue = new TwoStacksQueue<int>();

            FieldInfo? inputField = typeof(TwoStacksQueue<int>).GetField("_input", BindingFlags.NonPublic | BindingFlags.Instance);
            inputField?.SetValue(_twoStacksQueue, _inputStack);

            FieldInfo? outputField = typeof(TwoStacksQueue<int>).GetField("_output", BindingFlags.NonPublic | BindingFlags.Instance);
            outputField?.SetValue(_twoStacksQueue, _outputStack);
        }

        [Fact]
        public void IsEmpty_When_EmptyInputStack_And_EmptyOutputStack_Returns_True()
        {
            var result = _twoStacksQueue.IsEmpty();

            Assert.True(result);
        }

        [Fact]
        public void IsEmpty_When_EmptyInputStack_And_NonEmptyOutputStack_Returns_False()
        {
            _inputStack.Push(0);

            var result = _twoStacksQueue.IsEmpty();

            Assert.False(result);
        }

        [Fact]
        public void IsEmpty_When_NonEmptyInputStack_And_EmptyOutputStack_Returns_False()
        {
            _outputStack.Push(0);

            var result = _twoStacksQueue.IsEmpty();

            Assert.False(result);
        }

        [Fact]
        public void Enqueue_AddItem()
        {
            var item = 0;

            _twoStacksQueue.Enqueue(item);

            Assert.True(item == _inputStack.Peek());
        }

        [Fact]
        public void Dequeue_Removes_And_Returns_FirstEnteredItem()
        {
            var firstItem = 1;
            var secondItem = 2;

            _inputStack.Push(firstItem);
            _inputStack.Push(secondItem);

            var removedItem = _twoStacksQueue.Dequeue();

            Assert.True(removedItem == firstItem && _outputStack.Count == 1);
        }

        [Fact]
        public void Peek_Returns_FirstEnteredItem()
        {
            var firstItem = 1;
            var secondItem = 2;

            _inputStack.Push(firstItem);
            _inputStack.Push(secondItem);

            var returnedItem = _twoStacksQueue.Peek();

            Assert.True(returnedItem == firstItem && _outputStack.Count == 2);
        }
    }
}