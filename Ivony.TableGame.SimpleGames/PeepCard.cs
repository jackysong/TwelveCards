﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivony.TableGame.SimpleGames
{
  public class PeepCard : SimpleGameCard
  {



    public async override Task Execute( SimpleGamePlayer user, SimpleGamePlayer target )
    {
      user.GameHost.Game.AnnounceMessage( "{0} 使用了一张特殊卡牌", user.CodeName );
      foreach ( var player in user.Game.Players.Where( item => item != user ) )
      {
        player.DealCards();
        user.PlayerHost.WriteMessage( "{0} HP:{1,-3}{2}{3} 卡牌：{4}", player.CodeName, player.Health, player.ShieldState ? "S" : " ", player.AngelState ? "A" : player.AngelState ? "D" : " ", string.Join( ", ", player.Cards.Select( item => item.Name ) ) );
      }
    }

    public override string Name
    {
      get { return "窥视"; }
    }

    public override string Description
    {
      get { return "查看其它玩家手上所有的牌"; }
    }
  }
}
