using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask7
{
    public class ElementData
    {
        public string TypeName { get; }
        public ElementId ElementId { get; }
        public string Name { get; }
        public double Length { get; }
        public double Width { get; }
        public double Height { get; }
        public string Material { get; }
        public string BaseConstraint { get; }
        public double BaseOffset { get; }
        public string TopConstraint { get; }
        public double UnconnectedHeight { get; }
        public string BaseLevel {  get; }
        public string TopLevel {  get; }
        public string ColumnStyle { get; }
        public double TopOffset { get; }
        public double StartLevelOffset { get; }
        public double EndLevelOffset { get; }
        public double CrossSectionRotation { get; }
        public string Level { get; }
        public double HeightOffset { get; }

 

        public ElementData(string typeName, ElementId id, string name, double length, double width, double height, string material, string baseConstraint, double baseOffset, string topConstraint, double unconnectedHeight, string baseLevel, string topLevel, string columnStyle, double topOffset, double startLevelOffset, double endLevelOffset, double crossSectionRotation, string level, double heightOffset)
        {
            TypeName = typeName;
            ElementId = id;
            Name = name;
            Length = length;
            Width = width;
            Height = height;
            Material = material;
            BaseConstraint = baseConstraint;
            BaseOffset = baseOffset;
            TopConstraint = topConstraint;
            UnconnectedHeight = unconnectedHeight;
            BaseLevel = baseLevel;
            TopLevel = topLevel;
            ColumnStyle = columnStyle;
            TopOffset = topOffset;
            StartLevelOffset = startLevelOffset;
            EndLevelOffset = endLevelOffset;
            CrossSectionRotation = crossSectionRotation;
            Level = level;
            HeightOffset = heightOffset;
        }
    }
}

