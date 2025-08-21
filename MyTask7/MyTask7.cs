using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;
using System.Windows.Controls;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace MyTask7
{
    [Transaction(TransactionMode.Manual)]
    public partial class MyTask7 : System.Windows.Forms.Form
    {
        private Document _doc;
        private List<ElementData> _elementDataList;
        private ElementData _selectedelementData;
        private string _selectedUnit = "Feet";
       

        public MyTask7(List<ElementData> elementDataList, Document doc)
        {
            InitializeComponent();
            _doc = doc;
            _elementDataList = elementDataList;
           

            PopulateElementTypeComboBox();
            PopulateUnitComboBox();
          

           
            this.FormClosing += new FormClosingEventHandler(MyTask7_FormClosing);
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
                EnableStructuralFramingConstraints(false);
                EnableFloorConstraints(false);

                if (selectedType == "Walls")
                {
                    EnableWallConstraints(true);
                 
                }
                else if (selectedType == "Structural Columns")
                {
                    EnableColumnConstraints(true);
                    
                }
                else if (selectedType == "Structural Framing") 
                {
                    EnableStructuralFramingConstraints(true);
                
                }
                else if (selectedType == "Floors") 
                {
                    EnableFloorConstraints(true);
                   
                }

            }
        }

        private void EnableWallConstraints(bool enable)
        {
            BaseConstraintComboBox.Enabled = enable;
            TopConstraintComboBox.Enabled = enable;
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

            }
        }

        private void EnableColumnConstraints(bool enable)
        {
            BaseLevelComboBox.Enabled = enable;
            BaseOffsetTextBox.Enabled = enable;
            TopLevelComboBox.Enabled = enable;
            TopOffsetTextBox.Enabled = enable;
            ColumnStyleComboBox.Enabled = enable;

            if (enable)
            {
                PopulateColumnConstraints();
            }
            else
            {
                BaseLevelComboBox.Items.Clear();
                TopLevelComboBox.Items.Clear();
                ColumnStyleComboBox.Items.Clear();
            }
        }

        private void EnableStructuralFramingConstraints(bool enable)
        {
            StartLevelOffsetTextBox.Enabled = enable;
            EndLevelOffsetTextBox.Enabled = enable;
            CrossSectionRotationTextBox.Enabled = enable;

            if (enable) PopulateStructuralFramingConstraints();

            
           
        }

        private void EnableFloorConstraints(bool enable)
        {
            LevelComboBox.Enabled = enable;
            HeightOffsetTextBox.Enabled = enable;
            

            if (enable)
            {
                PopulateFloorConstraints();
            }
            else
            {
                LevelComboBox.Items.Clear();
                
            }
        }

        private void PopulateWallConstraints()
        {
            BaseConstraintComboBox.Items.Clear();
            TopConstraintComboBox.Items.Clear();

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
            BaseLevelComboBox.Items.Clear();
            TopLevelComboBox.Items.Clear();
            ColumnStyleComboBox.Items.Clear();

            BaseLevelComboBox.Items.Add("Level 1");
            BaseLevelComboBox.Items.Add("Level 2");
            BaseLevelComboBox.SelectedIndex = 0;

            TopLevelComboBox.Items.Add("Level 1");
            TopLevelComboBox.Items.Add("Level 2");
            TopLevelComboBox.SelectedIndex = 0;

            ColumnStyleComboBox.Items.Add("Vertical");
            ColumnStyleComboBox.Items.Add("Slanted-Angle Driven");
            ColumnStyleComboBox.Items.Add("Slanted-End Point Driven");
            ColumnStyleComboBox.SelectedIndex = 0;
        }

        private void PopulateStructuralFramingConstraints()
        {
            StartLevelOffsetTextBox.Text = "0.0";
            EndLevelOffsetTextBox.Text = "0.0";
            CrossSectionRotationTextBox.Text = "0.0";
        }

        private void PopulateFloorConstraints()
        {
            LevelComboBox.Items.Clear();
            LevelComboBox.Items.Add("Level 1");
            LevelComboBox.Items.Add("Level 2");

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

            if (_selectedelementData!= null)
            {
                ElementNameComboBox.Items.Clear();
                ElementNameComboBox.Items.Add(_selectedelementData.Name);
                ElementNameComboBox.SelectedIndex = 0;
                
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
            Element element=_doc.GetElement(elementData.ElementId);

            BaseConstraintComboBox.SelectedItem= elementData.BaseConstraint;
            TopConstraintComboBox.SelectedItem = elementData.TopConstraint;
            BaseOffsetTextBox.Text = element.LookupParameter("Base Offset")?.AsDouble().ToString() ?? "0";
            UnconnectedHeightTextBox.Text = element.LookupParameter("Unconnected Height")?.AsDouble().ToString() ?? "0";
            BaseLevelComboBox.SelectedItem = elementData.BaseLevel;
            TopLevelComboBox.SelectedItem = elementData.TopLevel;
            ColumnStyleComboBox.SelectedItem = elementData.ColumnStyle;
            TopOffsetTextBox.Text = element.LookupParameter("Top Offset")?.AsDouble().ToString() ?? "0";
            StartLevelOffsetTextBox.Text = element.LookupParameter("Start Level Offset")?.AsDouble().ToString() ?? "0";
            EndLevelOffsetTextBox.Text = element.LookupParameter("End Level Offset")?.AsDouble().ToString() ?? "0";
            CrossSectionRotationTextBox.Text = element.LookupParameter("Cross Section Rotation")?.AsDouble().ToString() ?? "0";
            LevelComboBox.SelectedItem = elementData.Level;
            HeightOffsetTextBox.Text = element.LookupParameter("Height Offset")?.AsDouble().ToString() ?? "0";
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
           // uiDoc.ShowElements(elementId); // Zoom into the selected element
        }


        // Event handler for Apply button
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

                        if (StartLevelOffsetTextBox.Enabled)
                        {
                            Parameter startLevelOffsetParam = element.LookupParameter("Start Level Offset");
                            double levelValue = double.Parse(StartLevelOffsetTextBox.Text);
                            startLevelOffsetParam.Set(UnitUtils.ConvertToInternalUnits(levelValue, UnitTypeId.Feet));
                        }

                        if (EndLevelOffsetTextBox.Enabled)
                        {
                            Parameter endLevelOffsetParam = element.LookupParameter("End Level Offset");
                            double endsetValue = double.Parse(EndLevelOffsetTextBox.Text);
                            endLevelOffsetParam.Set(UnitUtils.ConvertToInternalUnits(endsetValue, UnitTypeId.Feet));
                        }

                        if (CrossSectionRotationTextBox.Enabled)
                        {
                            Parameter crossSectionRotationParam = element.LookupParameter("Cross-Section Rotation");
                            double crossValue = double.Parse(CrossSectionRotationTextBox.Text);
                            crossSectionRotationParam.Set(UnitUtils.ConvertToInternalUnits(crossValue, UnitTypeId.Feet));
                        }

                        if (HeightOffsetTextBox.Enabled)
                        {
                            Parameter heightOffsetParam = element.LookupParameter("Height Offset From Level");
                            double setValue = double.Parse(HeightOffsetTextBox.Text);
                            heightOffsetParam.Set(UnitUtils.ConvertToInternalUnits(setValue, UnitTypeId.Feet));
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

        private void MyTask7_FormClosing(object sender, FormClosingEventArgs e)
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

        

        private void ElementTypeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void TopLevelLabel_Click(object sender, EventArgs e)
        {

        }

        private void MyTask7_Load(object sender, EventArgs e)
        {

        }
    }
}