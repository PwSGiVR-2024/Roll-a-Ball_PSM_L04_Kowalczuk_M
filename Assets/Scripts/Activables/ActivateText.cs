using UnityEngine;
using System.Collections.Generic;

public class ActivateText : MonoBehaviour, IActivable
{
    [SerializeField] List<string> texts;
    [SerializeField] TextWriter writer;
    public void Activate()
    {
        writer.writeText("");
    }

    public void Activate(float delay)
    {
        if(delay < texts.Count)
        {
            writer.writeText(texts[(int)delay]);
        }
    }
}
