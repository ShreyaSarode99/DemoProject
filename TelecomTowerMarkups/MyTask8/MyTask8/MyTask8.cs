using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace MyTask8
{
    [Transaction(TransactionMode.Manual)]
    public partial class MyTask8 : System.Windows.Forms.Form
    {

        private Autodesk.Revit.DB.Document _doc;
        private List<ElementData> _elementDataList;
        private ElementData _selectedelementData;
        private string _selectedUnit = "Feet";

        public MyTask8(List<ElementData> elementDataList, Autodesk.Revit.DB.Document doc)
        {
            InitializeComponent();
            _doc = doc;
            _elementDataList = elementDataList;


            PopulateElementTypeComboBox();
            PopulateUnitComboBox();



            this.FormClosing += new FormClosingEventHandler(MyTask8_FormClosing);
        }

        private void PopulateElementTypeComboBox()
        {
            var types = _elementDataList.Select(e => e.TypeName).Distinct().ToList();
            ElementTypeComboBox.Items.AddRange(types.ToArray());

            var autoCompleteSource = new AutoCompleteStringCollection();
            autoCompleteSource.AddRange(types.ToArray());
            ElementTypeComboBox.AutoCompleteCustomSource = autoCompleteSource;

            ElementTypeComboBox.SelectedIndexChanged += ElementTypeComboBox_SelectedIndexChanged;
        }

        private void ElementTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = ElementTypeComboBox.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedType))
            {
                var filteredElements = _elementDataList.Where(element => element.TypeName == selectedType).ToList();
                PopulateElementIdComboBox(filteredElements);

                EnableWallConstraints(false);
                EnableColumnConstraints(false);
                EnableFloorConstraints(false);
                EnableRoofConstraints(false);
                EnableDoorConstraints(false);
                EnablePlumbingFixtures(false);
                EnablePipeFittings(false);
                EnablePipeAccessories(false);
                EnableMechanicalEquipment(false);
                EnableElectricalEquipment(false);
                EnableStructuralFoundation(false);
                EnableSpecialtyEquipment(false);
                EnableLightingDevices(false);
                EnableCaseWork(false);
                EnablePipes(false);
                EnableTelephoneDevices(false);


                if (selectedType == "Walls")
                {
                    EnableWallConstraints(true);

                }
                else if (selectedType == "Structural Columns")
                {
                    EnableColumnConstraints(true);

                }
                else if (selectedType == "Floors")
                {
                    EnableFloorConstraints(true);

                }
                else if (selectedType == "Roofs")
                {
                    EnableRoofConstraints(true);
                }
                else if (selectedType == "Doors")
                {
                    EnableDoorConstraints(true);
                }
                else if (selectedType == "Plumbing Fixtures")
                {
                    EnablePlumbingFixtures(true);
                }
                else if (selectedType == "Pipe Fittings")
                {
                    EnablePipeFittings(true);
                }
                else if (selectedType == "Pipe Accessories")
                {
                    EnablePipeAccessories(true);
                }
                else if (selectedType == "Mechanical Equiment")
                {
                    EnableMechanicalEquipment(true);
                }
                else if (selectedType == "Electrical Equipment")
                {
                    EnableElectricalEquipment(true);
                }
                else if (selectedType == "Structural Foundation")
                {
                    EnableStructuralFoundation(true);
                }
                else if (selectedType == "Specialty Equipment")
                {
                    EnableSpecialtyEquipment(true);
                }
                else if (selectedType == "Lighting Devices")
                {
                    EnableLightingDevices(true);
                }
                else if (selectedType == "CaseWork")
                {
                    EnableCaseWork(true);
                }
                else if (selectedType == "Pipes")
                {
                    EnablePipes(true);
                }
                else if (selectedType == "Telephone Devices")
                {
                    EnableTelephoneDevices(true);
                }

            }
        }


        private void EnableWallConstraints(bool enable)
        {
            LocationLineComboBox.Enabled = enable;
            BaseConstraintComboBox.Enabled = enable;
            TopConstraintComboBox.Enabled = enable;
            TopOffsetTextBox.Enabled = enable;
            UnconnectedHeightTextBox.Enabled = enable;
            BaseOffsetTextBox.Enabled = enable;



            if (enable)
            {
                PopulateWallConstraints();

            }
            else
            {
                BaseConstraintComboBox.Items.Clear();
                TopConstraintComboBox.Items.Clear();
                LocationLineComboBox.Items.Clear();
            }
        }

        private void EnableColumnConstraints(bool enable)
        {
            BaseLevelTextBox.Enabled = enable;
            //BaseOffsetTextBox.Enabled = enable;
            TopLevelTextBox.Enabled = enable;
            //TopOffsetTextBox.Enabled = enable;
            ColumnStyleTextBox.Enabled = enable;

            if (enable) PopulateColumnConstraints();


        }

        private void EnableFloorConstraints(bool enable)
        {
            LevelTextBox.Enabled = enable;
            //HeightOffsetTextBox.Enabled = enable;


            if (enable) PopulateFloorConstraints();
        }

        private void EnableRoofConstraints(bool enable)
        {
            BaseLevelTextBox.Enabled = enable;
            BaseOffsetFromLevelTextBox.Enabled = enable;
            CutoffLevelComboBox.Enabled = enable;
            CutoffOffsetTextBox.Enabled = enable;

            if (enable)
            {
                PopulateRoofConstraints();
            }
            else
            {
                CutoffLevelComboBox.Items.Clear();
            }
        }

        private void EnableDoorConstraints(bool enable)
        {
            LevelTextBox.Enabled = enable;
            SillHeightTextBox.Enabled = enable;

            if (enable) PopulateDoorConstraints();
        }

        private void EnablePlumbingFixtures(bool enable)
        {
            LevelTextBox.Enabled = enable;
            ScheduleLevelTextBox.Enabled = enable;
            ElevationFromLevelTextBox.Enabled = enable;
            OffsetFromHostTextBox.Enabled = enable;
            HostTextBox.Enabled = enable;

            if (enable) PopulatePlumbingFixtures();
        }

        private void EnablePipeFittings(bool enable)
        {
            LevelTextBox.Enabled = (enable);
            ElevationFromLevelTextBox.Enabled = (enable);

            if (enable) PopulatePipeFittings();
        }

        private void EnablePipeAccessories(bool enable)
        {
            LevelTextBox.Enabled = (enable);
            ElevationFromLevelTextBox.Enabled = (enable);

            if (enable) PopulatePipeAccessories();
        }

        private void EnableMechanicalEquipment(bool enable)
        {
            LevelTextBox.Enabled = (enable);
            ElevationFromLevelTextBox.Enabled = (enable);
            OffsetFromHostTextBox.Enabled = (enable);

            if (enable) PopulateMechanicalEquipment();
        }

        private void EnableElectricalEquipment(bool enable)
        {
            LevelTextBox.Enabled = (enable);
            ElevationFromLevelTextBox.Enabled = (enable);
            OffsetFromHostTextBox.Enabled = (enable);

            if (enable) PopulateElectricalEquipment();
        }

        private void EnableStructuralFoundation(bool enable)
        {
            LevelTextBox.Enabled = (enable);
            HeightOffsetFromLevelTextBox.Enabled = (enable);

            if (enable) PopulateStructuralFoundation();
        }

        private void EnableSpecialtyEquipment(bool enable)
        {
            ElevationFromLevelTextBox.Enabled = (enable);

            if (enable) PopulateSpecialtyEquipment();
        }

        private void EnableLightingDevices(bool enable)
        {
            LevelTextBox.Enabled = (enable);
            ElevationFromLevelTextBox.Enabled = (enable);
            OffsetFromHostTextBox.Enabled = (enable);

            if (enable) PopulateLightingDevices();
        }

        private void EnableCaseWork(bool enable)
        {
            LevelTextBox.Enabled = (enable);
            ElevationFromLevelTextBox.Enabled = (enable);
            OffsetFromHostTextBox.Enabled = (enable);

            if (enable) PopulateCaseWork();
        }

        private void EnablePipes(bool enable)
        {
            HorizontalJustificationComboBox.Enabled = (enable);
            VerticalJustificationComboBox.Enabled = (enable);
            ReferenceLevelTextBox.Enabled = (enable);
            UpperEndTopElevationTextBox.Enabled = (enable);
            MiddleElevationTextBox.Enabled = (enable);
            LowerEndBottomElevationTextBox.Enabled = (enable);
            UpperEndCenterlineElevationTextBox.Enabled = (enable);
            LowerEndCenterlineElevationTextBox.Enabled = (enable);
            LowerEndInvertElevationTextBox.Enabled = (enable);
            SlopeTextBox.Enabled = (enable);

            if (enable)
            {
                PopulatePipes();
            }
            else
            {
                HorizontalJustificationComboBox.Items.Clear();
                VerticalJustificationComboBox.Items.Clear();
            }
        }

        private void EnableTelephoneDevices(bool enable)
        {
            ElevationFromLevelTextBox.Enabled = (enable);

            if (enable) PopulateTelephoneDevices();
        }


        private void PopulateWallConstraints()
        {
            LocationLineComboBox.Items.Clear();
            BaseConstraintComboBox.Items.Clear();
            TopConstraintComboBox.Items.Clear();

            LocationLineComboBox.Items.Add("Wall Centerline");
            LocationLineComboBox.Items.Add("Core Centerline");
            LocationLineComboBox.Items.Add("Finish Face: Exterior");
            LocationLineComboBox.Items.Add("Finish Face: Interior");
            LocationLineComboBox.Items.Add("Core Face: Exterior");
            LocationLineComboBox.Items.Add("Core Face: Interior");
            LocationLineComboBox.SelectedIndex = 0;

            BaseConstraintComboBox.Items.Add("Level 1");
            BaseConstraintComboBox.Items.Add("Level 2");
            BaseConstraintComboBox.SelectedIndex = 0;

            TopConstraintComboBox.Items.Add("Unconnected");
            TopConstraintComboBox.Items.Add("Up to Level: Level 1");
            TopConstraintComboBox.Items.Add("Up to Level: Level 2");
            TopConstraintComboBox.SelectedIndex = 0;



        }

        private void PopulateColumnConstraints()
        {

            BaseLevelTextBox.Text = "Level 1";
            TopLevelTextBox.Text = "0.0";
            ColumnStyleTextBox.Text = "0.0";

        }

        private void PopulateFloorConstraints()
        {


            LevelTextBox.Text = "Level 1";

        }

        private void PopulateRoofConstraints()
        {
            CutoffLevelComboBox.Items.Clear();
            CutoffLevelComboBox.Items.Add("None");
            CutoffLevelComboBox.Items.Add("Level 1");
            CutoffLevelComboBox.SelectedIndex = 0;
        }

        private void PopulateDoorConstraints()
        {
            LevelTextBox.Text = "Level 1";
            SillHeightTextBox.Text = "0.0";
        }

        private void PopulatePlumbingFixtures()
        {
            LevelTextBox.Text = "Level 1";
            ScheduleLevelTextBox.Text = "0.0";
            ElevationFromLevelTextBox.Text = "0.0";
            OffsetFromHostTextBox.Text = "0.0";
            HostTextBox.Text = "0.0";

        }

        private void PopulatePipeFittings()
        {
            LevelTextBox.Text = "Level 1";
            ElevationFromLevelTextBox.Text = "0.0";

        }

        private void PopulatePipeAccessories()
        {
            LevelTextBox.Text = "Level 1";
            ElevationFromLevelTextBox.Text = "0.0";

        }

        private void PopulateMechanicalEquipment()
        {
            LevelTextBox.Text = "Level 1";
            ElevationFromLevelTextBox.Text = "0.0";
            OffsetFromHostTextBox.Text = "0.0";

        }

        private void PopulateElectricalEquipment()
        {
            LevelTextBox.Text = "Level 1";
            ElevationFromLevelTextBox.Text = "0.0";
            OffsetFromHostTextBox.Text = "0.0";
        }

        private void PopulateStructuralFoundation()
        {
            LevelTextBox.Text = "Level 1";
            HeightOffsetFromLevelTextBox.Text = "0.0";
        }

        private void PopulateSpecialtyEquipment()
        {

            ElevationFromLevelTextBox.Text = "0.0";

        }
        private void PopulateLightingDevices()
        {
            LevelTextBox.Text = "Level 1";
            ElevationFromLevelTextBox.Text = "0.0";
            OffsetFromHostTextBox.Text = "0.0";
        }

        private void PopulateCaseWork()
        {
            LevelTextBox.Text = "Level 1";
            ElevationFromLevelTextBox.Text = "0.0";
            OffsetFromHostTextBox.Text = "0.0";
        }

        private void PopulatePipes()
        {
            HorizontalJustificationComboBox.Items.Clear();
            HorizontalJustificationComboBox.Items.Add("Left");
            HorizontalJustificationComboBox.Items.Add("Center");
            HorizontalJustificationComboBox.Items.Add("Right");
            HorizontalJustificationComboBox.SelectedIndex = 0;

            VerticalJustificationComboBox.Items.Clear();
            VerticalJustificationComboBox.Items.Add("Top");
            VerticalJustificationComboBox.Items.Add("Middle");
            VerticalJustificationComboBox.Items.Add("Bottom");
            VerticalJustificationComboBox.SelectedIndex = 0;

        }

        private void PopulateTelephoneDevices()
        {
            ElevationFromLevelTextBox.Text = "0.0";
        }

        private void PopulateElementIdComboBox(List<ElementData> filteredElements)
        {
            ElementIdComboBox.Items.Clear();
            var elementIds = filteredElements.Select(e => e.ElementId.Value.ToString()).ToList();
            ElementIdComboBox.Items.AddRange(elementIds.ToArray());

            ElementIdComboBox.SelectedIndexChanged += ElementIdComboBox_SelectedIndexChanged;
        }

        private void ElementIdComboBox_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string selectedId = ElementIdComboBox.SelectedItem?.ToString();
            _selectedelementData = _elementDataList.FirstOrDefault(element => element.ElementId.Value.ToString() == selectedId);

            if (_selectedelementData != null)
            {
                ElementNameTextBox.Text = _selectedelementData.Name;

                LengthTextBox.Text = _selectedelementData.Length.ToString("F2");
                WidthTextBox.Text = _selectedelementData.Width.ToString("F2");
                HeightTextBox.Text = _selectedelementData.Height.ToString("F2");
                MaterialTextBox.Text = _selectedelementData.Material;



                if (_selectedelementData != null)
                {
                    PopulateFormField(_selectedelementData);
                    HighlightElement(_selectedelementData.ElementId);

                }
            }
        }

        private void PopulateFormField(ElementData elementData)
        {
            Element element = _doc.GetElement(elementData.ElementId);

            LocationLineComboBox.SelectedItem = elementData.LocationLine;
            BaseConstraintComboBox.SelectedItem = elementData.BaseConstraint;
            TopConstraintComboBox.SelectedItem = elementData.TopConstraint;
            BaseOffsetTextBox.Text = element.LookupParameter("Base Offset")?.AsDouble().ToString() ?? "0";
            UnconnectedHeightTextBox.Text = element.LookupParameter("Unconnected Height")?.AsDouble().ToString() ?? "0";
            TopOffsetTextBox.Text = element.LookupParameter("Top Offset")?.AsDouble().ToString() ?? "0";
            BaseLevelTextBox.Text = element.LookupParameter("Base Level")?.AsDouble().ToString() ?? "0";
            BaseOffsetFromLevelTextBox.Text = element.LookupParameter("Base Offset From Level")?.AsDouble().ToString() ?? "0";
            CutoffLevelComboBox.SelectedItem = elementData.CutoffLevel;
            CutoffOffsetTextBox.Text = element.LookupParameter("Cutoff Offset")?.AsDouble().ToString() ?? "0";
            LevelTextBox.Text = element.LookupParameter("Level")?.AsDouble().ToString() ?? "0";
            SillHeightTextBox.Text = element.LookupParameter("Sill Height")?.AsDouble().ToString() ?? "0";
            ElevationFromLevelTextBox.Text = element.LookupParameter("Elevation from Level")?.AsDouble().ToString() ?? "0";
            OffsetFromHostTextBox.Text = element.LookupParameter("Offset from Host")?.AsDouble().ToString() ?? "0";
            HeightOffsetFromLevelTextBox.Text = element.LookupParameter("Height Offset From Level")?.AsDouble().ToString() ?? "0";
            OriginLevelOffsetTextBox.Text = element.LookupParameter("Origin Level Offset")?.AsDouble().ToString() ?? "0";
            TopLevelTextBox.Text = element.LookupParameter("Top Level")?.AsDouble().ToString() ?? "0";
            ColumnStyleTextBox.Text = element.LookupParameter("Column Style")?.AsDouble().ToString() ?? "0";
            HostTextBox.Text = element.LookupParameter("Host")?.AsDouble().ToString() ?? "0";
            HorizontalJustificationComboBox.SelectedItem = elementData.HorizontalJustification;
            VerticalJustificationComboBox.SelectedItem = elementData.VerticalJustification;
            ReferenceLevelTextBox.Text = element.LookupParameter("Reference Level")?.AsDouble().ToString() ?? "0";
            ScheduleLevelTextBox.Text = element.LookupParameter("Schedule Level")?.AsDouble().ToString() ?? "0";
            UpperEndTopElevationTextBox.Text = element.LookupParameter("Upper End Top Elevation")?.AsDouble().ToString() ?? "0";
            MiddleElevationTextBox.Text = element.LookupParameter("Middle Elevation")?.AsDouble().ToString() ?? "0";
            LowerEndBottomElevationTextBox.Text = element.LookupParameter("Lower End Bottom Elevation")?.AsDouble().ToString() ?? "0";
            UpperEndCenterlineElevationTextBox.Text = element.LookupParameter("Upper End CenterLine Elevation")?.AsDouble().ToString() ?? "0";
            LowerEndCenterlineElevationTextBox.Text = element.LookupParameter("Lower End CenterLine Elevation")?.AsDouble().ToString() ?? "0";
            LowerEndInvertElevationTextBox.Text = element.LookupParameter("Lower End Invert Elevation")?.AsDouble().ToString() ?? "0";
            SlopeTextBox.Text = element.LookupParameter("Slope")?.AsDouble().ToString() ?? "0";

        }

        private void PopulateUnitComboBox()
        {
            UnitComboBox.Items.AddRange(new string[] { "Meters", "Feet", "Inches", "Millimeters", "Centimeters", "Yards", "Degrees", "Square Meters", "Kilograms", "Cubic Meters", "Seconds", "Kilometers per Hour" });
            UnitComboBox.SelectedIndex = 1; // Default to Meters
            UnitComboBox.SelectedIndexChanged += UnitComboBox_SelectedIndexChanged;
        }

        private void UnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedUnit = UnitComboBox.SelectedItem.ToString();

            string selectedId = ElementIdComboBox.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedId))
            {
                var selectedElement = _elementDataList.FirstOrDefault(element => element.ElementId.Value.ToString() == selectedId);
                if (selectedElement != null)
                {
                    PopulateDimensionBoxes(selectedElement.ElementId);
                }
            }
        }

        private void HighlightElement(ElementId elementId)
        {
            UIApplication uiApp = new UIApplication(_doc.Application);
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            uiDoc.Selection.SetElementIds(new List<ElementId> { elementId });
            uiDoc.ShowElements(elementId); // Zoom into the selected element
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string selectedId = ElementIdComboBox.SelectedItem?.ToString();


            if (string.IsNullOrEmpty(selectedId))
            {
                MessageTextBox.Text = "Error: Please select an element to update.";
                return;
            }

            var selectedElement = _elementDataList.FirstOrDefault(element => element.ElementId.Value.ToString() == selectedId);

            if (selectedElement != null)
            {
                try
                {

                    // Start transaction
                    using (Transaction trans = new Transaction(_doc, "Update Element"))
                    {
                        trans.Start();

                        Element element = _doc.GetElement(_selectedelementData.ElementId);

                        if (BaseOffsetTextBox.Enabled)

                        {
                            Parameter baseOffsetParam = element.LookupParameter("Base Offset");
                            double offsetValue = double.Parse(BaseOffsetTextBox.Text);
                            baseOffsetParam.Set(UnitUtils.ConvertToInternalUnits(offsetValue, UnitTypeId.Feet));
                        }



                        if (UnconnectedHeightTextBox.Enabled)

                        {
                            Parameter unconnectedHeightParam = element.LookupParameter("Unconnected Height");
                            double heightValue = double.Parse(UnconnectedHeightTextBox.Text);
                            unconnectedHeightParam.Set(UnitUtils.ConvertToInternalUnits(heightValue, UnitTypeId.Feet));
                        }

                        if (TopOffsetTextBox.Enabled)
                        {
                            Parameter topOffsetParam = element.LookupParameter("Top Offset");
                            double topoffsetValue = double.Parse(TopOffsetTextBox.Text);
                            topOffsetParam.Set(UnitUtils.ConvertToInternalUnits(topoffsetValue, UnitTypeId.Feet));
                        }

                        if (BaseLevelTextBox.Enabled)
                        {
                            Parameter baseLevelParam = element.LookupParameter("Base Level");
                            double levelValue = double.Parse(BaseLevelTextBox.Text);
                            baseLevelParam.Set(UnitUtils.ConvertToInternalUnits(levelValue, UnitTypeId.Feet));
                        }

                        if (BaseOffsetFromLevelTextBox.Enabled)
                        {
                            Parameter baseOffsetFromLevelParam = element.LookupParameter("Base Offset From Level");
                            double baseValue = double.Parse(BaseOffsetFromLevelTextBox.Text);
                            baseOffsetFromLevelParam.Set(UnitUtils.ConvertToInternalUnits(baseValue, UnitTypeId.Feet));
                        }

                        if (CutoffOffsetTextBox.Enabled)
                        {
                            Parameter cutoffOffsetParam = element.LookupParameter("Cutoff Offset");
                            double cutValue = double.Parse(CutoffOffsetTextBox.Text);
                            cutoffOffsetParam.Set(UnitUtils.ConvertToInternalUnits(cutValue, UnitTypeId.Feet));
                        }

                        if (LevelTextBox.Enabled)
                        {
                            Parameter levelParam = element.LookupParameter("Level");
                            double lValue = double.Parse(LevelTextBox.Text);
                            levelParam.Set(UnitUtils.ConvertToInternalUnits(lValue, UnitTypeId.Feet));
                        }

                        if (SillHeightTextBox.Enabled)
                        {
                            Parameter sillHeightParam = element.LookupParameter("Sill Height");
                            double heightValue = double.Parse(SillHeightTextBox.Text);
                            sillHeightParam.Set(UnitUtils.ConvertToInternalUnits(heightValue, UnitTypeId.Feet));
                        }

                        if (ElevationFromLevelTextBox.Enabled)
                        {
                            Parameter elevationFromLevelParam = element.LookupParameter("Elevation from Level");
                            double elevationValue = double.Parse(ElevationFromLevelTextBox.Text);
                            elevationFromLevelParam.Set(UnitUtils.ConvertToInternalUnits(elevationValue, UnitTypeId.Feet));
                        }

                        if (OffsetFromHostTextBox.Enabled)
                        {
                            Parameter offsetFromHostParam = element.LookupParameter("Offset from Host");
                            double hostValue = double.Parse(OffsetFromHostTextBox.Text);
                            offsetFromHostParam.Set(UnitUtils.ConvertToInternalUnits(hostValue, UnitTypeId.Feet));
                        }

                        if (HeightOffsetFromLevelTextBox.Enabled)
                        {
                            Parameter heightOffsetFromLevelParam = element.LookupParameter("Height Offset From Level");
                            double hostValue = double.Parse(HeightOffsetFromLevelTextBox.Text);
                            heightOffsetFromLevelParam.Set(UnitUtils.ConvertToInternalUnits(hostValue, UnitTypeId.Feet));
                        }

                        if (OriginLevelOffsetTextBox.Enabled)
                        {
                            Parameter originLevelOffsetParam = element.LookupParameter("Origin Level Offset");
                            double originValue = double.Parse(OriginLevelOffsetTextBox.Text);
                            originLevelOffsetParam.Set(UnitUtils.ConvertToInternalUnits(originValue, UnitTypeId.Feet));
                        }

                        if (TopLevelTextBox.Enabled)
                        {
                            Parameter topLevelParam = element.LookupParameter("Top Level");
                            double topValue = double.Parse(TopLevelTextBox.Text);
                            topLevelParam.Set(UnitUtils.ConvertToInternalUnits(topValue, UnitTypeId.Feet));
                        }

                        if (ColumnStyleTextBox.Enabled)
                        {
                            Parameter columnStyleParam = element.LookupParameter("Column Style");
                            double styleValue = double.Parse(ColumnStyleTextBox.Text);
                            columnStyleParam.Set(UnitUtils.ConvertToInternalUnits(styleValue, UnitTypeId.Feet));
                        }

                        if (HostTextBox.Enabled)
                        {
                            Parameter hostParam = element.LookupParameter("Host");
                            double hValue = double.Parse(HostTextBox.Text);
                            hostParam.Set(UnitUtils.ConvertToInternalUnits(hValue, UnitTypeId.Feet));
                        }

                        if (ReferenceLevelTextBox.Enabled)
                        {
                            Parameter referenceLevelParam = element.LookupParameter("Reference Level");
                            double referenceValue = double.Parse(ReferenceLevelTextBox.Text);
                            referenceLevelParam.Set(UnitUtils.ConvertToInternalUnits(referenceValue, UnitTypeId.Feet));
                        }

                        if (ScheduleLevelTextBox.Enabled)
                        {
                            Parameter scheduleLevelParam = element.LookupParameter("Schedule Level");
                            double scheduleValue = double.Parse(ScheduleLevelTextBox.Text);
                            scheduleLevelParam.Set(UnitUtils.ConvertToInternalUnits(scheduleValue, UnitTypeId.Feet));
                        }


                        if (UpperEndTopElevationTextBox.Enabled)
                        {
                            Parameter upperEndTopElevationParam = element.LookupParameter("Upper End Top Elevation");
                            double upperValue = double.Parse(UpperEndTopElevationTextBox.Text);
                            upperEndTopElevationParam.Set(UnitUtils.ConvertToInternalUnits(upperValue, UnitTypeId.Feet));
                        }

                        if (MiddleElevationTextBox.Enabled)
                        {
                            Parameter middleElevationParam = element.LookupParameter("Middle Elevation");
                            double middleValue = double.Parse(MiddleElevationTextBox.Text);
                            middleElevationParam.Set(UnitUtils.ConvertToInternalUnits(middleValue, UnitTypeId.Feet));
                        }

                        if (LowerEndBottomElevationTextBox.Enabled)
                        {
                            Parameter lowerEndBottomElevationParam = element.LookupParameter("Lower End Bottom Elevation");
                            double lowerValue = double.Parse(LowerEndBottomElevationTextBox.Text);
                            lowerEndBottomElevationParam.Set(UnitUtils.ConvertToInternalUnits(lowerValue, UnitTypeId.Feet));
                        }

                        if (UpperEndCenterlineElevationTextBox.Enabled)
                        {
                            Parameter upperEndCenterlineElevationParam = element.LookupParameter("Upper End Centerline Elevation");
                            double endValue = double.Parse(UpperEndCenterlineElevationTextBox.Text);
                            upperEndCenterlineElevationParam.Set(UnitUtils.ConvertToInternalUnits(endValue, UnitTypeId.Feet));
                        }

                        if (LowerEndCenterlineElevationTextBox.Enabled)
                        {
                            Parameter lowerEndCenterlineElevationParam = element.LookupParameter("Lower End Centerline Elevation");
                            double eValue = double.Parse(LowerEndCenterlineElevationTextBox.Text);
                            lowerEndCenterlineElevationParam.Set(UnitUtils.ConvertToInternalUnits(eValue, UnitTypeId.Feet));
                        }

                        if (LowerEndInvertElevationTextBox.Enabled)
                        {
                            Parameter lowerEndInvertElevationParam = element.LookupParameter("Lower End Invert Elevation");
                            double invertValue = double.Parse(LowerEndInvertElevationTextBox.Text);
                            lowerEndInvertElevationParam.Set(UnitUtils.ConvertToInternalUnits(invertValue, UnitTypeId.Feet));
                        }

                        if (SlopeTextBox.Enabled)
                        {
                            Parameter slopeParam = element.LookupParameter("Slope");
                            double slopeValue = double.Parse(SlopeTextBox.Text);
                            slopeParam.Set(UnitUtils.ConvertToInternalUnits(slopeValue, UnitTypeId.Feet));
                        }

                        trans.Commit();
                        MessageTextBox.Text = "Success: Changes applied successfully!";
                    }
                }
                catch (Exception ex)
                {
                    MessageTextBox.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                MessageTextBox.Text = "Error: Selected element not found.";
            }
        }

        private void PopulateDimensionBoxes(ElementId elementId)
        {
            Element element = _doc.GetElement(elementId);
            if (element != null)
            {

                double length = GetParameterAsDouble(element, BuiltInParameter.CURVE_ELEM_LENGTH);
                double width = GetParameterAsDouble(element, BuiltInParameter.WALL_ATTR_WIDTH_PARAM);
                double height = GetParameterAsDouble(element, BuiltInParameter.WALL_USER_HEIGHT_PARAM);

                length = ConvertFromInternalUnits(length, _selectedUnit);
                width = ConvertFromInternalUnits(width, _selectedUnit);
                height = ConvertFromInternalUnits(height, _selectedUnit);

                // Populate text boxes
                LengthTextBox.Text = length.ToString("F2");
                WidthTextBox.Text = width.ToString("F2");
                HeightTextBox.Text = height.ToString("F2");
            }
        }

        private void MyTask8_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIApplication uiApp = new UIApplication(_doc.Application);
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            uiDoc.Selection.SetElementIds(new List<ElementId>());
        }

        private double GetParameterAsDouble(Element element, BuiltInParameter parameter)
        {
            Parameter param = element.get_Parameter(parameter);
            return param?.AsDouble() ?? 0;
        }

        private double ConvertFromInternalUnits(double value, string unit)
        {
            switch (unit)
            {
                case "Meters":
                    return UnitUtils.ConvertToInternalUnits(value, UnitTypeId.Meters);
                case "Feet":
                    return UnitUtils.ConvertToInternalUnits(value, UnitTypeId.Feet) * 0.3048;
                case "Inches":
                    return UnitUtils.ConvertToInternalUnits(value, UnitTypeId.Inches) * 0.0254;
                case "Millimeters":
                    return UnitUtils.ConvertToInternalUnits(value, UnitTypeId.Millimeters) / 1000;
                case "Centimeters":
                    return UnitUtils.ConvertToInternalUnits(value, UnitTypeId.Centimeters) * 100;
                case "Yards":
                    return UnitUtils.ConvertToInternalUnits(value, UnitTypeId.Meters) / 0.9144; ; // Convert yards to meters
                default:
                    throw new ArgumentException("Unsupported unit: " + unit);
            }
        }






        // Event handler for Cancel button
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MyTask8_Load(object sender, EventArgs e)
        {

        }
    }
}
