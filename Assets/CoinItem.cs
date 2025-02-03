using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : Item
{
    public int coinAmount = 1;

    public override void OnPickup(PlayerScript player)
    {
        player.increaseCoins(coinAmount);
    }
}
