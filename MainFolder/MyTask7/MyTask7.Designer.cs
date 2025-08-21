using System.Windows.Forms;

namespace MyTask7
{
    partial class MyTask7 : System.Windows.Forms.Form
    {
       
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox ElementTypeComboBox;
        private System.Windows.Forms.ComboBox ElementIdComboBox;
        private System.Windows.Forms.ComboBox ElementNameComboBox;
        private System.Windows.Forms.ComboBox UnitComboBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox MaterialTextBox;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label ElementTypeLabel;
        private System.Windows.Forms.Label ElementIdLabel;
        private System.Windows.Forms.Label ElementNameLabel;
        private System.Windows.Forms.Label UnitLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label MaterialLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.GroupBox ConstraintGroupBox;
        private System.Windows.Forms.Label BaseConstraintLabel;
        private System.Windows.Forms.ComboBox BaseConstraintComboBox;
        private System.Windows.Forms.Label BaseOffsetLabel;
        private System.Windows.Forms.TextBox BaseOffsetTextBox;
        private System.Windows.Forms.Label TopConstraintLabel;
        private System.Windows.Forms.ComboBox TopConstraintComboBox;
        private System.Windows.Forms.Label UnconnectedHeightLabel;
        private System.Windows.Forms.TextBox UnconnectedHeightTextBox;
        private System.Windows.Forms.Label BaseLevelLabel;
        private System.Windows.Forms.ComboBox BaseLevelComboBox;
        private System.Windows.Forms.Label TopLevelLabel;
        private System.Windows.Forms.ComboBox TopLevelComboBox;
        private System.Windows.Forms.Label TopOffsetLabel;
        private System.Windows.Forms.TextBox TopOffsetTextBox;
        private System.Windows.Forms.Label ColumnStyleLabel;
        private System.Windows.Forms.ComboBox ColumnStyleComboBox;
        private System.Windows.Forms.Label StartLevelOffsetLabel;
        private System.Windows.Forms.TextBox StartLevelOffsetTextBox;
        private System.Windows.Forms.Label EndLevelOffsetLabel;
        private System.Windows.Forms.TextBox EndLevelOffsetTextBox;
        private System.Windows.Forms.Label CrossSectionRotationLabel;
        private System.Windows.Forms.TextBox CrossSectionRotationTextBox;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.ComboBox LevelComboBox;
        private System.Windows.Forms.Label HeightOffsetLabel;
        private System.Windows.Forms.TextBox HeightOffsetTextBox;

