using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRuntimeVariable
{
    public object GetValueFromName(string name);

    public void SetValueFromName(string name, object value);
}
