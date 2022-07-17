using DataStructures.Collections;
using System.Reflection;

namespace DataStructures.UnitTests
{
    public class MyStackTest
    {
        private readonly MyStack<int> _stack;
        private readonly Queue<int> _queue;

        public MyStackTest()
        {
            _stack = new MyStack<int>();
            _queue = new Queue<int>();

            FieldInfo? queueField = typeof(MyStack<int>).GetField("_queue", BindingFlags.NonPublic | BindingFlags.Instance);
            queueField?.SetValue(_stack, _queue);
        }

        [Fact]
        public void IsEmpty_When_EmptyQueue_Returns_True()
        {
            var result = _stack.IsEmpty();

            Assert.True(result);    
        }

        [Fact]
        public void IsEmpty_When_NonEmptyQueue_Returns_False()
        {
            _queue.Enqueue(0);

            var result = _stack.IsEmpty();

            Assert.False(result);
        }

        [Fact]
        public void Push_When_AddTwoItems_SecondItem_IsAddedAtQueueFront()
        {
            var firstItem = 1;
            var secondItem = 2;
            
            _stack.Push(firstItem);
            _stack.Push(secondItem);

            Assert.True(_queue.Peek() == secondItem);
        }

        [Fact]
        public void Pop_Removes_And_Returns_ItemAtQueueFront()
        {
            var firstItem = 1;
            var secondItem = 2;

            _queue.Enqueue(firstItem);
            _queue.Enqueue(secondItem);

            Assert.True(_stack.Pop() == firstItem && _queue.Count == 1);
        }

        [Fact]
        public void Top_Returns_ItemAtQueueFront()
        {
            var firstItem = 1;
            var secondItem = 2;

            _queue.Enqueue(firstItem);
            _queue.Enqueue(secondItem);

            Assert.True(_stack.Top() == firstItem && _queue.Count == 2);
        }
    }
}
