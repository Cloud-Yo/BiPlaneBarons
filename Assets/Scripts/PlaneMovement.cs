using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlaneMovement : Vehicle
{
    private Transform _transform;
    private PhotonView _view;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _speedDelta = 2f;
    public bool Accelerate => Input.GetKey(KeyCode.LeftShift);
    public bool Decelerate => Input.GetKey(KeyCode.RightShift);

    // Start is called before the first frame update
    void Start()
    {
        _view = GetComponent<PhotonView>();
        _currentSpeed = Speed;
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
    {

        _transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);
        _transform.TransformDirection(transform.forward);   
        
        if (Accelerate) { Acceleration(); }
        if (Decelerate) { Deceleration(); }
        if (!Accelerate && !Decelerate) { ReturnToNormalSpeed(); }
    }

    private void ReturnToNormalSpeed()
    {
        if (!_view.IsMine) return;
        if (_currentSpeed != Speed)
        {
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, _speed, Time.deltaTime * _speedDelta);
        }
    }
    private void Acceleration()
    {
        if (!_view.IsMine) return;
        if (_currentSpeed < Speed * 2f)
        {
            _currentSpeed += Time.deltaTime * _speedDelta;
        }
        else
        {
            _currentSpeed = Speed * 2f;
        }

    }

    private void Deceleration()
    {
        if (!_view.IsMine) return;
        if (_currentSpeed > Speed * 0.5f)
        {
            _currentSpeed -= Time.deltaTime * _speedDelta;
        }
        else
        {
            _currentSpeed = _speed * 0.5f;
        }

    }

}
