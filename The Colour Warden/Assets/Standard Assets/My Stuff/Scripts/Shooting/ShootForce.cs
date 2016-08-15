using UnityEngine;

public class ShootForce : MonoBehaviour
{
    public Color32 BulletColourGetSet
    {
        private get { return GetComponent<Renderer>().material.GetColor("_Color"); }
        set { GetComponent<Renderer>().material.SetColor("_Color", value); }
    }
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", BulletColourGetSet);
        Launch();
    }
        
    float speed = 50F;
    void Launch()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collisionObject)
    {
        Transform m_CollidedTransform = collisionObject.transform;
        IsColourable(m_CollidedTransform);
    }

    void IsColourable(Transform collidedTransform)
    {
        INeon neonController;
        neonController = collidedTransform.GetComponent<INeon>();
        if (neonController != null)
        {
            neonController.UpdateRenderer(BulletColourGetSet);
        }
    }

    void OnCollisionExit()
    {
        Destroy(gameObject);
    }
}