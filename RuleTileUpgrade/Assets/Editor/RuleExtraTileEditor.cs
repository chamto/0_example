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

    }
}
