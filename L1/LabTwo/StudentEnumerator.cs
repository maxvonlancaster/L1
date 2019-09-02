using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L1.LabTwo
{
    public class StudentEnumerator : IEnumerator
    {
        private ArrayList _collection;
        private int curIndex;
        private IDateAndCopy curExam;

        public StudentEnumerator(ArrayList collection)
        {
            _collection = collection;
            curIndex = -1;
            curExam = default(IDateAndCopy);
        }

        public IEnumerator GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            if (++curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                curExam = (IDateAndCopy)_collection[curIndex];
            }
            return true;
        }

        public void Reset() { curIndex = -1; }

        public IDateAndCopy Current
        {
            get { return curExam; }
        }


        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
