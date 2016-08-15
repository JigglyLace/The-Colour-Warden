using UnityEngine;

public class NeonLightLink : MonoBehaviour, INeon
{
    private Color32 originalColour;
    public Color32 GetOriginalColour() { return originalColour; }
    public Color32 RendererColourGetSet
    {
        get { return GetComponent<Renderer>().material.GetColor("_Color"); }
        private set { GetComponent<Renderer>().material.SetColor("_Color", value); }
    }

    [SerializeField] private Transform neonLink;
    void Start()
    {
        neonLink.GetComponent<INeon>().UpdateRenderer(RendererColourGetSet);
        originalColour = RendererColourGetSet;
    }

    public void UpdateRenderer(Color32 i_Colour)
    {
        RendererColourGetSet = i_Colour;
        if (!RendererColourGetSet.Equals(GetConcurrentColour()))
        {
            neonLink.GetComponent<INeon>().UpdateRenderer(RendererColourGetSet);
        }
        SetConcurrentColour(i_Colour);
    }

    private Color32 concurrentColour = new Color32();
    private Color32 GetConcurrentColour() { return concurrentColour; }
    private void SetConcurrentColour(Color32 currentColour) { concurrentColour = currentColour; }
}