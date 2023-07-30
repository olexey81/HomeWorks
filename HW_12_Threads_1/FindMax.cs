﻿using System.Numerics;

namespace HW_12_Threads_1
{
    internal class FindMax<T> : Aggregator<T, T> where T : INumber<T>
    {
        private readonly T[] _results;
        public T MaxInArray { get; private set; }
        public FindMax(int threatsNum, T[] inputArray) : base(threatsNum, inputArray)
        {
            _results = new T[threatsNum];
            Array.Fill(_results, inputArray[0]); 
            MaxInArray = _results[0];
        }

        protected override void JobItems(Span<T> span, int index, StartParameters<T> parameters)
        {
            if (_results[parameters.ThreadIndex] < span[index])
                _results[parameters.ThreadIndex] = span[index];
        }
        public override T ThreadsWait()
        {
            foreach (var thread in _threads)
                thread.Join();

            for (int i = 1; i < _results.Length; i++)
            {
                if (MaxInArray < _results[i])
                    MaxInArray = _results[i];
            }
            return MaxInArray;
        }


    }
}
