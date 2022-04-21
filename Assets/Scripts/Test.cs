using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void Move(ResultArguments[] arguments)
    {
        Debug.Log(arguments[0].vectorValue + " " + arguments[0].floatValue);
    }
}
