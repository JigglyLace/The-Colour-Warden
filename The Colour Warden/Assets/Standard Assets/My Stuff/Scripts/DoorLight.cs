using UnityEngine;
using ColourOperations;

public class DoorLight : MonoBehaviour, INeon
{
    Color32 originalColour;
    public Color32 GetOriginalColour() { return originalColour; }
     
    void Awake()
    {
        originalColour = GetRendererColour();
        ApplyColour();
    } 

    public void UpdateRenderer(Color32 m_Colour)
    {
        Color32 m_ColourBlend = MixColours.Blend(GetRendererColour(), m_Colour);
        SetRendererColour(m_ColourBlend);
        ApplyColour();
    }
    
    public Color32 GetRendererColour() { return GetComponent<Renderer>().material.GetColor("_Color"); }
    private void SetRendererColour(Color32 i_Colour) { GetComponent<Renderer>().material.SetColor("_Color", i_Colour); }

    [SerializeField] private Transform[] neonLinks;
    private void ApplyColour()
    {
        foreach (Transform neonLink in neonLinks)
        {
            neonLink.GetComponent<INeon>().UpdateRenderer(GetRendererColour());
        }
    }
}