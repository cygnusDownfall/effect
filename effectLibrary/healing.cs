using UnityEngine;

[CreateAssetMenu(menuName = "effect/heal")]
public class healing : Effect
{
    public int heal;
    public int hps;
    public override string effect_detail
    {
        get => System.String.Format(
            ((effect_rate!=100)?"Có tỷ lệ {0}%":"")+
            "lập tức hồi {1} máu"+
            ((hps!=0)?"mỗi giây hồi {2} máu":"")
            ,effect_rate,heal,hps
        );
        set => base.effect_detail = value;
    }
    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets);
        targets.GetComponent<playerInfo>().healing(heal);
    }
    public override void triggerEffect(GameObject targets, GameObject source = null)
    {
        base.triggerEffect(targets);
        targets.GetComponent<playerInfo>().healing(hps);
    }
}
