using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

//유니티 Ver 2018.2.14f1 <RuleTile> => Ver 2022.3.9f1 업그레이드 작업
namespace UnityVer2022_03_09_f1
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
            public const int Adjacent = 3; //그리드에 인접타일 지정에 사용  
        }

        //TilingRule 의 확장 정보를 가진 객체 , 상속으로 정보를 확장할 수 없어서 추가로 객체를 만듦  
        //public class TilingRule_2
        //{
        //    public int _border_dir = 0; //arrows 경계 방향이 들어간다 , eDirection8 방향값으로 변환되어 들어간다 
        //}

        //[HideInInspector] public List<TilingRule_2> m_TilingRules_2 = new List<TilingRule_2>();

        public TileBase[] AdjacentTiles;

        public override bool RuleMatch(int neighbor, TileBase other)
        {

            switch (neighbor)
            {
                case Neighbor.Adjacent:
                    return AdjacentTiles.Contains(other);
            }

            return base.RuleMatch(neighbor, other);
        }
    }
}