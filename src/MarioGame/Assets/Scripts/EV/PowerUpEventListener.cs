using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomPowerUpEvent : UnityEvent<PowerUp>
{
}

public class PowerUpEventListener : MonoBehaviour
{
    public PowerUpEvent Event;
    public CustomPowerUpEvent Response;
    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(PowerUp p)
    {
        Response.Invoke(p);
    }
}