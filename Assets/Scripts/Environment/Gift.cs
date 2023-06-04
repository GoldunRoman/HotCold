using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gift : MonoBehaviour
{
    [SerializeField] Transform _playerArm;
    [SerializeField] GameObject _winPanel;

    private void OnEnable()
    {
        _winPanel = FindFirstObjectByType<WinPanel>().gameObject;
        _playerArm = FindFirstObjectByType<Arm>().transform;
    }

    private void Update()
    {
        DistanceToPlayerArm();
        Debug.Log(DistanceToPlayerArm());

        EnableWinPanel();
    }

    public float DistanceToPlayerArm()
    {
        float _distanceToPlayer = Vector3.Distance(_playerArm.position, this.transform.position);
        return _distanceToPlayer;
    }

    private void EnableWinPanel()
    {
        if(this.gameObject.GetComponentInParent<Arm>() != null)
        {
            _winPanel.SetActive(true);
        }
    }


}
