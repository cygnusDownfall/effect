using UnityEngine;

public class disscard : Effect
{
    public int num = 1;

    public override void startEffect(GameObject targets, GameObject source = null)
    {
        base.startEffect(targets, source);
        var cardHand = deckCard.Instance.cardInHand;
        if (cardHand.Count < num)
        {
            Debug.Log("khong du bai de kich hoat bo bai");
            return;
        }
        for (int i = 0; i < num; i++)
        {
            deckCard.Instance.returnCard(i);
        }
    }
}