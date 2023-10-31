using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditorInternal;
using System.Collections.Generic;
using UnityVer2022_03_09_f1;

namespace UnityEditor
{

    /// <summary>
    /// The Editor for an RuleExtraTileEditor.
    /// </summary>
    [CustomEditor(typeof(RuleExtraTile))]
    public class RuleExtraTileEditor : RuleTileEditor
    {
        private static class Styles
        {
            public static readonly GUIContent defaultSprite = EditorGUIUtility.TrTextContent("!!!Default Sprite"
                , "!!!Overrides the default Sprite for the original Rule Tile.");
            public static readonly GUIContent defaultGameObject = EditorGUIUtility.TrTextContent("!!!Default GameObject"
                , "Overrides the default GameObject for the original Rule Tile.");
            public static readonly GUIContent defaultCollider = EditorGUIUtility.TrTextContent("!!!Default Collider"
                , "Overrides the default Collider for the original Rule Tile.");
        }

        /// <summary>
        /// The RuleExtraTileEditor being edited.
        /// </summary>
        public new RuleExtraTile tile => target as RuleExtraTile;


        /// <summary>
        /// OnEnable for the RuleExtraTileEditor
        /// </summary>
        //public override void OnEnable()
        //{
        //    if (m_RuleList == null)
        //    {
        //        m_RuleList = new ReorderableList(m_Rules, typeof(KeyValuePair<RuleTile.TilingRule, RuleTile.TilingRule>), false, true, false, false);
        //        //m_RuleList.drawHeaderCallback = DrawRulesHeader;
        //        //m_RuleList.drawElementCallback = DrawRuleElement;
        //        //m_RuleList.elementHeightCallback = GetRuleElementHeight;
        //    }
        //}

        /// <summary>
        /// Draws the Inspector GUI for the RuleExtraTileEditor
        /// </summary>
        //public override void OnInspectorGUI()
        //{
        //    serializedObject.UpdateIfRequiredOrScript();

        //    DrawTileField();

        //    EditorGUI.BeginChangeCheck();
        //    overrideTile.m_DefaultSprite = EditorGUILayout.ObjectField(Styles.defaultSprite, overrideTile.m_DefaultSprite, typeof(Sprite), false) as Sprite;
        //    overrideTile.m_DefaultGameObject = EditorGUILayout.ObjectField(Styles.defaultGameObject, overrideTile.m_DefaultGameObject, typeof(GameObject), false) as GameObject;
        //    overrideTile.m_DefaultColliderType = (Tile.ColliderType)EditorGUILayout.EnumPopup(Styles.defaultCollider, overrideTile.m_DefaultColliderType);
        //    if (EditorGUI.EndChangeCheck())
        //        SaveTile();

        //    DrawCustomFields();

        //    //if (overrideTile.m_Tile)
        //    //{
        //    //    ValidateRuleTile(overrideTile.m_Tile);
        //    //    overrideTile.GetOverrides(m_Rules, ref m_MissingOriginalRuleIndex);
        //    //}

        //    m_RuleList.DoLayoutList();
        //}

        protected override void OnDrawElement(Rect rect, int index, bool isactive, bool isfocused)
        {
            Sync_TilingRule_1_2(tile); 

            RuleTile.TilingRule rule = tile.m_TilingRules[index];
            BoundsInt bounds = GetRuleGUIBounds(rule.GetBounds(), rule);

            float yPos = rect.yMin + 2f;
            float height = rect.height - k_PaddingBetweenRules;
            Vector2 matrixSize = GetMatrixSize(bounds);

            Rect spriteRect = new Rect(rect.xMax - k_DefaultElementHeight - 5f, yPos, k_DefaultElementHeight, k_DefaultElementHeight);
            Rect matrixRect = new Rect(rect.xMax - matrixSize.x - spriteRect.width - 10f, yPos, matrixSize.x, matrixSize.y);
            Rect inspectorRect = new Rect(rect.xMin, yPos, rect.width - matrixSize.x - spriteRect.width - 20f, height);

            RuleInspectorOnGUI(inspectorRect, rule);
            RuleMatrixOnGUI(tile, matrixRect, bounds, rule);
            RuleMatrixOnGUI_Direction(tile, inspectorRect,index, rule);
            SpriteOnGUI(spriteRect, rule);

        }

        //TilingRule 1 에 맞게 2 의 갯수를 맞춘다  
        internal static void Sync_TilingRule_1_2(RuleExtraTile tile)
        {
            int count1 = tile.m_TilingRules.Count;
            int count2 = tile.m_TilingRules_2.Count;

            if (count1 > count2)
            {
                for (int i = 0; i < count1 - count2; i++)
                {
                    tile.m_TilingRules_2.Add(new RuleExtraTile.TilingRule_2());
                }
            }
            else if (count1 < count2)
            {
                for (int i = 0; i < count2 - count1; i++)
                {
                    tile.m_TilingRules_2.RemoveAt(0);
                }
            }


        }

        internal static void RuleMatrixOnGUI_Direction(RuleExtraTile tile, Rect rect, int index, RuleExtraTile.TilingRule tilingRule)
        {

            RuleExtraTile.TilingRule_2 info2 = tile.m_TilingRules_2[index];

            Rect r = rect;
            r.x -= 20f;
            r.y += 20f;
            r.width = 20f;
            r.height = 20f;



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
            //s_Arrows[0] = Base64ToTexture(s_Arrow0); //leftUp ->    4 -> 0
            //s_Arrows[1] = Base64ToTexture(s_Arrow1); //up ->        3 -> 1
            //s_Arrows[2] = Base64ToTexture(s_Arrow2); //rightUp ->   2 -> 2
            //s_Arrows[3] = Base64ToTexture(s_Arrow3); //left ->      5 -> 3
            //s_Arrows[5] = Base64ToTexture(s_Arrow5); //right ->     1 -> 5
            //s_Arrows[6] = Base64ToTexture(s_Arrow6); //leftDown ->  6 -> 6
            //s_Arrows[7] = Base64ToTexture(s_Arrow7); //down ->      7 -> 7
            //s_Arrows[8] = Base64ToTexture(s_Arrow8); //rightDown -> 8 -> 8
            //s_Arrows[9] = Base64ToTexture(s_XIconString); //        0 -> 9
            int[] tr = new int[] { 9, 5, 2, 1, 0, 3, 6, 7, 8 };
            int trans_index = tr[info2._border_dir];

            if ((int)info2._border_dir < 0) info2._border_dir = 0;

            GUI.DrawTexture(r, RuleTileEditor.arrows[trans_index]);

            if (Event.current.type == EventType.MouseDown && r.Contains(Event.current.mousePosition))
            {
                info2._border_dir = (((int)info2._border_dir+1) % 9);
                GUI.changed = true;
                Event.current.Use();
            }

            //Debug.Log(info2._border_dir);

        }

    }
}