        private void InitializeComponent()
        {
            this.ElementTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ElementIdComboBox = new System.Windows.Forms.ComboBox();
            this.ElementNameComboBox = new System.Windows.Forms.ComboBox();
            this.UnitComboBox = new System.Windows.Forms.ComboBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.MaterialTextBox = new System.Windows.Forms.TextBox();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ElementTypeLabel = new System.Windows.Forms.Label();
            this.ElementIdLabel = new System.Windows.Forms.Label();
            this.ElementNameLabel = new System.Windows.Forms.Label();
            this.UnitLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.MaterialLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ConstraintGroupBox = new System.Windows.Forms.GroupBox();
            this.BaseConstraintLabel = new System.Windows.Forms.Label();
            this.BaseConstraintComboBox = new System.Windows.Forms.ComboBox();
            this.BaseOffsetLabel = new System.Windows.Forms.Label();
            this.BaseOffsetTextBox = new System.Windows.Forms.TextBox();
            this.TopConstraintLabel = new System.Windows.Forms.Label();
            this.TopConstraintComboBox = new System.Windows.Forms.ComboBox();
            this.UnconnectedHeightLabel = new System.Windows.Forms.Label();
            this.UnconnectedHeightTextBox = new System.Windows.Forms.TextBox();
            this.BaseLevelLabel = new System.Windows.Forms.Label();
            this.BaseLevelComboBox = new System.Windows.Forms.ComboBox();
            this.TopLevelLabel = new System.Windows.Forms.Label();
            this.TopLevelComboBox = new System.Windows.Forms.ComboBox();
            this.TopOffsetLabel = new System.Windows.Forms.Label();
            this.TopOffsetTextBox = new System.Windows.Forms.TextBox();
            this.ColumnStyleLabel = new System.Windows.Forms.Label();
            this.ColumnStyleComboBox = new System.Windows.Forms.ComboBox();
            this.StartLevelOffsetLabel = new System.Windows.Forms.Label();
            this.StartLevelOffsetTextBox = new System.Windows.Forms.TextBox();
            this.EndLevelOffsetLabel = new System.Windows.Forms.Label();
            this.CrossSectionRotationLabel = new System.Windows.Forms.Label();
            this.CrossSectionRotationTextBox = new System.Windows.Forms.TextBox();
            this.EndLevelOffsetTextBox = new System.Windows.Forms.TextBox();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.LevelComboBox = new System.Windows.Forms.ComboBox();
            this.HeightOffsetLabel = new System.Windows.Forms.Label();
            this.HeightOffsetTextBox = new System.Windows.Forms.TextBox();
            this.ConstraintGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElementTypeComboBox
            // 
            this.ElementTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ElementTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ElementTypeComboBox.FormattingEnabled = true;
            this.ElementTypeComboBox.Location = new System.Drawing.Point(160, 17);
            this.ElementTypeComboBox.Name = "ElementTypeComboBox";
            this.ElementTypeComboBox.Size = new System.Drawing.Size(160, 28);
            this.ElementTypeComboBox.TabIndex = 7;
            this.ElementTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ElementTypeComboBox_SelectedIndexChanged_1);
            // 
            // ElementIdComboBox
            // 
            this.ElementIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ElementIdComboBox.Location = new System.Drawing.Point(160, 54);
            this.ElementIdComboBox.Name = "ElementIdComboBox";
            this.ElementIdComboBox.Size = new System.Drawing.Size(160, 28);
            this.ElementIdComboBox.TabIndex = 8;
            // 
            // ElementNameComboBox
            // 
            this.ElementNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ElementNameComboBox.Location = new System.Drawing.Point(160, 90);
            this.ElementNameComboBox.Name = "ElementNameComboBox";
            this.ElementNameComboBox.Size = new System.Drawing.Size(160, 28);
            this.ElementNameComboBox.TabIndex = 9;
            // 
            // UnitComboBox
            // 
            this.UnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnitComboBox.Location = new System.Drawing.Point(160, 124);
            this.UnitComboBox.Name = "UnitComboBox";
            this.UnitComboBox.Size = new System.Drawing.Size(160, 28);
            this.UnitComboBox.TabIndex = 20;
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.ForeColor = System.Drawing.Color.Gray;
            this.LengthTextBox.Location = new System.Drawing.Point(160, 166);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(160, 26);
            this.LengthTextBox.TabIndex = 10;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.ForeColor = System.Drawing.Color.Gray;
            this.WidthTextBox.Location = new System.Drawing.Point(160, 200);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(160, 26);
            this.WidthTextBox.TabIndex = 11;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.ForeColor = System.Drawing.Color.Gray;
            this.HeightTextBox.Location = new System.Drawing.Point(160, 233);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(160, 26);
            this.HeightTextBox.TabIndex = 12;
            // 
            // MaterialTextBox
            // 
            this.MaterialTextBox.ForeColor = System.Drawing.Color.Gray;
            this.MaterialTextBox.Location = new System.Drawing.Point(160, 269);
            this.MaterialTextBox.Name = "MaterialTextBox";
            this.MaterialTextBox.Size = new System.Drawing.Size(160, 26);
            this.MaterialTextBox.TabIndex = 13;
            this.MaterialTextBox.Text = "Concrete";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.ForeColor = System.Drawing.Color.Red;
            this.MessageTextBox.Location = new System.Drawing.Point(12, 460);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ReadOnly = true;
            this.MessageTextBox.Size = new System.Drawing.Size(349, 40);
            this.MessageTextBox.TabIndex = 21;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(160, 583);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(149, 41);
            this.ApplyButton.TabIndex = 14;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(578, 583);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 41);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ElementTypeLabel
            // 
            this.ElementTypeLabel.Location = new System.Drawing.Point(15, 20);
            this.ElementTypeLabel.Name = "ElementTypeLabel";
            this.ElementTypeLabel.Size = new System.Drawing.Size(110, 20);
            this.ElementTypeLabel.TabIndex = 0;
            this.ElementTypeLabel.Text = "Element Type:";
            // 
            // ElementIdLabel
            // 
            this.ElementIdLabel.Location = new System.Drawing.Point(15, 54);
            this.ElementIdLabel.Name = "ElementIdLabel";
            this.ElementIdLabel.Size = new System.Drawing.Size(100, 20);
            this.ElementIdLabel.TabIndex = 1;
            this.ElementIdLabel.Text = "Element ID:";
            // 
            // ElementNameLabel
            // 
            this.ElementNameLabel.Location = new System.Drawing.Point(15, 90);
            this.ElementNameLabel.Name = "ElementNameLabel";
            this.ElementNameLabel.Size = new System.Drawing.Size(123, 20);
            this.ElementNameLabel.TabIndex = 2;
            this.ElementNameLabel.Text = "Element Name:";
            // 
            // UnitLabel
            // 
            this.UnitLabel.AutoSize = true;
            this.UnitLabel.Location = new System.Drawing.Point(15, 127);
            this.UnitLabel.Name = "UnitLabel";
            this.UnitLabel.Size = new System.Drawing.Size(42, 20);
            this.UnitLabel.TabIndex = 19;
            this.UnitLabel.Text = "Unit:";
            // 
            // LengthLabel
            // 
            this.LengthLabel.Location = new System.Drawing.Point(12, 166);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(100, 20);
            this.LengthLabel.TabIndex = 3;
            this.LengthLabel.Text = "Length:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.Location = new System.Drawing.Point(12, 203);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(100, 20);
            this.WidthLabel.TabIndex = 4;
            this.WidthLabel.Text = "Width:";
            // 
            // HeightLabel
            // 
            this.HeightLabel.Location = new System.Drawing.Point(12, 233);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(100, 20);
            this.HeightLabel.TabIndex = 5;
            this.HeightLabel.Text = "Height:";
            // 
            // MaterialLabel
            // 
            this.MaterialLabel.Location = new System.Drawing.Point(12, 269);
            this.MaterialLabel.Name = "MaterialLabel";
            this.MaterialLabel.Size = new System.Drawing.Size(100, 20);
            this.MaterialLabel.TabIndex = 6;
            this.MaterialLabel.Text = "Material:";
            // 
            // MessageLabel
            // 
            this.MessageLabel.Location = new System.Drawing.Point(15, 429);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(100, 20);
            this.MessageLabel.TabIndex = 6;
            this.MessageLabel.Text = "Message:";
            // 
            // ConstraintGroupBox
            // 
            this.ConstraintGroupBox.Controls.Add(this.BaseConstraintLabel);
            this.ConstraintGroupBox.Controls.Add(this.BaseConstraintComboBox);
            this.ConstraintGroupBox.Controls.Add(this.BaseOffsetLabel);
            this.ConstraintGroupBox.Controls.Add(this.BaseOffsetTextBox);
            this.ConstraintGroupBox.Controls.Add(this.TopConstraintLabel);
            this.ConstraintGroupBox.Controls.Add(this.TopConstraintComboBox);
            this.ConstraintGroupBox.Controls.Add(this.UnconnectedHeightLabel);
            this.ConstraintGroupBox.Controls.Add(this.UnconnectedHeightTextBox);
            this.ConstraintGroupBox.Controls.Add(this.BaseLevelLabel);
            this.ConstraintGroupBox.Controls.Add(this.BaseLevelComboBox);
            this.ConstraintGroupBox.Controls.Add(this.TopLevelLabel);
            this.ConstraintGroupBox.Controls.Add(this.TopLevelComboBox);
            this.ConstraintGroupBox.Controls.Add(this.TopOffsetLabel);
            this.ConstraintGroupBox.Controls.Add(this.TopOffsetTextBox);
            this.ConstraintGroupBox.Controls.Add(this.ColumnStyleLabel);
            this.ConstraintGroupBox.Controls.Add(this.ColumnStyleComboBox);
            this.ConstraintGroupBox.Controls.Add(this.StartLevelOffsetLabel);
            this.ConstraintGroupBox.Controls.Add(this.StartLevelOffsetTextBox);
            this.ConstraintGroupBox.Controls.Add(this.EndLevelOffsetLabel);
            this.ConstraintGroupBox.Controls.Add(this.CrossSectionRotationLabel);
            this.ConstraintGroupBox.Controls.Add(this.CrossSectionRotationTextBox);
            this.ConstraintGroupBox.Controls.Add(this.EndLevelOffsetTextBox);
            this.ConstraintGroupBox.Controls.Add(this.LevelLabel);
            this.ConstraintGroupBox.Controls.Add(this.LevelComboBox);
            this.ConstraintGroupBox.Controls.Add(this.HeightOffsetLabel);
            this.ConstraintGroupBox.Controls.Add(this.HeightOffsetTextBox);
            this.ConstraintGroupBox.Location = new System.Drawing.Point(367, -1);
            this.ConstraintGroupBox.Name = "ConstraintGroupBox";
            this.ConstraintGroupBox.Size = new System.Drawing.Size(400, 578);
            this.ConstraintGroupBox.TabIndex = 1;
            this.ConstraintGroupBox.TabStop = false;
            this.ConstraintGroupBox.Text = "Constraint Parameters";
            // 
            // BaseConstraintLabel
            // 
            this.BaseConstraintLabel.Location = new System.Drawing.Point(21, 34);
            this.BaseConstraintLabel.Name = "BaseConstraintLabel";
            this.BaseConstraintLabel.Size = new System.Drawing.Size(135, 23);
            this.BaseConstraintLabel.TabIndex = 0;
            this.BaseConstraintLabel.Text = "Base Constraint";
            // 
            // BaseConstraintComboBox
            // 
            this.BaseConstraintComboBox.Location = new System.Drawing.Point(211, 31);
            this.BaseConstraintComboBox.Name = "BaseConstraintComboBox";
            this.BaseConstraintComboBox.Size = new System.Drawing.Size(179, 28);
            this.BaseConstraintComboBox.TabIndex = 1;
            // 
            // BaseOffsetLabel
            // 
            this.BaseOffsetLabel.Location = new System.Drawing.Point(25, 73);
            this.BaseOffsetLabel.Name = "BaseOffsetLabel";
            this.BaseOffsetLabel.Size = new System.Drawing.Size(120, 23);
            this.BaseOffsetLabel.TabIndex = 2;
            this.BaseOffsetLabel.Text = "Base Offset";
            // 
            // BaseOffsetTextBox
            // 
            this.BaseOffsetTextBox.Location = new System.Drawing.Point(211, 73);
            this.BaseOffsetTextBox.Name = "BaseOffsetTextBox";
            this.BaseOffsetTextBox.Size = new System.Drawing.Size(179, 26);
            this.BaseOffsetTextBox.TabIndex = 3;
            // 
            // TopConstraintLabel
            // 
            this.TopConstraintLabel.Location = new System.Drawing.Point(21, 110);
            this.TopConstraintLabel.Name = "TopConstraintLabel";
            this.TopConstraintLabel.Size = new System.Drawing.Size(124, 23);
            this.TopConstraintLabel.TabIndex = 4;
            this.TopConstraintLabel.Text = "Top Constraint";
            // 
            // TopConstraintComboBox
            // 
            this.TopConstraintComboBox.Location = new System.Drawing.Point(211, 119);
            this.TopConstraintComboBox.Name = "TopConstraintComboBox";
            this.TopConstraintComboBox.Size = new System.Drawing.Size(179, 28);
            this.TopConstraintComboBox.TabIndex = 5;
            // 
            // UnconnectedHeightLabel
            // 
            this.UnconnectedHeightLabel.Location = new System.Drawing.Point(21, 152);
            this.UnconnectedHeightLabel.Name = "UnconnectedHeightLabel";
            this.UnconnectedHeightLabel.Size = new System.Drawing.Size(166, 23);
            this.UnconnectedHeightLabel.TabIndex = 6;
            this.UnconnectedHeightLabel.Text = "Unconnected Height";
            // 
            // UnconnectedHeightTextBox
            // 
            this.UnconnectedHeightTextBox.Location = new System.Drawing.Point(211, 163);
            this.UnconnectedHeightTextBox.Name = "UnconnectedHeightTextBox";
            this.UnconnectedHeightTextBox.Size = new System.Drawing.Size(179, 26);
            this.UnconnectedHeightTextBox.TabIndex = 7;
            // 
            // BaseLevelLabel
            // 
            this.BaseLevelLabel.Location = new System.Drawing.Point(21, 198);
            this.BaseLevelLabel.Name = "BaseLevelLabel";
            this.BaseLevelLabel.Size = new System.Drawing.Size(135, 23);
            this.BaseLevelLabel.TabIndex = 0;
            this.BaseLevelLabel.Text = "Base Level";
            // 
            // BaseLevelComboBox
            // 
            this.BaseLevelComboBox.Location = new System.Drawing.Point(211, 195);
            this.BaseLevelComboBox.Name = "BaseLevelComboBox";
            this.BaseLevelComboBox.Size = new System.Drawing.Size(179, 28);
            this.BaseLevelComboBox.TabIndex = 0;
            // 
            // TopLevelLabel
            // 
            this.TopLevelLabel.Location = new System.Drawing.Point(21, 246);
            this.TopLevelLabel.Name = "TopLevelLabel";
            this.TopLevelLabel.Size = new System.Drawing.Size(124, 23);
            this.TopLevelLabel.TabIndex = 4;
            this.TopLevelLabel.Text = "Top Level";
            this.TopLevelLabel.Click += new System.EventHandler(this.TopLevelLabel_Click);
            // 
            // TopLevelComboBox
            // 
            this.TopLevelComboBox.FormattingEnabled = true;
            this.TopLevelComboBox.Location = new System.Drawing.Point(211, 243);
            this.TopLevelComboBox.Name = "TopLevelComboBox";
            this.TopLevelComboBox.Size = new System.Drawing.Size(179, 28);
            this.TopLevelComboBox.TabIndex = 2;
            // 
            // TopOffsetLabel
            // 
            this.TopOffsetLabel.Location = new System.Drawing.Point(21, 291);
            this.TopOffsetLabel.Name = "TopOffsetLabel";
            this.TopOffsetLabel.Size = new System.Drawing.Size(120, 23);
            this.TopOffsetLabel.TabIndex = 2;
            this.TopOffsetLabel.Text = "Top Offset";
            // 
            // TopOffsetTextBox
            // 
            this.TopOffsetTextBox.Location = new System.Drawing.Point(211, 288);
            this.TopOffsetTextBox.Name = "TopOffsetTextBox";
            this.TopOffsetTextBox.Size = new System.Drawing.Size(179, 26);
            this.TopOffsetTextBox.TabIndex = 3;
            // 
            // ColumnStyleLabel
            // 
            this.ColumnStyleLabel.Location = new System.Drawing.Point(21, 340);
            this.ColumnStyleLabel.Name = "ColumnStyleLabel";
            this.ColumnStyleLabel.Size = new System.Drawing.Size(120, 23);
            this.ColumnStyleLabel.TabIndex = 2;
            this.ColumnStyleLabel.Text = "Column Style";
            // 
            // ColumnStyleComboBox
            // 
            this.ColumnStyleComboBox.Location = new System.Drawing.Point(211, 335);
            this.ColumnStyleComboBox.Name = "ColumnStyleComboBox";
            this.ColumnStyleComboBox.Size = new System.Drawing.Size(179, 28);
            this.ColumnStyleComboBox.TabIndex = 4;
            // 
            // StartLevelOffsetLabel
            // 
            this.StartLevelOffsetLabel.Location = new System.Drawing.Point(21, 379);
            this.StartLevelOffsetLabel.Name = "StartLevelOffsetLabel";
            this.StartLevelOffsetLabel.Size = new System.Drawing.Size(141, 23);
            this.StartLevelOffsetLabel.TabIndex = 2;
            this.StartLevelOffsetLabel.Text = "Start Level Offset";
            // 
            // StartLevelOffsetTextBox
            // 
            this.StartLevelOffsetTextBox.Location = new System.Drawing.Point(211, 379);
            this.StartLevelOffsetTextBox.Name = "StartLevelOffsetTextBox";
            this.StartLevelOffsetTextBox.Size = new System.Drawing.Size(179, 26);
            this.StartLevelOffsetTextBox.TabIndex = 3;
            // 
            // EndLevelOffsetLabel
            // 
            this.EndLevelOffsetLabel.Location = new System.Drawing.Point(21, 427);
            this.EndLevelOffsetLabel.Name = "EndLevelOffsetLabel";
            this.EndLevelOffsetLabel.Size = new System.Drawing.Size(141, 23);
            this.EndLevelOffsetLabel.TabIndex = 2;
            this.EndLevelOffsetLabel.Text = "End Level Offset";
            // 
            // CrossSectionRotationLabel
            // 
            this.CrossSectionRotationLabel.Location = new System.Drawing.Point(21, 466);
            this.CrossSectionRotationLabel.Name = "CrossSectionRotationLabel";
            this.CrossSectionRotationLabel.Size = new System.Drawing.Size(180, 23);
            this.CrossSectionRotationLabel.TabIndex = 2;
            this.CrossSectionRotationLabel.Text = "Cross Section Rotation";
            // 
            // CrossSectionRotationTextBox
            // 
            this.CrossSectionRotationTextBox.Location = new System.Drawing.Point(211, 463);
            this.CrossSectionRotationTextBox.Name = "CrossSectionRotationTextBox";
            this.CrossSectionRotationTextBox.Size = new System.Drawing.Size(179, 26);
            this.CrossSectionRotationTextBox.TabIndex = 3;
            // 
            // EndLevelOffsetTextBox
            // 
            this.EndLevelOffsetTextBox.Location = new System.Drawing.Point(211, 427);
            this.EndLevelOffsetTextBox.Name = "EndLevelOffsetTextBox";
            this.EndLevelOffsetTextBox.Size = new System.Drawing.Size(179, 26);
            this.EndLevelOffsetTextBox.TabIndex = 3;
            // 
            // LevelLabel
            // 
            this.LevelLabel.Location = new System.Drawing.Point(25, 507);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(120, 23);
            this.LevelLabel.TabIndex = 2;
            this.LevelLabel.Text = "Level";
            // 
            // LevelComboBox
            // 
            this.LevelComboBox.Location = new System.Drawing.Point(211, 502);
            this.LevelComboBox.Name = "LevelComboBox";
            this.LevelComboBox.Size = new System.Drawing.Size(179, 28);
            this.LevelComboBox.TabIndex = 1;
            // 
            // HeightOffsetLabel
            // 
            this.HeightOffsetLabel.Location = new System.Drawing.Point(25, 547);
            this.HeightOffsetLabel.Name = "HeightOffsetLabel";
            this.HeightOffsetLabel.Size = new System.Drawing.Size(120, 23);
            this.HeightOffsetLabel.TabIndex = 2;
            this.HeightOffsetLabel.Text = "Height Offset";
            // 
            // HeightOffsetTextBox
            // 
            this.HeightOffsetTextBox.Location = new System.Drawing.Point(211, 544);
            this.HeightOffsetTextBox.Name = "HeightOffsetTextBox";
            this.HeightOffsetTextBox.Size = new System.Drawing.Size(179, 26);
            this.HeightOffsetTextBox.TabIndex = 3;
            // 
            // MyTask7
            // 
            this.ClientSize = new System.Drawing.Size(786, 647);
            this.Controls.Add(this.ConstraintGroupBox);
            this.Controls.Add(this.ElementTypeLabel);
            this.Controls.Add(this.ElementIdLabel);
            this.Controls.Add(this.ElementNameLabel);
            this.Controls.Add(this.UnitLabel);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.MaterialLabel);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.ElementTypeComboBox);
            this.Controls.Add(this.ElementIdComboBox);
            this.Controls.Add(this.ElementNameComboBox);
            this.Controls.Add(this.UnitComboBox);
            this.Controls.Add(this.LengthTextBox);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.MaterialTextBox);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.btnCancel);
            this.Name = "MyTask7";
            this.Text = "Modify Revit Element";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyTask7_FormClosing);
            this.Load += new System.EventHandler(this.MyTask7_Load);
            this.ConstraintGroupBox.ResumeLayout(false);
            this.ConstraintGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
} 