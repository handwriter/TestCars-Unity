using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCarController : MonoBehaviour
{
    private ModelController.RepeatPoint[] _movePath;
    private int _pointIndex;
    private float _timeFromStart;

    public void SetupPath(ModelController.RepeatPoint[] path)
    {
        _movePath = path;
        _pointIndex = 1;
        _timeFromStart = 0;
    }

    private void Update()
    {
        _timeFromStart += Time.deltaTime;
        if (_movePath != null && _pointIndex < _movePath.Length)
        {
            if (_timeFromStart > _movePath[_pointIndex].Time) _pointIndex++;
            if (_pointIndex == _movePath.Length) return;
            float deltaTime = _movePath[_pointIndex].Time - _movePath[_pointIndex - 1].Time;
            float t = 1 - ((_movePath[_pointIndex].Time - _timeFromStart) / deltaTime);
            transform.position = Vector3.Lerp(_movePath[_pointIndex - 1].WorldPosition, _movePath[_pointIndex].WorldPosition, t);
            transform.rotation = Quaternion.Lerp(_movePath[_pointIndex - 1].WorldRotation, _movePath[_pointIndex].WorldRotation, t);
        }
    }
}
