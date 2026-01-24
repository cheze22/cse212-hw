using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities: ItemA (1), ItemB (5), ItemC (3).
    // Expected Result: ItemB (Priority 5) should be dequeued first.
    // Defect(s) Found: Initially, the code did not remove the item from the queue after dequeuing.
    public void TestPriorityQueue_HighPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 1);
        priorityQueue.Enqueue("ItemB", 5);
        priorityQueue.Enqueue("ItemC", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("ItemB", result);
    }

    [TestMethod]
    // Scenario: Enqueue items where two items have the same highest priority: ItemA (2), ItemB (5), ItemC (5), ItemD (1).
    // Expected Result: ItemB should be dequeued first because it was enqueued before ItemC (FIFO tie-break).
    // Defect(s) Found: The original code used ">=" which caused the last item with the high priority 
    // to be picked instead of the first one.
    public void TestPriorityQueue_TiePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 2);
        priorityQueue.Enqueue("ItemB", 5);
        priorityQueue.Enqueue("ItemC", 5);
        priorityQueue.Enqueue("ItemD", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("ItemB", result);
    }

    [TestMethod]
    // Scenario: Enqueue items where the highest priority item is at the very back: ItemA (1), ItemB (2).
    // Expected Result: ItemB should be dequeued.
    // Defect(s) Found: The loop in Dequeue was using "index < _queue.Count - 1", 
    // which prevented it from ever checking the last item in the list.
    public void TestPriorityQueue_BackOfQueue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 1);
        priorityQueue.Enqueue("ItemB", 2);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("ItemB", result);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None. This part of the logic was correctly implemented.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}