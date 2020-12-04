using System;
using System.Collections.Generic;

namespace CyclicListApp
{
    class CyclicList<T> : IEnumerable<T>
    {
        private readonly int _maxLength;
        private int _currentIndexPosition;
        private readonly List<T> _elements = new List<T>();
        public CyclicList(int maxLength)
        {
            _maxLength = maxLength;
            for (int i = 0; i < maxLength; i++)
            {
                _elements.Add(default(T));
            }
        }
        public void Add(T entry)
        {
            _currentIndexPosition = OverflowCheck(_currentIndexPosition);
            _elements[_currentIndexPosition] = entry;
            _currentIndexPosition++;
        }

        private int OverflowCheck(int positionToCheck)
        {
            return positionToCheck > _maxLength - 1 ? 0 : positionToCheck;
        }

        public T GetElement(int position)
        {
            try
            {
                Console.WriteLine($"Trying to get item at index {position}");
                return _elements[position];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Position {position} is beyond the range of the list with length {_maxLength}");
                return default;
            }
        }

        public void GetAllElements()
        {
            var tempIndexPosition = _currentIndexPosition;
            foreach (var item in _elements)
            {
                tempIndexPosition = OverflowCheck(tempIndexPosition);
                Console.WriteLine(_elements[tempIndexPosition]);
                tempIndexPosition++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
