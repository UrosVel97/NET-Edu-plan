using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Text;

internal sealed class UnmanagedFileResource : IDisposable
{
    private readonly FileStream _fileStream;
    private readonly SafeFileHandle _fileHandle;
    private bool _disposed;

    public UnmanagedFileResource(string filePath)
    {
        _fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        _fileHandle = _fileStream.SafeFileHandle;

        Console.WriteLine($"Opened file handle: {_fileHandle.DangerousGetHandle()}");
    }

    ~UnmanagedFileResource()
    {
        Console.WriteLine("Finalizer called. Releasing unmanaged file resource through Dispose(false).");
        Dispose(false);
    }

    public void WriteLine(string text)
    {
        ThrowIfDisposed();

        var bytes = Encoding.UTF8.GetBytes(text + Environment.NewLine);
        _fileStream.Seek(0, SeekOrigin.End);
        _fileStream.Write(bytes);
        _fileStream.Flush();
    }

    public string ReadAllText()
    {
        ThrowIfDisposed();

        _fileStream.Seek(0, SeekOrigin.Begin);

        using var reader = new StreamReader(_fileStream, Encoding.UTF8, leaveOpen: true);
        return reader.ReadToEnd();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            Console.WriteLine("Dispose called manually. Closing managed FileStream and its file handle.");
            _fileStream.Dispose();
        }
        else
        {
            Console.WriteLine("Dispose called from finalizer. Releasing SafeFileHandle.");
            _fileHandle.Dispose();
        }

        _disposed = true;
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }
}
