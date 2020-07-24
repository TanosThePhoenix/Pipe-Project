using UnityEngine;
using UnityEngine.UI;

public class RaycastInteract : MonoBehaviour
{
    private GameObject RaycastedObj;
    public Image Crosshairs;
    public LayerMask InteractLayer;
    public int raylength = 10;
    public Text LabelUI;

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, raylength, InteractLayer.value))
        {
            if (hit.collider.CompareTag("InteractableObject"))
            {
                RaycastedObj = hit.collider.gameObject;
                Debug.Log(RaycastedObj.name);
                LabelUI.text = RaycastedObj.GetComponent<InteractScript>().label;
                CrosshairActive();

                //if (Input.GetMouseButtonDown(0))
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("Objected Interacted");
                    //RaycastedObj.SetActive(false);
                    RaycastedObj.GetComponent<InteractScript>().Interact();
                }
            }
            else if (hit.collider.CompareTag("LabelOnly"))
            {
                RaycastedObj = hit.collider.gameObject;
                Debug.Log(RaycastedObj.name);
                LabelUI.text = RaycastedObj.GetComponent<InteractScript>().label;
                CrosshairLabelOnly();
            }
        }
        else
        {
            CrosshairNormal();
            LabelUI.text = null;
        }

        void CrosshairActive()
        {
            Crosshairs.color = Color.green;
        }

        void CrosshairLabelOnly()
        {
            Crosshairs.color = Color.red;
        }

        void CrosshairNormal()
        {
            Crosshairs.color = Color.white;
        }
    }
}
