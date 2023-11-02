using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditorInternal;
using System.Collections.Generic;


namespace UnityEditor
{

    /// <summary>
    /// The Editor for an RuleExtraTileEditor.
    /// </summary>
    [CustomEditor(typeof(RuleExtraTile))]
    public class RuleExtraTileEditor : RuleTile_Custom_Editor
    {
        
        /// <summary>
        /// The RuleExtraTileEditor being edited.
        /// </summary>
        public new RuleExtraTile tile => target as RuleExtraTile;

        protected override void OnDrawElement(Rect rect, int index, bool isactive, bool isfocused)
        {
            base.OnDrawElement(rect, index, isactive, isfocused);
        }

        //TilingRule 1 에 맞게 2 의 갯수를 맞춘다  
        //internal static void Sync_TilingRule_1_2(RuleExtraTile tile)
        //{
        //    int count1 = tile.m_TilingRules.Count;
        //    int count2 = tile.m_TilingRules_2.Count;

        //    if (count1 > count2)
        //    {
        //        for (int i = 0; i < count1 - count2; i++)
        //        {
        //            tile.m_TilingRules_2.Add(new RuleExtraTile.TilingRule_2());
        //        }
        //    }
        //    else if (count1 < count2)
        //    {
        //        for (int i = 0; i < count2 - count1; i++)
        //        {
        //            tile.m_TilingRules_2.RemoveAt(0);
        //        }
        //    }
        //}

    }
}
