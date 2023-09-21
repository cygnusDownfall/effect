using System;
using UnityEngine;

[CreateAssetMenu(menuName = "effect/Slow")]
class slow : Effect
{
    public int slowScale = 30;
    int slowValue = 0;
    public override string effect_detail
    {
        get
        {
            detail = String.Format(
                (effect_rate != 100) ? "Có {0}% tỷ lệ" : "" +
                " giảm <color=#00fafa>{1}%</color> tốc chạy kẻ địch trúng chiêu.",
                 effect_rate, slowScale);
            return detail;
        }

    }
    public override void startEffect(GameObject target, GameObject source = null)
    {
        base.startEffect(target);
        Debug.Log("slow    ");
        playerInfo playerInfo;
        if (target.TryGetComponent<playerInfo>(out playerInfo))
        {
            playerImpacteds = playerInfo;
            int slow = Convert.ToInt32(playerInfo.speed * slowScale / 100f);

            slowValue = slow;
            Debug.Log("Speed of player:"+playerInfo.speed);
            playerInfo.speed -= slow;
            Debug.Log("slow value:"+slow);
        }
    }
    public override void endEffect(GameObject gameObjects, GameObject source = null)
    {
        playerImpacteds.speed += slowValue;
    }
}