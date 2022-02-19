using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windDelta = 0.1f;
    public float windUpdateTime = 0.5f;
    public float windMaxMagnitude = 10f;
    public float windStartMaxMagnitude = 3f;

    [SerializeField]
    private Vector2 wind;
    private Vector2 windUpdated;
    private float time;


    // Start is called before the first frame update
    void Start()
    {
        SetWind(Random.insideUnitCircle * windStartMaxMagnitude);
    }
    public Vector2 GetWind()
    {
        return wind;
    }

    public void SetWind(Vector2 newWind)
    {
        wind = newWind;
        windUpdated = wind;
        time = 0f;
    }

    public void UpdateWind()
    {
        wind = Vector2.Lerp(wind, windUpdated, Time.deltaTime);
    }

    private Vector2 GetUpdatedWind()
    {
        Vector2 result = wind + Random.insideUnitCircle * windDelta;
        result = result.normalized * Mathf.Min(result.magnitude, windMaxMagnitude);
        return result;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateWind();
        time += Time.deltaTime;
        if(time > windUpdateTime)
        {
            time = 0f;
            windUpdated = GetUpdatedWind();        }
    }
}
