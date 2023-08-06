using System;

namespace HW_15_Async
{
    class Generator
    {
        private readonly string _path;
        public readonly long _size;

        private readonly Random _random = new Random();

        public Generator(string path, long size = 2l * 1024 * 1024 * 1024)
        {
            _path = path;
            _size = size;
        }

        public async Task Do()
        {
            var bufferSize = (long)(_size * 0.001);
            var task = Task.CompletedTask;
            var buffers = GetBuffers(bufferSize);

            await using var stream = File.Create(_path);

            var progress = _size;
            while (progress > 0)
            {
                buffers.MoveNext();
                var buffer = buffers.Current;

                _random.NextBytes(buffer);

                await task;
                task = stream.WriteAsync(buffer, 0, buffer.Length);

                progress -= bufferSize;
            }
        }

        private IEnumerator<byte[]> GetBuffers(long length)
        {
            var buffer1 = new byte[length];
            var buffer2 = new byte[length];

            while (true)
            {
                yield return buffer1;
                yield return buffer2;
            }
        }
    }
}
