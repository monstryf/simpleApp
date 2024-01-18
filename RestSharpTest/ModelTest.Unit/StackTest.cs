using simpleApp.ModelTest;


namespace RestSharpTest.ModelTest.Unit
{
    public class StackTest
    {
        [Fact]
        public void Push_ArgIsNull_ThowArgNullException()
        {
            var Stack = new Stacks<string>();
            Assert.Throws<ArgumentNullException>(() => Stack.Push(null));
        }
        [Fact]
        public void Puch_ValidArg_AddTheObjectToTheStack()
        {
            var Stack =new Stacks<string>();
            Stack.Push("a");
            Assert.Equal(Stack.Count, 1);
        }
        [Fact]
        public void Count_EmptyStack_ReturnZero()
        {
            var Stack = new Stacks<string>();
            Assert.Equal(Stack.Count,0);
        }
        [Fact]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var Stack = new Stacks<string>();
            Assert.Throws<InvalidOperationException>(() => Stack.Pop());
        }
        [Fact]
        public void Pop_StackWithAfewObjects_ReturnObjectOnTheTop()
        {
            var Stack = new Stacks<string>();
            Stack.Push("a");
            Stack.Push("b");
            Stack.Push("c");

            var Respons = Stack.Pop();

            Assert.Equal(Respons, "c");
        }
        [Fact]
        public void Pop_StackWithAfewObjects_RemoveObjectOnTheTop()
        {
            var Stack = new Stacks<string>();
            Stack.Push("a");
            Stack.Push("b");
            Stack.Push("c");

            Stack.Peek();

            Assert.Equal(Stack.Count, 2);
        }
        [Fact]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var Stack = new Stacks<string>();
   
            Assert.Throws<InvalidOperationException>( () => Stack.Peek());
        }
        [Fact]
        public void Peek_StackWithObjects_ReturnObjectOnTopOfTheStack()
        {
            var Stack = new Stacks<string>();
            Stack.Push("a");
            Stack.Push("b");
            Stack.Push("c");

            var Respons = Stack.Pop();

            Assert.Equal(Respons, "c");
        }
        [Fact]
        public void Peek_StackWithObjects_DoseNotRemoveTheObjectOnTopOfTheStack()
        {
            var Stack = new Stacks<string>();
            Stack.Push("a");
            Stack.Push("b");
            Stack.Push("c");

            Stack.Peek();

            Assert.Equal(Stack.Count, 3);
        }
    }
}
