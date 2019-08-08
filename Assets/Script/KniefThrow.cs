using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KniefThrow : MonoBehaviour
{

    [SerializeField]
    Knief knief;

    [SerializeField]
    Vector3 initialPos, initialRotation;

    [SerializeField]
    List<Knief> kniefs = new List<Knief>();

    [SerializeField]
    int numberOfKneif = 10;

    [SerializeField]
    float kniefSpeed = 45;

    [SerializeField]
    Material blueKnief;

    private Transform thisTransform;
    int numberOfKniefThrow = 0;

    void Start()
    {
        thisTransform = GetComponent<Transform>();
        GameController.instance.Play -= SetKnief;
        GameController.instance.Play += SetKnief;
        generateKneif();
    }

    void generateKneif()
    {
        for(int i=0;i< numberOfKneif; i++)
        {
            Knief newknief = null;
            newknief = Instantiate(knief);
            newknief.kniefIndex = i;
            newknief.kniefThrowRef = this;
            newknief.name = "Knief_" + i;
            kniefs.Add(newknief);
        }
    }
    void SetKnief()
    {
        numberOfKniefThrow = 0;
        for (int i = 0; i < numberOfKneif; i++)
        {
            kniefs[i].IsSettle = false;
            kniefs[i].HitToKnief = false;
            kniefs[i].transform.SetParent(thisTransform);
            kniefs[i].kniefRd.isKinematic = true;
            kniefs[i].Enable(false);
        }
        SetAnotherKnief();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameController.instance.ISGamePlay)
            ThrowKnief();
    }
    public void SetAnotherKnief()
    {
        if (numberOfKniefThrow >= kniefs.Count)
            return;
        GameController.instance.ShowScore(numberOfKniefThrow);
        kniefs[numberOfKniefThrow].Enable(true);
        kniefs[numberOfKniefThrow].SetAt(initialPos, initialRotation);
    }
    void ThrowKnief()
    {
        if (numberOfKniefThrow == 10)
        {
            GameController.instance.GameComplete();
            return;
        }
        kniefs[numberOfKniefThrow].kniefRd.isKinematic = false;
        kniefs[numberOfKniefThrow].kniefRd.velocity = Vector3.up * kniefSpeed;
        numberOfKniefThrow++;
    }
}
