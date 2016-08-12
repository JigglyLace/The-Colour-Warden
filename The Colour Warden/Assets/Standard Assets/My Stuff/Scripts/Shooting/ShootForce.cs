using UnityEngine;

public class ShootForce : MonoBehaviour
{
    private Color32 bulletColour;
    public Color32 GetBulletColour() { return bulletColour; }
    public void SetBulletColour(Color32 newBulletColour) { bulletColour = newBulletColour; }
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", GetBulletColour());
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
            neonController.UpdateRenderer(GetComponent<Renderer>().material.GetColor("_Color"));
        }
    }

    void OnCollisionExit()
    {
        Destroy(gameObject);
    }
}