using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, then dequeue all three.
    // Expected Result: Items are returned in priority order: "high"(5), "med"(3), "low"(1).
    // Defect(s) Found: Two bugs prevented correct behavior:
    //   1. The loop used `_queue.Count - 1` as the upper bound, skipping the last element.
    //   2. The dequeued item was never removed from the list, so the queue never shrank.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("med", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("med", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items with the same priority, then dequeue them.
    // Expected Result: Items are returned in FIFO order: "first", "second", "third".
    // Defect(s) Found: The loop used `>=` for priority comparison, which updated highPriorityIndex
    // to later equal-priority items, breaking FIFO order. Fixed by using strict `>`.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 3);
        priorityQueue.Enqueue("second", 3);
        priorityQueue.Enqueue("third", 3);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: No defect. The empty check was already correctly implemented.
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
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
        }
    }

    [TestMethod]
    // Scenario: The highest-priority item is the last one added (last in the list).
    // Expected Result: "last"(10) is dequeued first, proving the loop reaches the last element.
    // Defect(s) Found: The loop used `_queue.Count - 1` as the upper bound, which caused the
    // last element to never be evaluated. Fixed by changing the bound to `_queue.Count`.
    public void TestPriorityQueue_HighestPriorityIsLast()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 2);
        priorityQueue.Enqueue("last", 10);

        Assert.AreEqual("last", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}