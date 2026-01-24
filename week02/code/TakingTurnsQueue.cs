using System;

/// <summary>
/// This queue is circular. When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Fixed logic:
    /// 1. If turns <= 0, the person is infinite and always enqueued again.
    /// 2. If turns > 1, the person has finite turns, decrease by 1 and re-enqueue.
    /// 3. If turns == 1, the person is not re-enqueued.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // If turns are 0 or less, they stay in forever
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // If they have more than 1 turn, they stay in and lose a turn
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}