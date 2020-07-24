using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractValve : InteractScript
{
    public override void Interact()
    {
        //base.Interact();
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
