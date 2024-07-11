using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FortuneWheel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Stopper _stopper;
    [SerializeField] private bool _isSpinning;
    [SerializeField, Range(100, 400f)] private float _RotationSpeed;
    [SerializeField] private float _accelerationTime;
    [SerializeField, Range(0, 0.5f)] private float _randomizer;
    [SerializeField, Range(0.1f, 0.8f)] private float _friction;
    [SerializeField] private float _velocityToActivateStopper;
    [SerializeField] private Ease _accelerationEase;
    [SerializeField] private Detector _detector;
    private IStopper _iStopper;
    private Tween _tween;

    private void OnValidate()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _iStopper = _stopper.GetComponent<IStopper>();
    }
    private void Start()
    {
        _isSpinning = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpinTheWheel();
    }

    public void SpinTheWheel()
    {
        if (_isSpinning) return;
        _rigidBody.angularDrag = _friction;
        _isSpinning = true;
        var randomizedSpeed = Random.Range(_RotationSpeed * _randomizer, _RotationSpeed * (_randomizer + 1f));
        print($"speed is {randomizedSpeed}");
        _tween = DOVirtual.Float(0, randomizedSpeed, _accelerationTime, v => _rigidBody.angularVelocity = v).SetEase(_accelerationEase);
        _iStopper.DeactivateStopper();
        StartCoroutine(SpeedCheck());
    }

    private IEnumerator SpeedCheck()
    {
        yield return new WaitUntil(() => !_tween.IsActive() && _rigidBody.angularVelocity < _velocityToActivateStopper);
        _iStopper.ActivateStopper();
        yield return new WaitUntil(() => _rigidBody.angularVelocity == 0);
        _isSpinning = false;
        DeterminateWinnerCircle();
    }

    private void DeterminateWinnerCircle()
    {
        _detector.CheckWinningCircle();
    }
}
