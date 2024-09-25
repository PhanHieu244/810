using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.SceneManagement;
public class Clicks : MonoBehaviour
{
    RaycastHit Hit;
    public GameObject Frame;
    public int PopCount;
    public int totalpops;
    public static Clicks instance;
    public List<GameObject> poped;
    public bool normal;
    public bool A;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    void Start()
    {
        PopCount = 0;
        A = true;
        normal = true;
        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && A)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
            {
                if (Hit.collider != null)
                {
                    if (Hit.collider.tag == "Pop")
                    {
                        GameObject thispop = Hit.collider.gameObject;
                        if (AudioManager.instance)
                        {
                            AudioManager.instance.Play("pop it");
                        }
                        poped.Add(thispop);
                        thispop.GetComponent<Pop>().reverse();
                        thispop.GetComponent<BoxCollider>().enabled = false;
                        Frame.transform.DOShakeRotation(0.8f, 1.5f);
                        PopCount++;
                        if (totalpops == PopCount)
                        {
                            A = false;
                            if (normal)
                            {
                                Frame.transform.DORotate(new Vector3(-90, 0, -180), 1).OnComplete(onray);
                                normal = false;

                            }
                            else
                            {

                                Frame.transform.DORotate(new Vector3(-90, 0, 0), 1).OnComplete(onray);
                                normal = true;

                            }
                            Flip();
                        }
                    }
                }
            }
        }
    }
    public void Flip()
    {
        for (int i = 0; i < poped.Count; i++)
        {
            poped[i].GetComponent<BoxCollider>().enabled = true;
        }
        poped.Clear();
        PopCount = 0;

    }
    public void onray()
    {
        A = true;
    }

}
