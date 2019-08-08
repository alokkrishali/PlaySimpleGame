using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knief : MonoBehaviour
{
    public Rigidbody kniefRd = null;
    public Transform kniefTransform = null;
    public bool IsSettle = false;
    public KniefThrow kniefThrowRef;
    public int kniefIndex = 0;

    public bool HitToKnief = false;

    void Start()
    {
        kniefRd = GetComponent<Rigidbody>();
        kniefTransform = GetComponent<Transform>();
    }

    public void SetAt(Vector3 pos, Vector3 rotation)
    {
        kniefTransform.position = pos;
        kniefTransform.eulerAngles = rotation;
    }

    public void Enable(bool flag)
    {
        gameObject.SetActive(flag);
    }
}
