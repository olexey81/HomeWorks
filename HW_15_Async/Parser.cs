using System;
using System.IO;

namespace HW_15_Async
{


    class Parser
    {
        private readonly string _path;
        private byte[] _bufferResult;
        private byte[] _bufferRead1;
        private byte[] _bufferRead2;
       

        public Parser(string path)
        {
            _path = path;
        }

        public async Task Parse()
        {
            const int _bufferSize =  1024 * 1024;

            await using var stream = File.OpenRead(_path);                      // стрим на чтение из старого
            await using var resultStream = File.Create("d:/result.bin");     // стрим на запись в новый

            bool isFirstBuffer = true;
            _bufferRead1 = new byte[_bufferSize];
            _bufferRead2 = new byte[_bufferSize];

            _bufferResult = new byte[_bufferSize];                   // буфер на запись после обработки

            while (stream.Position < stream.Length)
            {
                int resultCount = 0;

                byte[] buffer = isFirstBuffer ? _bufferRead1 : _bufferRead2;

                var count = await stream.ReadAsync(buffer, 0, _bufferSize);

                for (int i = 0; i < count; i++)                 // обработка текущего буфера - выбираем только 0-127
                {
                    var ch = (char)buffer[i];
                    if (char.IsAscii(ch))
                    {
                        _bufferResult[resultCount] = buffer[i];    // пишем в буфер для записи значения 0-127
                        resultCount++;
                    }
                }

                await resultStream.WriteAsync(_bufferResult, 0, resultCount);

                isFirstBuffer = !isFirstBuffer;
            }
        }
    }
}
