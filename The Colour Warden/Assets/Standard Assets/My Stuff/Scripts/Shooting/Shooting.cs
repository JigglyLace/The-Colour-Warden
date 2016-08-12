using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private byte mouseButton;
    void Update()
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            Fire();
        }
    }

    [SerializeField] private Transform prefab;

    void Fire()
    {
        Transform instancePrefab = Instantiate(prefab, transform.GetChild(0).position, transform.rotation) as Transform;
        instancePrefab.GetComponent<ShootForce>().SetBulletColour(GetRendererColour());
    }

    Color32 GetRendererColour() { return GetComponent<Renderer>().material.GetColor("_Color"); }
}