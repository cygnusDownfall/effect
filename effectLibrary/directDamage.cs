using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "effect/Damage/direct")]
public class directDamge : damage
{
    public override string effect_detail
    {
        get
        {
            try
            {
                return System.String.Format(
                            ((effect_rate != 100) ? "Có tỷ lệ {3}%" : "") +
                            "Gây <color={1}>{0}</color>  sát thương <color={1}>{2}</color>"
                            , dmg, Dic.singleton.colorOfDame[dmgType]
                            , Dic.singleton.nameOfDame[dmgType], effect_rate);
            }
            catch (UnityException e)
            {
                Debug.Log(e);
                return "";
            }

        }
        set => base.effect_detail = value;
    }

    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets);
        Dmg(dmg, dmgType, targets);
    }

}