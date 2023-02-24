// File:    OperationAggregate.cs
// Created: Tuesday, June 02, 2020 4:06:02 AM
// Purpose: Definition of Class OperationAggregate

using System;
using System.Collections.Generic;


public class OperationAggregate : IAggregate<OperationIterator>
{
    private List<Operation> operations;

    public OperationAggregate()
    {
        operations = new List<Operation>();
    }

    public OperationAggregate(List<Operation> operats)
    {
        operations = new List<Operation>(operats);
    }
    public int Count()
    {
        return operations.Count;
    }

    public OperationIterator CreateIterator()
    {
        return new OperationIterator(this);
    }

    public List<Operation> getAllElements()
    {
        return operations;
    }

    public Operation this[int index]
    {
        get { return operations[index]; }
    }

    public void AddItem(Operation operation)
    {
        operations.Add(operation);
    }
    public void RemoveItem(Operation operation)
    {
        operations.Remove(operation);
    }

    public void setList(List<Operation> oper)
    {
        operations = new List<Operation>(oper);
    }


}
