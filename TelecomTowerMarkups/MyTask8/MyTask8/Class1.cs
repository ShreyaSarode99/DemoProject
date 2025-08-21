using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace MyTask8
{
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                // Get the current Revit document
                Document doc = commandData.Application.ActiveUIDocument.Document;
                // Retrieve element data
                List<ElementData> elementDataList = GetElementData(doc);
                using (MyTask8 mainForm = new MyTask8(elementDataList, doc))
                {
                    mainForm.ShowDialog();
                }
                return Result.Succeeded;
            }
            catch (System.Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }


        private List<ElementData> GetElementData(Document doc)
        {
            List<ElementData> elementDataList = new List<ElementData>();
            // Collect all elements in the model
            FilteredElementCollector collector = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType();
            foreach (Element element in collector)
            {
                string typeName = element.Category?.Name ?? "Unknown";
                string name = element.Name;
                ElementId id = element.Id;
                // Example: Retrieve parameters like length, width, height, material
                double length = element.LookupParameter("Length")?.AsDouble() ?? 0;
                double width = element.LookupParameter("Width")?.AsDouble() ?? 0;
                double height = element.LookupParameter("Height")?.AsDouble() ?? 0;
                string material = element.LookupParameter("Material")?.AsValueString() ?? "Unknown";
                string locationLine = element.LookupParameter("Material")?.AsValueString() ?? "None";
                string baseConstraint = element.LookupParameter("Base Constraint")?.AsValueString() ?? "None";
                double baseOffset = element.LookupParameter("Base Offset")?.AsDouble() ?? 0;
                string topConstraint = element.LookupParameter("Top Constraint")?.AsValueString() ?? "None";
                double unconnectedHeight = element.LookupParameter("Unconnected Height")?.AsDouble() ?? 0;
                double topOffset = element.LookupParameter("Top Offset")?.AsDouble() ?? 0;
                string baseLevel = element.LookupParameter("Base Level")?.AsValueString() ?? "None";
                double baseOffsetFromLevel = element.LookupParameter("Base Offset From Level")?.AsDouble() ?? 0;
                string cutoffLevel = element.LookupParameter("Cutoff Level")?.AsValueString() ?? "None";
                double cutoffOffset = element.LookupParameter("Cutoff Offset")?.AsDouble() ?? 0;
                string level = element.LookupParameter("Level")?.AsValueString() ?? "None";
                double sillHeight = element.LookupParameter("Sill Height")?.AsDouble() ?? 0;
                double elevationFromLevel = element.LookupParameter("Elevation from Level")?.AsDouble() ?? 0;
                double offsetFromHost = element.LookupParameter("Offset from Host")?.AsDouble() ?? 0;
                double heightOffsetFromLevel = element.LookupParameter("Height Offset From Level")?.AsDouble() ?? 0;
                double originLevelOffset = element.LookupParameter("Origin Level Offset")?.AsDouble() ?? 0;
                string topLevel = element.LookupParameter("Top Level")?.AsValueString() ?? "None";
                string columnStyle = element.LookupParameter("Column Style")?.AsValueString() ?? "None";
                string host = element.LookupParameter("Host")?.AsValueString() ?? "None";
                string horizontalJustification = element.LookupParameter("Horizontal Justification")?.AsValueString() ?? "None";
                string verticalJustification = element.LookupParameter("Vertical Justification")?.AsValueString() ?? "None";
                string referenceLevel = element.LookupParameter("Reference Level")?.AsValueString() ?? "None";
                string scheduleLevel = element.LookupParameter("Schedule Level")?.AsValueString() ?? "None";
                double upperEndTopElevation = element.LookupParameter("Upper End Top Elevation")?.AsDouble() ?? 0;
                double middleElevation = element.LookupParameter("Middle Elevation")?.AsDouble() ?? 0;
                double lowerEndBottomElevation = element.LookupParameter("Lower End Bottom Elevation")?.AsDouble() ?? 0;
                double upperEndCenterlineElevation = element.LookupParameter("Upper End Centerline Elevation")?.AsDouble() ?? 0;
                double lowerEndCenterlineElevation = element.LookupParameter("Lower End Centerline Elevation")?.AsDouble() ?? 0;
                double lowerEndInvertElevation = element.LookupParameter("Lower End Invert Elevation")?.AsDouble() ?? 0;
                double slope = element.LookupParameter("Slope")?.AsDouble() ?? 0;



                elementDataList.Add(new ElementData(typeName, id, name, length, width, height, material, locationLine, baseConstraint, baseOffset, topConstraint, unconnectedHeight,
                                             topOffset, baseLevel, baseOffsetFromLevel, cutoffLevel, cutoffOffset, level, sillHeight, elevationFromLevel, offsetFromHost, heightOffsetFromLevel,
                                             originLevelOffset, topLevel, columnStyle, host, horizontalJustification, verticalJustification, referenceLevel, scheduleLevel, upperEndTopElevation, middleElevation,
                                             lowerEndBottomElevation, upperEndCenterlineElevation, lowerEndCenterlineElevation, lowerEndInvertElevation, slope));
            }
            return elementDataList;
        }
    }
}

