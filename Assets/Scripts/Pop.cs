using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pop : MonoBehaviour
{
    public bool normal;
    public float firstfold;
    void Start()
    {
        Clicks.instance.totalpops++;
        normal = true;
        firstfold = transform.localScale.y;
    }
    public void reverse()
    {
        if (normal)
        {
            normal = false;
            transform.DOScale(new Vector3(transform.localScale.x, -firstfold, transform.localScale.z), 0.5f);
        }
        else
        {
            transform.DOScale(new Vector3(transform.localScale.x, firstfold, transform.localScale.z), 0.5f);
            normal = true;

        }
    }
}
