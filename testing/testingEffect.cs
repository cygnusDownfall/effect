using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class testingEffect : MonoBehaviour
{
    public cardModel[] cardTest;
    public List<Effect> effects;
    public GameObject menuCam;
    public GameObject menuCanva;
    public TMP_Text loggerTest;
    public GameObject[] players;
    public List<Rigidbody> rigidbodies;
    public bool testMenu=false;
    private void Start()
    {
        menuCanva.SetActive(testMenu);
        for (int i = 0; i < players.Length; i++)
        {
            rigidbodies.Add(players[i].GetComponent<Rigidbody>());

        }
        menuCam.GetComponent<CinemachineVirtualCamera>().Priority = 0;
        Test();
    }

    void Update()
    {

    }

    public void Test(int i=0)
    {
        Debug.Log(cardTest[i].CardDescription);
        foreach (Effect ef in cardTest[i].cardEffect)
        {
            Debug.Log(ef.effect_detail);
            ef.onStart.AddListener(eff=>{
                Debug.Log("EffectStart: "+eff);
            });
            ef.onEnd.AddListener(eff =>
            {
                Debug.Log("end: "+eff);
            });
        }
        cardTest[i].effect(players[0].transform, players[1].transform.position);

    }

    public void TestEff()
    {
        foreach (Effect eff in effects)
        {
            eff.onStart.AddListener(ef =>
            {
                Debug.Log(eff.name, eff.source);
            });
            eff.trigger(players[0]);
        }
    }
}
