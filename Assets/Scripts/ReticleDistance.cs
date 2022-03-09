using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleDistance : MonoBehaviour
{
    [SerializeField] private float _distance = 7.5f;
    [SerializeField] private Transform _canvasGO;
    [SerializeField] private Vector3 _canvasDefaultPosition;
    private Vector3 _canvasHitLocation;
    
    

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, _distance))
        {
            if(hit.collider != null)
            {
                if (DistanceFromPlane(hit.point) > 10f)
                    return;
                _canvasGO.localPosition = transform.InverseTransformPoint(hit.point);
            }
        }
        else
        {
            if (_canvasGO.localPosition == _canvasDefaultPosition) { return; }
            _canvasGO.localPosition = _canvasDefaultPosition;
        }
    }

    private float DistanceFromPlane(Vector3 point)
    {
        return Vector3.Distance(transform.position, point); 
    }
}
