using Unity.Netcode;
using UnityEngine;
public class breakArmor : Effect
{
    public byte breakValue = 0;
    public DmgType breakType;
    public override string effect_detail
    {
        get
        {
            detail = System.String.Format(
                ((effect_rate != 100) ? "Có {0}% tỷ lệ" : "") +
                " giảm <color=#00fafa>{1}</color> kháng {2} của kẻ địch trúng chiêu.",
                 effect_rate, breakValue, Dic.singleton.nameOfDame[breakType]);
            return detail;
        }

    }
    public override void startEffect(GameObject target, GameObject source = null)
    {
        base.startEffect(target);
        Debug.Log("break armor    ");
        playerInfo playerInfo;
        if (target.TryGetComponent(out playerInfo))
        {
            playerImpacteds = playerInfo;

            playerInfo.defence[breakType] -= breakValue;
        }
    }
    public override void endEffect(GameObject gameObjects, GameObject source = null)
    {
        playerImpacteds.defence[breakType] += breakValue;
    }
    public override void NetworkSerialize<T>(BufferSerializer<T> serializer)
    {
        base.NetworkSerialize(serializer);
        serializer.SerializeValue(ref breakType);
        serializer.SerializeValue(ref breakValue);
    }
}