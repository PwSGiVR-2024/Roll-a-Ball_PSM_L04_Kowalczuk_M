using UnityEngine;

public static class Tools
{
    public struct Activable
    {
        public float delay;
        public IActivable activable;
        public Activable(float delay, IActivable activable)
        {
            this.delay = delay;
            this.activable = activable;
        }
    }

    [System.Serializable]
    public struct ActivableObject
    {
        public float delay;
        public GameObject activableObject;
    }
}
