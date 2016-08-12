using UnityEngine;
using System.Collections;

public class CollisionDetections : MonoBehaviour
{
    Color32 objectColour;
    Color32 currentColour;
    Transform m_CollidedObject;
    void OnCollisionEnter(Collision collisionTransform)
    {
        m_CollidedObject = collisionTransform.transform;
        currentColour = GetRendererColour();
        objectColour = m_CollidedObject.GetComponent<Renderer>().material.GetColor("_Color");
        SetRendererColour(objectColour);
    }

    void OnCollisionExit() { SetRendererColour(currentColour); }

    private Color32 GetRendererColour() { return GetComponent<Renderer>().material.GetColor("_Color"); }
    private void SetRendererColour(Color32 newColour) { GetComponent<Renderer>().material.SetColor("_Color", newColour); }
}