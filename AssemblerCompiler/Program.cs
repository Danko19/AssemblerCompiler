using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AssemblerCompiler.Binary;

namespace AssemblerCompiler
{
    public class Program
    {
        private readonly List<Instruction> instructions = new List<Instruction>();
        private readonly string fileName;
        private SegmnetType currentSegment;

        public readonly Dictionary<string, int> Labels = new Dictionary<string, int>();
        public int DataSize { get; private set; }
        public int CodeSize { get; private set; }
        public int RunNumber { get; private set; }
        public int Address => DataSize + CodeSize;
        public int ReferenceSize { get; set; }
        public int LabelSize { get; set; }

        public readonly ObjectFile ObjectFile = new ObjectFile();

        public Program(string fileName)
        {
            this.fileName = fileName;
        }

        public void Compile()
        {
            try
            {
                InitInstructions();
                while (!Run()) { }
                ObjectFile.HeaderBlock.Fill(fileName);
                ObjectFile.DescriptionBlock.SetDgroup();
                Console.WriteLine(Constants.CompilerName + " Copyright (c) 2018" + Environment.NewLine);
                ToBytes();
                Console.WriteLine("Error messages: none");
                Console.WriteLine("Warning messages: none");
                Console.WriteLine($"Passes: {RunNumber}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void InitInstructions()
        {
            var number = 0;
            foreach (var codeLine in File.ReadLines(fileName))
            {
                number++;
                if (codeLine == string.Empty) continue;
                instructions.Add(InstructionsManager.CreateInstruction(number, codeLine));
            }
        }

        private bool Run()
        {
            RunNumber++;
            var compiled = true;
            foreach (var instruction in instructions.Where(x => !x.Done))
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

        private void ToBytes()
        {
            var outputFileName = fileName.Split('.').First();
            outputFileName += ".obj";
            if (File.Exists(outputFileName))
                File.Delete(outputFileName);
            Console.WriteLine($"Assembling file: {fileName} to {outputFileName}");
            using (var fileStream = File.OpenWrite(outputFileName))
            using (var binaryWriter = new BinaryWriter(fileStream))
            {
                ObjectFile.ToBytes(binaryWriter);
            }
        }
    }
}
