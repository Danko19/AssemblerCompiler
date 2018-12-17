namespace AssemblerCompiler.Binary
{
    public class Segment
    {
        private readonly SegmentsBlock segmentsBlock;

        private Record definitionRecord;
        private Record referenceRecord;

        public Segment(SegmentsBlock segmentsBlock)
        {
            this.segmentsBlock = segmentsBlock;
        }

        public void AddDefinition(BinaryCode binaryCode)
        {
            InitDefinitionRecordIfNull();
            definitionRecord.AddBinaryCode(binaryCode);
        }

        public void AddReference(BinaryCode binaryCode)
        {
            InitReferenceRecordIfNull();
            referenceRecord.AddBinaryCode(binaryCode);
        }

        private void InitDefinitionRecordIfNull()
        {
            if (definitionRecord == null)
            {
                definitionRecord = new Record(0xA0);
                definitionRecord.AddBinaryCode(new BinaryCode(segmentsBlock.GetNextSegmentNumber()));
                segmentsBlock.AddRecord(definitionRecord);
            }
        }

        private void InitReferenceRecordIfNull()
        {
            InitDefinitionRecordIfNull();
            if (referenceRecord == null)
            {
                referenceRecord = new Record(0x9C);
                segmentsBlock.AddRecord(referenceRecord);
            }
        }
    }
}