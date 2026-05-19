# Garbage Collector Demos

Two small .NET 10 console projects exploring how the CLR garbage collector works and how to cooperate with it when dealing with unmanaged resources.

## 01-GarbageCollector

Demonstrates the different overloads of `GC.Collect` and how they affect managed memory.

- `GarbageCreator` allocates 50,000 short-lived `DemoObject` instances (each holding a 1 KB buffer) to quickly produce garbage.
- `MemoryReporter` prints total managed memory (`GC.GetTotalMemory`) and per-generation collection counts (`GC.CollectionCount`).
- `GarbageCollectorDemo` runs five scenarios:
  1. `GC.Collect()` — full collection across all generations.
  2. `GC.Collect(0)` — collect generation 0 only.
  3. `GC.Collect(2, GCCollectionMode.Forced)` — forced collection up to gen 2.
  4. `GC.Collect(2, GCCollectionMode.Forced, blocking: true)` — blocks the calling thread until the collection completes.
  5. `GC.Collect(2, GCCollectionMode.Forced, blocking: true, compacting: true)` — additionally requests Large Object Heap compaction.

The output shows how memory usage and generation collection counts change after each call.

## 02-GarbageCollectorDispose

Demonstrates the `IDisposable` pattern and finalizers for releasing unmanaged resources (a file handle in this case).

- `UnmanagedFileResource` wraps a `FileStream` / `SafeFileHandle`, implements `IDisposable` with the standard `Dispose(bool disposing)` pattern, and provides a finalizer as a safety net.
- `FileResourceDemo` runs two scenarios:
  1. **Dispose demo** — uses `using` blocks so the file handle is released deterministically.
  2. **GC finalizer demo** — intentionally skips `Dispose`, then calls `GC.Collect` + `GC.WaitForPendingFinalizers` to show the finalizer eventually releasing the handle.

The console output makes it clear which path (manual `Dispose` vs. finalizer) closes the resource, and why explicit disposal is preferred.

## Running

From the solution folder:

```powershell
dotnet run --project 01-GarbageCollector/01-GarbageCollector.csproj
dotnet run --project 02-GarbageCollectorDispose/02-GarbageCollectorDispose.csproj
```
