using UnityEngine;

public class RandomAnimTime : MonoBehaviour
{
    public float difference = 30f;

    void Start()
    {
        GetComponentInChildren<Animator>().Update(Random.value * difference);
    }
}
