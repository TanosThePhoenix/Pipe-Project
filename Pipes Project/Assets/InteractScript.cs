using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractScript : MonoBehaviour
{
    public abstract void Interact();

    public string label;

    public bool interactFlag;
}
