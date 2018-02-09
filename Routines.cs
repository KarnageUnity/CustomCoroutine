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
/// The manager class that increments all running routines 
/// and provides APIs to start and stop new Routines.
/// </summary>
public class Routines {
    /// <summary>
    /// Store of all running routines
    /// </summary>
    LinkedList<IEnumerator> routines = new LinkedList<IEnumerator>();

    /// <summary>
    /// If a MonoBehaviour calls this every Update(), 
    /// Routines will behave exactly like Coroutines.
    /// </summary>
    public void OnUpdate() {
        LinkedListNode<IEnumerator> node = routines.First;
        while (node != null) {
            LinkedListNode<IEnumerator> next = node.Next;
            IEnumerator routine = node.Value;
            if (!routine.MoveNext()) {
                routines.Remove(node);
            }
            node = next;
        }
    }

    /// <summary>
    /// Can be used to check whether to bother with OnUpdate() at all
    /// </summary>
    public bool IsRunning() {
        return routines.Count > 0;
    }

    /// <summary>
    /// Equivalent of StartCoroutine(IEnumerator)
    /// </summary>
    public Routine StartRoutine(IEnumerator routine) {
        LinkedListNode<IEnumerator> node = routines.AddLast(routine);
        return new Routine(routine, node);
    }
    /// <summary>
    /// Equivalent of StopCoroutine(Coroutine)
    /// </summary>
    public void StopRoutine(Routine routine) {
        if (routine.container.List == routines) {
            routines.Remove(routine.iterator);
        }
    }

    /// <summary>
    /// Equivalent of StopAllCoroutines()
    /// </summary>
    public void StopAllRoutines() {
        routines.Clear();
    }
}
