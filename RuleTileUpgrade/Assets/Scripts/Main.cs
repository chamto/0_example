using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Main : MonoBehaviour
{

    public Tilemap _tilemap = null;
    RuleTile_Custom _ruleTile = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject o = GameObject.Find("Tilemap_test1");
        if (null != o)
        {
            _tilemap = o.GetComponent<Tilemap>();
            _tilemap.RefreshAllTiles(); //타일그리기를 한번더 출력한다 
            //Specifier_This(NotThis) 네이버모드일 경우 한번출력과 두번출력의 결과가 다르다.
            //_specifier 의 지정 비교시 , 비교대상 룰타일의 우선순위가 아래에 있는 경우 한번출력에서는 비교대상이 없어서 선택이 안된다
            //두번출력으로 비교대상이 미리 채워진 상태에서 지정자 비교를 할 수 있다 
        }



        Vector3Int XY_2d = new Vector3Int(27,-14,0); //chamto test
        _ruleTile = _tilemap.GetTile(XY_2d) as RuleTile_Custom;
        //RuleTile_Custom.TilingRule rule = _ruleTile._tileDataMap[XY_2d]._tilingRule;

        Debug.Log("----"+_ruleTile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    //void OnSceneGUI()
    {
#if UNITY_EDITOR
        if (null != _ruleTile)
        {
            //_tilemap.RefreshAllTiles(); //chamto test - GetTileData 를 다시호출하여 TileData를 다시 설정한다.
            ////내부 AppointData 데이터가 남아있기 때문에 문자열비교 규칙타일에서 기존 데이터를 참조하는 문제가 있다
            ///
            //_ruleTile.Debug_Print_BoderDir();
            //_ruleTile.Debug_Print_TileSeq();
        }
#endif
    }

    //public void LoadTilemap_Struct()
    //{
        
    //    RuleTile_Custom.TilingRule ruleInfo = null;
        
    //    foreach (Vector3Int XY_2d in _tilemap.cellBounds.allPositionsWithin)
    //    {
    //        RuleTile_Custom ruleTile = _tilemap.GetTile(XY_2d) as RuleTile_Custom;
    //        if (null == ruleTile) continue;

    //        ruleInfo = ruleTile._tileDataMap.GetTilingRule(XY_2d);
            

    //    }

    //}
}
