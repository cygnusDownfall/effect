using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "effect")]
public class Effect :ScriptableObject
{
    public int effect_rate=100;
    public int duration=1;
    public  string effect_detail;
    public float callbyseccond = 1;

            
    protected List<playerInfo> playerImpacteds=new List<playerInfo>();

    public delegate void EffectDelegate(GameObject[] target);
    public IEnumerator trigger(GameObject[] target)
    {
        if (Random.value < (effect_rate/100f))
        {
            return DurationCall(triggerEffect, target,startEffect,endEffect);
        }
        return null;
    }
    public virtual void triggerEffect(GameObject[] targets)
    {

    }
    public virtual void startEffect(GameObject[] targets)
    {

    }
    public virtual void endEffect(GameObject[] targets)
    {

    }
    public IEnumerator DurationCall(EffectDelegate effect, GameObject[] target, EffectDelegate starteff = null, EffectDelegate endeff = null)
    {
        if (starteff != null)
        {
            starteff(target);
        }
        for (float i = 0; i < duration; i += callbyseccond)
        {
            effect(target);
            yield return new WaitForSeconds(1);
        }
        if (endeff != null)
        {
            endeff(target);
        }
        yield break;
    }
}