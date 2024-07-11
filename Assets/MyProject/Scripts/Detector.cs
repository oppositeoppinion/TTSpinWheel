using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private BetsAndScores _betsAndScores;
    private IBetsAndScores _iBetsAndScores;
    private RaycastHit _hitInfo;
    private void OnValidate()
    {
        _iBetsAndScores = _betsAndScores.GetComponent<BetsAndScores>();
    }
    public void CheckWinningCircle()
    {
        Physics.Raycast(transform.position, Vector3.down, out _hitInfo, 1f);
        _iBetsAndScores.CalculateSpinningResult(_hitInfo.collider.gameObject.name);
    }
}
