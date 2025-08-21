using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace MyTask8
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
        public string LocationLine { get; }
        public string BaseConstraint { get; }
        public double BaseOffset { get; }
        public string TopConstraint { get; }
        public double UnconnectedHeight { get; }
        public double TopOffset { get; }
        public string BaseLevel { get; }
        public double BaseOffsetFromLevel { get; }
        public string CutoffLevel { get; }
        public double CutoffOffset { get; }
        public string Level { get; }
        public double SillHeight { get; }
        public double ElevationFromLevel { get; }
        public double OffsetFromHost { get; }
        public double HeightOffsetFromLevel { get; }
        public double OriginLevelOffset { get; }
        public string TopLevel { get; }
        public string ColumnStyle { get; }
        public string Host { get; }
        public string HorizontalJustification { get; }
        public string VerticalJustification { get; }
        public string ReferenceLevel { get; }
        public string ScheduleLevel { get; }
        public double UpperEndTopElevation { get; }
        public double MiddleElevation { get; }
        public double LowerEndBottomElevation { get; }
        public double UpperEndCenterlineElevation { get; }
        public double LowerEndCenterlineElevation { get; }
        public double LowerEndInvertElevation { get; }
        public double Slope { get; }



        public ElementData(string typeName, ElementId id, string name, double length, double width, double height, string material, string locationLine, string baseConstraint, double baseOffset, string topConstraint, double unconnectedHeight,
                                             double topOffset, string baseLevel, double baseOffsetFromLevel, string cutoffLevel, double cutoffOffset, string level, double sillHeight, double elevationFromLevel, double offsetFromHost, double heightOffsetFromLevel,
                                             double originLevelOffset, string topLevel, string columnStyle, string host, string horizontalJustification, string verticalJustification, string referenceLevel, string scheduleLevel, double upperEndTopElevation, double middleElevation,
                                             double lowerEndBottomElevation, double upperEndCenterlineElevation, double lowerEndCenterlineElevation, double lowerEndInvertElevation, double slope)
        {
            TypeName = typeName;
            ElementId = id;
            Name = name;
            Length = length;
            Width = width;
            Height = height;
            Material = material;
            LocationLine = locationLine;
            BaseConstraint = baseConstraint;
            BaseOffset = baseOffset;
            TopConstraint = topConstraint;
            UnconnectedHeight = unconnectedHeight;
            TopOffset = topOffset;
            BaseLevel = baseLevel;
            BaseOffsetFromLevel = baseOffsetFromLevel;
            CutoffLevel = cutoffLevel;
            CutoffOffset = cutoffOffset;
            Level = level;
            SillHeight = sillHeight;
            ElevationFromLevel = elevationFromLevel;
            OffsetFromHost = offsetFromHost;
            HeightOffsetFromLevel = heightOffsetFromLevel;
            OriginLevelOffset = originLevelOffset;
            TopLevel = topLevel;
            ColumnStyle = columnStyle;
            Host = host;
            HorizontalJustification = horizontalJustification;
            VerticalJustification = verticalJustification;
            ReferenceLevel = referenceLevel;
            ScheduleLevel = scheduleLevel;
            UpperEndTopElevation = upperEndTopElevation;
            MiddleElevation = middleElevation;
            LowerEndBottomElevation = lowerEndBottomElevation;
            UpperEndCenterlineElevation = upperEndCenterlineElevation;
            LowerEndCenterlineElevation = lowerEndCenterlineElevation;
            LowerEndInvertElevation = lowerEndInvertElevation;
            Slope = slope;

        }
    }
}

