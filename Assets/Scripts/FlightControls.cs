using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FlightControls : MonoBehaviour
{
    private Transform _pTran = null;
    [SerializeField] private float _turnSpeed = 15f;
    [SerializeField] private float _rollAngle = 5f;
    [SerializeField] private float _yawAngle = 10f;
    [SerializeField] private float _pitchAngle = 10f;
    [SerializeField] private float _rollBack = 1.5f;
    [SerializeField] private float _pitchBack = 1.5f;
    [SerializeField] private float _returnSpeed = 1.5f;

    private PlayerCameraManager _playerCameraManager;
    private bool _stabilize = true;
    private PhotonView _view;

    void Start()
    {
        _playerCameraManager = GetComponent<PlayerCameraManager>();
        _view = GetComponent<PhotonView>();
        _pTran = GetComponent<Transform>();
        if(!_view.IsMine)
        {
            _playerCameraManager.CameraSettings(_view.IsMine);

        }
        transform.name = $"Player{_view.ViewID}";
    }


    void Update()
    {
        if(_view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl)) { _stabilize = !_stabilize; }

            FlightControl();

            if (!Input.anyKey) { ReturnToLevel(); }
        }

    }

    void FlightControl()
    {
  
        var roll = Input.GetAxis("Horizontal") * (_rollAngle * Time.deltaTime) * _turnSpeed;
        var pitch = Input.GetAxis("Vertical") * (_pitchAngle * Time.deltaTime) * _turnSpeed;
        _pTran.Rotate(pitch, 0, -roll, Space.Self);


        if(Input.GetKey(KeyCode.Q))
        {
            _pTran.Rotate(0, -_yawAngle, 0, Space.Self);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            _pTran.Rotate(0, _yawAngle, 0, Space.Self);
        }

    }

    void ReturnToLevel()
    {
        if (!_stabilize) { return; }
            

        float zRoll = Mathf.SmoothStep(_pTran.rotation.z, 0, _rollBack);
        float xPitch = Mathf.SmoothStep(_pTran.rotation.x, 0, _pitchBack);
        var tempAngle = _pTran.rotation;
        tempAngle.z = zRoll;
        tempAngle.x = xPitch;
        _pTran.rotation = Quaternion.Slerp(_pTran.rotation, tempAngle, _returnSpeed * Time.deltaTime);
    }

}
