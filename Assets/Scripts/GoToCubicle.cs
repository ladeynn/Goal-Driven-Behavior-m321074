using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCubicle : GAction
{
    public override bool PrePerform()
    {
        target = inventory.FindObjectWithTag("Cubicle");
        if (target == null) { return false; }
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("TreatingPatient", 1);
        GWorld.Instance.AddCubicles(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", 1);
        return true;
    }
}
