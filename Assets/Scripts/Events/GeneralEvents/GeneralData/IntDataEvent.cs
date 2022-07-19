using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntDataEvent : DataEvent
{
    public int Value;

    public IntDataEvent(int value)
    {
        Value = value;
    }
}
