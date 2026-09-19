using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three values with different priorities to the queue.
    // Expected Result: Each value is added to the back of the queue in insertion order.
    // Defect(s) Found: PASSED before and after the fix; values were added in the correct order.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("[A (Pri:1), B (Pri:3), C (Pri:2)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Add three values with increasing priorities, with the highest-priority value last.
    // Expected Result: Values are removed from highest to lowest priority: C, B, A.
    // Defect(s) Found: FAILED before fix: expected C first, but got B. The last item was not searched,
    // and dequeued items were not removed.
    // PASSED after the priority queue implementation was fixed.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three values with the same priority.
    // Expected Result: Values with equal priorities are removed in FIFO order: A, B, C.
    // Defect(s) Found: FAILED before fix: expected A first, but got B. Equal priorities did not preserve
    // FIFO order, and dequeued items were not removed.
    // PASSED after the priority queue implementation was fixed.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to remove a value from an empty priority queue.
    // Expected Result: InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: PASSED before and after the fix; the exception type and message were correct.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
