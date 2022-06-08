using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T _left;
        private T _right;
        public EqualityScale(T left, T right)
        {
            this._left = left;
            this._right = right;
        }
        public bool AreEqual()
        {
            if (_left.Equals(_right))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
