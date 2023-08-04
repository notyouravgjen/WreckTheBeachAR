using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAccessCircularArray<T> {
    private T[] internalArray;
    private int startIndex;
    private int length;
    private T defaultEntry;
	public RandomAccessCircularArray(int length, T defaultEntry)
    {
        internalArray = new T[length];
        for(int i=0; i< length; i++)
        {
            internalArray[i] = defaultEntry;
        }
        startIndex = 0;
        this.length = length;
        this.defaultEntry = defaultEntry;
    }

    public T Get(int i)
    {
        if(i>length || i<0)
        {
            throw new System.IndexOutOfRangeException("index i=" + i + " is out of bounds for RandomAccessCircularArray of length=" + length);
        }
        int index = (startIndex + i) % length;
        return internalArray[index];
    }

    public void Set(int i, T newValue)
    {
        if (i > length || i < 0)
        {
            throw new System.IndexOutOfRangeException("index i=" + i + " is out of bounds for RandomAccessCircularArray of length=" + length);
        }
        int index = (startIndex + i) % length;
        internalArray[index] = newValue;
    }

    // moves every entry one index to the left,
    // sets the last entry of the array to defaultEntry
    // and returns the previous value of the last entry
    public T RotateLeft()
    {
        T oldEntry = Get(0);
        startIndex = (startIndex + 1) % length;
        Set(length - 1, defaultEntry);
        return oldEntry;
    }

    // moves every entry one index to the right,
    // sets the last entry of the array to defaultEntry
    // and returns the previous value of the last entry
    public T RotateRight()
    {
        T oldEntry = Get(length-1);
        // + length to keep it positive
        startIndex = (startIndex - 1 + length) % length;
        Set(0, defaultEntry);
        return oldEntry;
    }
}
