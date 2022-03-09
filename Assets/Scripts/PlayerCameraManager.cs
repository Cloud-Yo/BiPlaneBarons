using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCameraManager : MonoBehaviour
{
    [SerializeField] private GameObject _myCam = null;
    [SerializeField] private GameObject _reticle = null;
    [SerializeField] private GameObject _virtualCam = null;

    public void CameraSettings(bool mine)
    {

        if (!mine)
        {
            _virtualCam.SetActive(false);
            _myCam.SetActive(false);
            _reticle.SetActive(false);
        }
       
    }
}
