using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDataEvent : GeneralEvent
{
	public void Raise(EventData data)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			((GeneralDataEventListener) listeners[i]).OnEventRaised(data);
	}

}
