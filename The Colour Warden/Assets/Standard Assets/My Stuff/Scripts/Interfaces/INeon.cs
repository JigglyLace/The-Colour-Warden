using UnityEngine;

public interface INeon
{
    void UpdateRenderer(Color32 i_Colour);
    
    Color32 GetRendererColour();

    Color32 GetOriginalColour();
}