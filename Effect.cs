using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "effect")]
public class Effect : ScriptableObject, INetworkSerializable
{
    #region properties
    public byte effect_rate = 100;
    public byte duration = 1;
    [SerializeField] protected string detail;
    public virtual string effect_detail
    {
        get
        {
            return detail;
        }
        set
        {
            detail = value;
        }
    }
    public float callbyseccond = 1;

    public playerInfo playerImpacteds;
    public GameObject source;
    #endregion
    #region event
    public UnityEvent<Effect> onStart, onTrigger, onEnd;
    #endregion

    #region method
    public delegate void EffectDelegate(GameObject target, GameObject source = null);
    public IEnumerator trigger(GameObject target)
    {
        int r;
        if ((r = Random.Range(0, 100)) < effect_rate)
        {
            Debug.Log("random rate:" + r);
            return DurationCall(triggerEffect, source, target, startEffect, endEffect);
        }
        return null;
    }
    #region effect
    public virtual void triggerEffect(GameObject targets, GameObject source = null)
    {
        onTrigger.Invoke(this);

    }
    public virtual void startEffect(GameObject targets, GameObject source = null)
    {
        onStart.Invoke(this);
        //targets.GetComponent<playerInfo>().addChain(this); add xong moi chay nen khong the dat o day 
    }
    public virtual void endEffect(GameObject targets, GameObject source = null)
    {
        onEnd.Invoke(this);
        targets.GetComponent<playerInfo>().removeChain(this);
        Destroy(this);
    }
    #endregion
    public IEnumerator DurationCall(EffectDelegate effect, GameObject source, GameObject target, EffectDelegate starteff = null, EffectDelegate endeff = null)
    {
        if (starteff != null)
        {
            starteff(target, source);
        }
        for (float i = 0; i < duration; i += callbyseccond)
        {
            effect(target, source);
            yield return new WaitForSeconds(callbyseccond);
        }
        if (endeff != null)
        {
            endeff(target, source);
        }
        yield break;
    }
    void OnDestroy()
    {
        onStart.RemoveAllListeners();
        onEnd.RemoveAllListeners();
        onTrigger.RemoveAllListeners();
    }

    public virtual void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref effect_rate);
        serializer.SerializeValue(ref duration);
        serializer.SerializeValue(ref callbyseccond);
        serializer.SerializeValue(ref detail);

    }
    #endregion
}