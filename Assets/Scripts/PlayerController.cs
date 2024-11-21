using Ashsvp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private SimcadeVehicleController _vehicleController;
    [SerializeField] private float _savePointDelay;
    private float _timeFromStart;
    private const float _stopAfterFinishDelay = 0.7f;
    private List<ModelController.RepeatPoint> _activePath = new List<ModelController.RepeatPoint>();
    public void StopCar(bool useDelay = true)
    {
        StartCoroutine(StopWithDelay(useDelay));
    }

    public void StartCar()
    {
        _timeFromStart = 0;
        _activePath.Clear();
        _vehicleController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    public IEnumerator StopWithDelay(bool useDelay)
    {
        yield return new WaitForSeconds(useDelay ? _stopAfterFinishDelay : 0);
        _vehicleController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public ModelController.RepeatPoint[] GetActivePath()
    {
        SaveCurrentPoint();
        return _activePath.ToArray();
    }

    private void SaveCurrentPoint()
    {
        _activePath.Add(new ModelController.RepeatPoint(_timeFromStart, transform.position, transform.rotation));
    }

    private void Update()
    {
        _timeFromStart += Time.deltaTime;
        if ((_timeFromStart / _savePointDelay) > _activePath.Count)
        {
            SaveCurrentPoint();
        }
    }
}
