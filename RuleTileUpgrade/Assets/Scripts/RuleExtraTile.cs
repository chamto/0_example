using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

//유니티 Ver 2018.2.14f1 <RuleTile> => Ver 2022.3.9f1 업그레이드 작업
//namespace UnityVer2022_03_09_f1
namespace UnityEngine
{
    //public enum eDirection8 : int
    //{
    //    none = 0,
    //    center = none,
    //    right = 1,
    //    rightUp = 2,
    //    up = 3,
    //    leftUp = 4,
    //    left = 5,
    //    leftDown = 6,
    //    down = 7,
    //    rightDown = 8,
    //    max,
    //}


    /// <summary>
    /// This special tile add a third rule : adjacent tiles, so you can match rules with other tile than this one.
    /// See the cliff tile for an example.
    /// </summary>
    [CreateAssetMenu]
    public class RuleExtraTile : RuleTile_Custom<RuleExtraTile.Neighbor>
    {
        //Type m_NeighborType = typeof<Neighbor>; //타입을 받아온다 

        public class Neighbor : RuleTile_Custom.TilingRule.Neighbor
        {
            //public const int Adjacent = 4; //그리드에 인접타일 지정에 사용  
        }
        //public TileBase[] AdjacentTiles;

        //public override bool RuleMatch(int neighbor, TileBase other)
        //{
        //    switch (neighbor)
        //    {
        //        case Neighbor.Adjacent:
        //            return AdjacentTiles.Contains(other);
        //    }

        //    return base.RuleMatch(neighbor, other);
        //}
    }
}