using UnityEngine;
using ColourOperations;

public class DoorLight : MonoBehaviour, INeon
{
    Color32 originalColour;
    public Color32 GetOriginalColour() { return originalColour; }
    public Color32 RendererColourGetSet
    {
        get { return GetComponent<Renderer>().material.GetColor("_Color"); }
        private set { GetComponent<Renderer>().material.SetColor("_Color", value); }
    }
    void Awake()
    {
        originalColour = RendererColourGetSet;
        ApplyColour();
    }

    public void UpdateRenderer(Color32 m_Colour)
    {
        Color32 m_ColourBlend = MixColours.Blend(RendererColourGetSet, m_Colour);
        RendererColourGetSet = m_ColourBlend;
        ApplyColour();
    }

    [SerializeField] private Transform[] neonLinks;
    private void ApplyColour()
    {
        foreach (Transform neonLink in neonLinks)
        {
            neonLink.GetComponent<INeon>().UpdateRenderer(RendererColourGetSet);
        }
    }
}