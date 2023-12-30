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
            _ruleTile.Debug_Print_BoderDir();
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
