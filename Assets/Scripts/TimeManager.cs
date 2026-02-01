using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float startTime = 120.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;

        if (startTime <= 0)
        {
            Debug.Log("Dance is over");
        }
    }
}
