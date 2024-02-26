namespace MWorkDaily.Base;
public sealed class AsyncLock
{
    private readonly SemaphoreSlim _semaLock = new SemaphoreSlim(1, 1);

    public async Task<IDisposable> LockAsync()
    {
        await _semaLock.WaitAsync();
        return new Handler(_semaLock);
    }
    internal sealed class Handler : IDisposable
    {
        private readonly SemaphoreSlim _semaphore;
        private bool _disposed = false;

        public Handler(SemaphoreSlim semaphore)
        {
            _semaphore = semaphore;
        }

        public void Dispose()
        {
            if (_disposed) return;

            _semaphore.Release();
            _disposed = true;
        }
    }
}