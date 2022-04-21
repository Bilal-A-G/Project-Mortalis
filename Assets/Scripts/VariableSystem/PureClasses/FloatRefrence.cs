using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatRefrence
{
    [SerializeField]
    bool useVariable;

    [SerializeField]
    float assignedValue;
    [SerializeField]
    FloatVariable floatVariable;

    public float GetValue() => useVariable ? floatVariable.value : assignedValue;
}
