using UnityEngine;
using System.Collections.Generic;

public class Future : MonoBehaviour {
    public delegate void DelayedFunction();

    private struct DelayedCall {
        public float scheduledTime;
        public DelayedFunction function;
    }

    private List<DelayedCall> delayedCalls = new List<DelayedCall>();

	// Update is called once per frame
	void Update () {
        for ( int i = 0; i < delayedCalls.Count; i++ ) {
            if (delayedCalls[i].scheduledTime < Time.unscaledTime) {
                delayedCalls[i].function.DynamicInvoke();
                delayedCalls.RemoveAt(i);
                i--;
            }
        }
	}

    public Future schedule(float delay, DelayedFunction delayedFunction) {
		this.delayedCalls.Add(new DelayedCall() { scheduledTime = Time.unscaledTime + delay, function = delayedFunction });
        return this;
    }
}
