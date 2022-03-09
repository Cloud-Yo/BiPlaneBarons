using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab = null;
    [SerializeField] private float _distance = 10f;
    [SerializeField] private UIHealthManager _healthManager = null;
    private Vector3 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 xY = Random.insideUnitCircle.normalized * _distance;
        _startPos = new Vector3(xY.x, 8f, xY.y);
        GameObject player = PhotonNetwork.Instantiate(_playerPrefab.name, _startPos, Quaternion.identity);
        player.transform.LookAt(new Vector3(0, player.transform.position.y, 0));
        _healthManager.SetPlayer(player.GetComponent<PlayerHealth>());

    }

}
