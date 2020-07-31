using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{

    private PhotonView view;

    [SerializeField]
    private List<Behaviour> componentsToDisable;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(view.IsMine)
        {

        }
        else
        {
            foreach( var component in componentsToDisable)
            {
                component.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
