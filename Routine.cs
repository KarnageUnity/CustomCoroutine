/* **************************************************************************
 * This is an extremely simple demonstration of how Unity's Coroutines work. 
 * Unity creates a Coroutine object when you call StartCoroutine (you can see
 * the allocation in the Profiler; don't use StartCoroutine() in hot code) and
 * adds it to some list somewhere. Unity also provides special classes to yield
 * return various aspects of time instead of just one frame, as is implemented here. 
*/

using System.Collections;           // IEnumerator
using System.Collections.Generic;   // LinkedList

/// <summary>
/// The wrapper "Coroutine" class, whose object will be allocated on StartRoutine()
/// For ease of the implementation of StopRoutine(), a Routine's corresponding
/// LinkedListNode is also a public member. DON'T do this in an actual framework!
/// </summary>
public class Routine {
    /// <summary>
    /// The iterator that is incremented every OnUpdate()
    /// </summary>
    public IEnumerator iterator;
    /// <summary>
    /// Iterator's LinkedListNode reference
    /// </summary>
    public LinkedListNode<IEnumerator> container;

    /// <summary>
    /// No default constructor
    /// </summary>
    /// <param name="iterator">The iterator that is incremented every OnUpdate()</param>
    /// <param name="container">Iterator's LinkedListNode reference</param>
    public Routine(IEnumerator iterator, LinkedListNode<IEnumerator> container) {
        this.iterator = iterator;
        this.container = container;
    }
}
