using UnityEngine;

namespace ColourOperations
{
    public static class ColourOpposites
    {
        public static Color32 Calculate(Color32 originalColour)
        {
            byte maxRGBAValue = 255;
            Color32 oppositeColour = new Color32((byte)(maxRGBAValue - originalColour.r), (byte)(maxRGBAValue - originalColour.g), (byte)(maxRGBAValue - originalColour.b), maxRGBAValue);
            return oppositeColour;
        }
    }

    public static class MixColours
    {
        public static Color32 Blend(Color32 firstColour, Color32 secondColour)
        {
            Color32 m_BaseColour = firstColour;
            Color32 m_AddedColour = secondColour;

            byte maxValue = 255;
            bool stillAByte = StillAByte(m_BaseColour, m_AddedColour, maxValue);

            Color32 m_ColourBlend = new Color32();
            m_ColourBlend.r = stillAByte ? (byte)(m_BaseColour.r + m_AddedColour.r) : (byte)((m_BaseColour.r + m_AddedColour.r) / 2);
            m_ColourBlend.g = stillAByte ? (byte)(m_BaseColour.g + m_AddedColour.g) : (byte)((m_BaseColour.g + m_AddedColour.g) / 2);
            m_ColourBlend.b = stillAByte ? (byte)(m_BaseColour.b + m_AddedColour.b) : (byte)((m_BaseColour.b + m_AddedColour.b) / 2);
            m_ColourBlend.a = maxValue;
            
            return m_ColourBlend;
        }

        private static bool StillAByte(Color32 baseColour, Color32 addedColour, byte maxValue)
        {
            bool stillAByte = false;
            if ((baseColour.r + addedColour.r) <= maxValue && (baseColour.g + addedColour.g) <= maxValue && (baseColour.b + addedColour.b) <= maxValue) { stillAByte = true; }
            return stillAByte;
        }
    }
}