using UnityEngine;

public class NeonLightLink : MonoBehaviour, INeon
{
    private Color32 originalColour;
    public Color32 GetOriginalColour() { return originalColour; }

    [SerializeField] private Transform neonLink;
    void Start()
    {
        neonLink.GetComponent<INeon>().UpdateRenderer(GetRendererColour());
        originalColour = GetRendererColour();
    }

    public void UpdateRenderer(Color32 i_Colour)
    {
        SetRendererColour(i_Colour);
        if (!GetRendererColour().Equals(GetConcurrentColour()))
        {
            neonLink.GetComponent<INeon>().UpdateRenderer(GetRendererColour());
        }
        SetConcurrentColour(i_Colour);
    }

    public Color32 GetRendererColour() { return GetComponent<Renderer>().material.GetColor("_Color"); }
    private void SetRendererColour(Color32 i_Colour) { GetComponent<Renderer>().material.SetColor("_Color", i_Colour); }


    private Color32 concurrentColour = new Color32();
    private Color32 GetConcurrentColour() { return concurrentColour; }
    private void SetConcurrentColour(Color32 currentColour) { concurrentColour = currentColour; }
}