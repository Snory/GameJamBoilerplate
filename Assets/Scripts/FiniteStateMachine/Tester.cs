using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tester : MonoBehaviour
{
    public UnityEvent<ExampleStateEventArgument> TestEvent;


    public void Start()
    {
        if(TestEvent != null)
        {
            TestEvent.Invoke(new ExampleStateEventArgument());
        }
    }

}
