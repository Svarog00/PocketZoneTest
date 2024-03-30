using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private const int CameraZOffset = -5;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(_target.position.x, _target.position.y, CameraZOffset);
    }
}
