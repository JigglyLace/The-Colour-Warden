using UnityEngine;
using System.Collections;

public class ColourPicker : MonoBehaviour
{
    private new Renderer renderer = new Renderer();
    void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    public void SetRendererColour(Color32 i_Colour)
    {
        renderer.material.SetColor("_Color", i_Colour);
    }

    public Color32 GetRendererColour()
    {
        return renderer.material.GetColor("_Color");
    }
}