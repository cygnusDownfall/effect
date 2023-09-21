
using UnityEngine;
public class negate : Effect
{
    public System.Type targetType;
    public override string effect_detail
    {
         get => System.String.Format(
            ((effect_rate!=100)?"Có tỷ lệ {0}%":"")+
            "vô hiệu 1 hiệu ứng đang ảnh hưởng "
            
            ,effect_rate
        );
        set => base.effect_detail = value;
    }
    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets);
        var player = targets.GetComponent<playerInfo>();
        foreach (var eff in player.chainEffect)
        {
            if (eff.GetType() == targetType)
            {
                player.removeChain(eff);
                Destroy(eff);
            }
        }
        base.endEffect(targets);
    }

}