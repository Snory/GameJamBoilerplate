using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneralDataEventListener : GeneralEventListener
{
    new public UnityEvent<EventData> Response;

    public void OnEventRaised(EventData data)
    { Response?.Invoke(data); }
}
