// File:    IIterator.cs
// Created: Tuesday, June 02, 2020 4:01:38 AM
// Purpose: Definition of Interface IIterator


public interface IIterator<T>
{
    T First();

    T Next();

    bool IsDone();

    T CurrentItem();

}
