using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitWhile : CustomYieldInstruction
{
    private Func<bool> _waitPredicate;

    public override bool keepWaiting { get => _waitPredicate(); }

    public WaitWhile(Func<bool> waitPredicate)
    {
        this._waitPredicate = waitPredicate;
    }
}
