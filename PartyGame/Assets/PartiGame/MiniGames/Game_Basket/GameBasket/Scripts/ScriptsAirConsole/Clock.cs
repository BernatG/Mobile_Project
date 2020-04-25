using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock
{
    float lastReset = 0;
    public Clock()
    {
        reset();
    }

    public void reset()
    {
        lastReset = Time.time;
    }
    public float getTime()
    {
        return Time.time - lastReset;
    }

}
