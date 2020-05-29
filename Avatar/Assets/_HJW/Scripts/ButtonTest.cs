using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    Button next;
    Button prev;

    public GameObject[] hair;
    public GameObject[] upBody;
    public GameObject[] downBody;

    int[] save = { 0, 0, 0 };
    int[] load = { 0, 0, 0 };

    int currHair = 0;
    int currUpbody;
    int currDownbody;

    private void Update()
    {
        for (int i = 0; i < hair.Length; i++)
        {
            if (i == currHair)
                hair[i].SetActive(true);
            else
                hair[i].SetActive(false);
        }
        for (int i = 0; i < upBody.Length; i++)
        {
            if (i == currUpbody)
                upBody[i].SetActive(true);
            else
                upBody[i].SetActive(false);
        }
        for (int i = 0; i < hair.Length; i++)
        {
            if (i == currDownbody)
                downBody[i].SetActive(true);
            else
                downBody[i].SetActive(false);
        }


    }

    public void NextHair()
    {
        currHair++;
        Debug.Log(currHair);
        if (currHair > hair.Length - 1)
            currHair = 0;
    }

    public void PrevHair()
    {
        currHair--;
        Debug.Log(currHair);
        if (currHair < 0)
            currHair = hair.Length - 1;
    }
    public void NextUp()
    {
        currUpbody++;
        Debug.Log(currUpbody);
        if (currUpbody > upBody.Length - 1)
            currUpbody = 0;
    }

    public void PrevUp()
    {
        currUpbody--;
        Debug.Log(currUpbody);
        if (currUpbody < 0)
            currUpbody = upBody.Length - 1;
    }
    public void NextDown()
    {
        currDownbody++;
        Debug.Log(currDownbody);
        if (currDownbody > downBody.Length - 1)
            currDownbody = 0;
    }

    public void PrevDown()
    {
        currDownbody--;
        Debug.Log(currDownbody);
        if (currDownbody < 0)
            currDownbody = downBody.Length - 1;
    }

    public void Save()
    {
        save[0] = currHair;
        save[1] = currUpbody;
        save[2] = currDownbody;
    }

    public void Load()
    {
        currHair = save[0];
        currUpbody = save[1];
        currDownbody = save[2];
    }
}
