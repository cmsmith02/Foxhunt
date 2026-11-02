using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : MonoBehaviour
{
    GameObject transmitter;
    public float dist;
    public float gain;
    public float freq;
    public float pow;
    public float str;
    // Start is called before the first frame update
    void Start()
    {
        transmitter = GameObject.FindWithTag("Transmitter");
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transmitter.transform.position, transform.position);
        dist = Mathf.Max(dist, 1f);
        float FSPL = 20*Mathf.Log10(dist)+20*Mathf.Log10(freq)-27.56f;
        float prx = pow + gain - FSPL;
        float gLinear = Mathf.Pow(10, gain / 10);
        float HPBW = Mathf.Pow(41253 / gLinear, 0.5f);
        Vector3 dir = (transmitter.transform.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, dir);
        str = prx - 12 * Mathf.Pow((angle / HPBW), 2f);
    }
}
