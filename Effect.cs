using System.Collections;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public int effect_rate;
    public int duration;
    public delegate void EffectDelegate(GameObject target);
    public void trigger(GameObject target)
    {
        if (Random.value < effect_rate)
        {
            //triggerEffect(target);
            this.transform.SetParent(target.transform, false);
            StartCoroutine(DurationCall(triggerEffect, target));
        }
    }
    public virtual void triggerEffect(GameObject target)
    {

    }
    public IEnumerator DurationCall(EffectDelegate effect, GameObject target)
    {
        for (int i = 0; i < duration; i++)
        {
            effect(target);
            yield return new WaitForSeconds(1);
        }
        yield break;
    }
}