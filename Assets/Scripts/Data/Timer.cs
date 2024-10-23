using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Timer
{
    [SerializeField] float timeLimit;
    float timeElapsed;

    public float TimeLimit => timeLimit;
    public float TimeElapsed => timeElapsed;
    public float TimeRemaining => timeLimit - timeElapsed;
    public float FractionOfTimeElapsed => TimeElapsed / TimeLimit;
    public float FractionOfTimeRemaining => TimeRemaining / TimeLimit;

    public bool OutOfTime => TimeElapsed >= TimeLimit;

    public Timer(float timeLimit)
    {
        this.timeLimit = timeLimit;
        timeElapsed = 0f;
    }

    public void Update(float time)
    {
        timeElapsed = Mathf.Clamp(timeElapsed + time, 0f, timeLimit);
    }

    public void Reset()
    {
        this = new Timer(timeLimit);
    }
}
