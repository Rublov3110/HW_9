using System;

namespace HW_9.Services.Abstractions
{
    public interface IFileService
    {
        public string Read(string path);
        public IDisposable Create(string path);
        public void Write(IDisposable streamWriter, string data);
        public void Close(IDisposable streamWriter);
    }
}