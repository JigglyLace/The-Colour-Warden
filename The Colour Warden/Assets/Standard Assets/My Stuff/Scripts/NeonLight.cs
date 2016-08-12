using UnityEngine;
using ColourOperations;

public class NeonLight : MonoBehaviour, INeon
{
    [SerializeField] private GameObject doorLink;
    bool setOriginalColour = false;
    public void UpdateRenderer(Color32 m_Colour)
    {
        Color32 m_CalculatedColour;
        if  (m_Colour == Color.white) { m_CalculatedColour = doorLink.GetComponent<INeon>().GetOriginalColour(); }
        else { m_CalculatedColour = ColourOpposites.Calculate(m_Colour); }

        SetRendererColour(m_CalculatedColour);
        if (!setOriginalColour) { SetOriginalColour(GetRendererColour()); }
    }

    private Color32 originalColour;
    public Color32 GetOriginalColour() { return originalColour; }
    private void SetOriginalColour(Color32 m_OriginalColour) { originalColour = m_OriginalColour; setOriginalColour = true; }

    public Color32 GetRendererColour() { return GetComponent<Renderer>().material.GetColor("_Color"); }
    private void SetRendererColour(Color32 i_Colour) { GetComponent<Renderer>().material.SetColor("_Color", i_Colour); }
}