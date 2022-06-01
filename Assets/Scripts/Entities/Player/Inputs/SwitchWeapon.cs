using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : BasePlayerInput
{
    public EventObject switchToPrimaryWeaponEvent;
    public EventObject switchToSecondaryWeaponEvent;

    void Awake()
    {
        inputActions = new InputActions();

        inputActions.PcMap.PrimaryWeapon.performed += ctx => switchToPrimaryWeaponEvent.Invoke(callingObject);

        inputActions.PcMap.SecondaryWeapon.performed += ctx => switchToSecondaryWeaponEvent.Invoke(callingObject);
    }
}
