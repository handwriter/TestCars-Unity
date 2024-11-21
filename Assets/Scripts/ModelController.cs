using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ModelController
{
    public static int TryIndex;
    
    public class RepeatPoint
    {
        public float Time;
        public Vector3 WorldPosition;
        public Quaternion WorldRotation;

        public RepeatPoint(float time, Vector3 worldPosition, Quaternion worldRotation)
        {
            this.Time = time;
            this.WorldPosition = worldPosition;
            this.WorldRotation = worldRotation;
        }
    }
    public static RepeatPoint[] LastCarPath;
}
