using DataStructures.Collections;
using System.Reflection;

namespace DataStructures.UnitTests
{
    public class MyQueueTest
    {
        private readonly MyQueue<int> _queue;
        private readonly Stack<int> _inputStack;
        private readonly Stack<int> _outputStack;

        public MyQueueTest()
        {
            _inputStack = new Stack<int>();
            _outputStack = new Stack<int>();

            _queue = new MyQueue<int>();

            FieldInfo? inputField = typeof(MyQueue<int>).GetField("_input", BindingFlags.NonPublic | BindingFlags.Instance);
            inputField?.SetValue(_queue, _inputStack);

            FieldInfo? outputField = typeof(MyQueue<int>).GetField("_output", BindingFlags.NonPublic | BindingFlags.Instance);
            outputField?.SetValue(_queue, _outputStack);
        }

        [Fact]
        public void IsEmpty_When_EmptyInputStack_And_EmptyOutputStack_Returns_True()
        {
            var result = _queue.IsEmpty();

            Assert.True(result);
        }

        [Fact]
        public void IsEmpty_When_EmptyInputStack_And_NonEmptyOutputStack_Returns_False()
        {
            _inputStack.Push(0);

            var result = _queue.IsEmpty();

            Assert.False(result);
        }

        [Fact]
        public void IsEmpty_When_NonEmptyInputStack_And_EmptyOutputStack_Returns_False()
        {
            _outputStack.Push(0);

            var result = _queue.IsEmpty();

            Assert.False(result);
        }

        [Fact]
        public void Enqueue_AddItem()
        {
            var item = 0;

            _queue.Enqueue(item);

            Assert.True(item == _inputStack.Peek());
        }

        [Fact]
        public void Dequeue_Removes_And_Returns_FirstEnteredItem()
        {
            var firstItem = 1;
            var secondItem = 2;

            _inputStack.Push(firstItem);
            _inputStack.Push(secondItem);

            var removedItem = _queue.Dequeue();

            Assert.True(removedItem == firstItem && _outputStack.Count == 1);
        }

        [Fact]
        public void Peek_Returns_FirstEnteredItem()
        {
            var firstItem = 1;
            var secondItem = 2;

            _inputStack.Push(firstItem);
            _inputStack.Push(secondItem);

            var returnedItem = _queue.Peek();

            Assert.True(returnedItem == firstItem && _outputStack.Count == 2);
        }
    }
}