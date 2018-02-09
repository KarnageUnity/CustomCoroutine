# CustomCoroutine

## Two C# classes demonstrating how Unity3D implements Coroutines

This is an extremely simple demonstration of how Unity's Coroutines work. Unity creates a Coroutine object when you call StartCoroutine (you can see the allocation in the Profiler; don't use StartCoroutine() in hot code) and adds it to some list somewhere. Unity also provides special classes to yield return various aspects of time instead of just one frame, as is implemented here.

### Usage
Write an `IEnumerator` method (inside a `MonoBehaviour`) as you normally would. Call it and pass the returned `IEnumerator` to an instance of `Routines` via `Routines::StartRoutine(IEnumerator)`. This will return a reference to an object of type `Routine`, which can also be used to stop it via `Routines::StopRoutine(Routine)`.
