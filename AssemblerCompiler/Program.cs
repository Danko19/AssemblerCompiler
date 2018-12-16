using System.Collections.Generic;
using System.IO;
using AssemblerCompiler.Binary;

namespace AssemblerCompiler
{
    public class Program
    {
        private readonly List<Instruction> instructions = new List<Instruction>();
        private readonly string fileName;
        private SegmnetType currentSegment;

        public int DataSize { get; private set; }
        public int CodeSize { get; private set; }
        public int ReferenceSize { get; set; }

        public readonly ObjectFile ObjectFile = new ObjectFile();

        public Program(string fileName)
        {
            this.fileName = fileName;
        }

        public void Compile()
        {
            InitInstructions();
            while (!Run()) {}
        }

        private void InitInstructions()
        {
            foreach (var codeLine in File.ReadLines(fileName))
                instructions.Add(InstructionsManager.CreateInstruction(codeLine));
        }

        private bool Run()
        {
            var compiled = true;
            foreach (var instruction in instructions)
            {
                instruction.Execute(this);
                if (!instruction.Done)
                    compiled = false;
            }

            return compiled;
        }

        public void AddDataLength(int size)
        {
            DataSize += size;
        }

        public void AddCodeLength(int size)
        {
            CodeSize += size;
        }

        public void StartSegment(SegmnetType segmnetType)
        {
            EndCurrentSegment();
            if (segmnetType == SegmnetType.Data)
                ObjectFile.DescriptionBlock.StartDataSegment();
            if (segmnetType == SegmnetType.Code)
                ObjectFile.DescriptionBlock.StartCodeSegment();
            currentSegment = segmnetType;
        }

        public void EndCurrentSegment()
        {
            if (currentSegment == SegmnetType.Data)
                ObjectFile.DescriptionBlock.EndSegment(DataSize);
            if (currentSegment == SegmnetType.Code)
                ObjectFile.DescriptionBlock.EndSegment(CodeSize);
        }
    }
}
