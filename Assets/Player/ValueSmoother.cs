using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ValueSmoother
{
    public float StartValue;
    public float EndValue;
    [SerializeField] public float Speed; // в еденицах интерполируемого значения/сек

    public ValueSmoother(float Speed)
    {
        this.Speed = Speed;
    }

    public void Set(float StartValue, float EndValue)
    {
        this.StartValue = StartValue;
        this.EndValue = EndValue;
    }

    public float GetInterpolatedValue(float f)
    {
        return Mathf.Lerp(StartValue, EndValue, f);
    }

    public float GetValueByTime(float Time)
    {
        float Delta = Mathf.Abs(EndValue - StartValue);

        if (Delta == 0)
        {
            return EndValue;
        }

        return GetInterpolatedValue(Speed * Time / Delta);
    }
}
