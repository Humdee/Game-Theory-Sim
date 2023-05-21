using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalScript : MonoBehaviour
{
    public static NormalScript instance;
    private System.Random random;
    public float mean;
    private void Awake() {
        instance = this;
    }
    private void Start()
    {
        random = new System.Random();
        mean = 10f;
    }

    public float GenerateRandomNumber()
    {
        double u1 = 1.0 - random.NextDouble();
        double u2 = 1.0 - random.NextDouble();
        double randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log((float)u1)) * Mathf.Sin(2.0f * Mathf.PI * (float)u2);
        float randNormal = (float)randStdNormal;
        float result = mean + randNormal;
        result = Mathf.Abs(result);
        return result;
    }
}
