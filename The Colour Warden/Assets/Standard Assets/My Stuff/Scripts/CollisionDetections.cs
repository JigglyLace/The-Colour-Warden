using UnityEngine;
using System.Collections;

public class CollisionDetections : MonoBehaviour
{
    private Color32 ColourGetSet
    {
        get { return GetComponent<Renderer>().material.GetColor("_Color"); }
        set { GetComponent<Renderer>().material.SetColor("_Color", value); }
    }

    Color32 currentColour;
    Color32 objectColour;
    void OnCollisionEnter(Collision collisionTransform)
    {
        Transform m_CollidedObject = collisionTransform.transform;
        currentColour = ColourGetSet;
        objectColour = m_CollidedObject.GetComponent<Renderer>().material.GetColor("_Color");
        ColourGetSet = objectColour;
    }

    void OnCollisionExit() { ColourGetSet = currentColour; }
}