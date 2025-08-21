using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace MyTask7
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
                // Open the main form
                using (MyTask7 mainForm = new MyTask7(elementDataList, doc))
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

                string baseConstraint = element.LookupParameter("Base Constraint")?.AsValueString() ?? "None";
                double baseOffset = element.LookupParameter("Base Offset")?.AsDouble() ?? 0;
                string topConstraint = element.LookupParameter("Top Constraint")?.AsValueString() ?? "None";
                double unconnectedHeight = element.LookupParameter("Unconnected Height")?.AsDouble() ?? 0;
                string baseLevel = element.LookupParameter("Base Level")?.AsValueString() ?? "None";
                string topLevel = element.LookupParameter("Top Level")?.AsValueString() ?? "None";
                string columnStyle = element.LookupParameter("Column Style")?.AsValueString() ?? "None";
                double topOffset = element.LookupParameter("Top Offset")?.AsDouble() ?? 0;
                double startLevelOffset = element.LookupParameter("Start Level Offset")?.AsDouble() ?? 0;
                double endLevelOffset = element.LookupParameter("End Level Offset")?.AsDouble() ?? 0;
                double crossSectionRotation = element.LookupParameter("Cross Section Rotation")?.AsDouble() ?? 0;
                string level = element.LookupParameter("Level")?.AsValueString() ?? "None";
                double heightOffset = element.LookupParameter("Height Offset")?.AsDouble() ?? 0;

                elementDataList.Add(new ElementData(typeName, id, name, length, width, height, material, baseConstraint, baseOffset, topConstraint, unconnectedHeight, baseLevel, topLevel, columnStyle, topOffset,
                                                             startLevelOffset, endLevelOffset, crossSectionRotation, level, heightOffset));
            }
            return elementDataList;
        }
    }

    
}


