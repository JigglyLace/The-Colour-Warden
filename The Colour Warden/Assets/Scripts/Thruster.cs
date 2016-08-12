using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour
{
    public Transform TargetTransform;
    public float rotSpeed = 5;

    void Update()
    {
        RotateAround(TargetTransform.position);
    }

    public void RotateAround(Vector2 playerPos)
    {
        Debug.Log("rotating");
        transform.Rotate(playerPos, rotSpeed, Space.Self);
    }
}