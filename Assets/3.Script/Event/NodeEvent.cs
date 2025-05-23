using UnityEngine;

namespace TMS.Event
{
    public class NodeStartEvent
    {
    }

    public class NodeTouchEvent
    {
        public float TouchAccuracy { get; private set; }

        public NodeTouchEvent(float touchAccuracy)
        {
            TouchAccuracy = touchAccuracy;
        }
    }
}