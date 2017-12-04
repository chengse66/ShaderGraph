using UnityEngine;
using UnityEditor.Graphing;

namespace UnityEditor.ShaderGraph
{
    interface IMayRequireVertexColor
    {
        bool RequiresVertexColor();
    }

    [Title("Input", "Geometry", "Vertex Color")]
    public class VertexColorNode : AbstractMaterialNode, IMayRequireVertexColor
    {
        private const int kOutputSlotId = 0;
        private const string kOutputSlotName = "Out";

        public override bool hasPreview { get { return true; } }

        public override PreviewMode previewMode
        {
            get { return PreviewMode.Preview3D; }
        }

        public VertexColorNode()
        {
            name = "Vertex Color";
            UpdateNodeAfterDeserialization();
        }

        public sealed override void UpdateNodeAfterDeserialization()
        {
            AddSlot(new Vector4MaterialSlot(kOutputSlotId, kOutputSlotName, kOutputSlotName, SlotType.Output, Vector4.one));
            RemoveSlotsNameNotMatching(new[] { kOutputSlotId });
        }

        public override string GetVariableNameForSlot(int slotId)
        {
            return ShaderGeneratorNames.VertexColor;
        }

        public bool RequiresVertexColor()
        {
            return true;
        }
    }
}
