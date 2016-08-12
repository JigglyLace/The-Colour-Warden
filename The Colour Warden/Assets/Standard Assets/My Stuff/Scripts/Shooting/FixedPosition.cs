using UnityEngine;
using System.Collections;

public class FixedPosition : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float x, y = 0, z = 0;

    public Transform freeLook;
    public Transform pivot;
    void Update()
    {
        Vector3 targetPosition = new Vector3(followTarget.position.x + x, followTarget.position.y + y, followTarget.position.z + z);
        transform.position = targetPosition;

        transform.rotation = new Quaternion(pivot.rotation.x, freeLook.rotation.y, 0, transform.rotation.w);
    }

    private IEnumerator RotateTransform()
    {
        Quaternion desiredRotation = new Quaternion(pivot.rotation.x, freeLook.rotation.y, transform.rotation.z, transform.rotation.w);
        while (!transform.rotation.Equals(desiredRotation))
        {
            transform.RotateAround(followTarget.position, Vector3.up, 10 * Time.deltaTime);
            yield return null;
        }
    }
}