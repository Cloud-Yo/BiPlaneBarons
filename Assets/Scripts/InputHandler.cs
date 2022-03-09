using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class InputHandler : MonoBehaviour   
{
    [SerializeField] private string _inputName;
    [SerializeField] private KeyCode _keyCode;
    public UnityEvent OnDownDetected;
    public UnityEvent OnUpDetected;
    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();

    }



    void Update()
    {
        if (_view.IsMine)
        {
            if (Input.GetKey(_keyCode))
            {
                OnDownDetected?.Invoke();
            }
            else if(Input.GetKeyUp(_keyCode))
            {
                OnUpDetected?.Invoke();
            }
        }
    }


}
