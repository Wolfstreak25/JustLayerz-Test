using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckModifier : MonoBehaviour
{
    [SerializeField] private TruckBody[] m_bodyParts;
    [SerializeField] private Texture2D[] m_albedoList;
    [SerializeField] private Material m_lights;
    [SerializeField] private Material[] m_bodyColors;
    public void ChangeBodyColours(int i)
    {
        foreach (var parts in  m_bodyParts)
        {
            if(parts.partType == PartType.MainBody)
            {
                var mater = parts.bodyPart.materials;
                mater[0] = m_lights;
                mater[1] = m_bodyColors[i];
                parts.bodyPart.materials = mater;
            }
            else
            {
                parts.bodyPart.material = m_bodyColors[i];
            }
            
        }
    }
    public void ChangeBodyTextures(int i)
    {
        foreach (var parts in  m_bodyParts)
        {
            
            if(parts.partType == PartType.MainBody)
            {
                parts.bodyPart.materials[1].SetTexture("_MainTex",m_albedoList[i]);
                parts.bodyPart.materials[0].SetTexture("_MainTex",null);
            }
            else
            {
                parts.bodyPart.material.SetTexture("_MainTex",m_albedoList[i]);
            }
        }

    }
}

// Part of different aproach
[System.Serializable]
public struct TruckBody
{
    public PartType partType;
    public Renderer bodyPart;
}
public enum PartType
{
    MainBody,
    Horns,
    FrontFender,
    Hood,
    GrillCase,
    Logo,
    Grill,
    FrontBumper,
    Wheels,
}