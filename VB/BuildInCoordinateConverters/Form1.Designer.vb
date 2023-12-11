Namespace BuildInCoordinateConverters

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim imageTilesLayer1 As DevExpress.XtraMap.ImageTilesLayer = New DevExpress.XtraMap.ImageTilesLayer()
            Dim bingMapDataProvider1 As DevExpress.XtraMap.BingMapDataProvider = New DevExpress.XtraMap.BingMapDataProvider()
            Me.layoutControl1 = New DevExpress.XtraLayout.LayoutControl()
            Me.cbData = New System.Windows.Forms.ComboBox()
            Me.mapControl1 = New DevExpress.XtraMap.MapControl()
            Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.lciDataCombo = New DevExpress.XtraLayout.LayoutControlItem()
            CType((Me.layoutControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.layoutControl1.SuspendLayout()
            CType((Me.mapControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.layoutControlGroup1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.layoutControlItem1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.lciDataCombo), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' layoutControl1
            ' 
            Me.layoutControl1.Controls.Add(Me.cbData)
            Me.layoutControl1.Controls.Add(Me.mapControl1)
            Me.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.layoutControl1.Location = New System.Drawing.Point(0, 0)
            Me.layoutControl1.Name = "layoutControl1"
            Me.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
            Me.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25F)
            Me.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
            Me.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
            Me.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
            Me.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.layoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
            Me.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.layoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.layoutControl1.Root = Me.layoutControlGroup1
            Me.layoutControl1.Size = New System.Drawing.Size(784, 561)
            Me.layoutControl1.TabIndex = 0
            Me.layoutControl1.Text = "layoutControl1"
            ' 
            ' cbData
            ' 
            Me.cbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbData.FormattingEnabled = True
            Me.cbData.Location = New System.Drawing.Point(180, 2)
            Me.cbData.Name = "cbData"
            Me.cbData.Size = New System.Drawing.Size(602, 21)
            Me.cbData.TabIndex = 6
            AddHandler Me.cbData.SelectedIndexChanged, New System.EventHandler(AddressOf Me.cbData_SelectedIndexChanged)
            ' 
            ' mapControl1
            ' 
            bingMapDataProvider1.Kind = DevExpress.XtraMap.BingMapKind.Area
            imageTilesLayer1.DataProvider = bingMapDataProvider1
            Me.mapControl1.Layers.Add(imageTilesLayer1)
            Me.mapControl1.Location = New System.Drawing.Point(2, 27)
            Me.mapControl1.Name = "mapControl1"
            Me.mapControl1.Size = New System.Drawing.Size(780, 532)
            Me.mapControl1.TabIndex = 4
            ' 
            ' layoutControlGroup1
            ' 
            Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.layoutControlGroup1.GroupBordersVisible = False
            Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.lciDataCombo})
            Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlGroup1.Name = "layoutControlGroup1"
            Me.layoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
            Me.layoutControlGroup1.Size = New System.Drawing.Size(784, 561)
            Me.layoutControlGroup1.TextVisible = False
            ' 
            ' layoutControlItem1
            ' 
            Me.layoutControlItem1.Control = Me.mapControl1
            Me.layoutControlItem1.Location = New System.Drawing.Point(0, 25)
            Me.layoutControlItem1.Name = "layoutControlItem1"
            Me.layoutControlItem1.Size = New System.Drawing.Size(784, 536)
            Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
            Me.layoutControlItem1.TextVisible = False
            ' 
            ' lciDataCombo
            ' 
            Me.lciDataCombo.Control = Me.cbData
            Me.lciDataCombo.Location = New System.Drawing.Point(0, 0)
            Me.lciDataCombo.Name = "lciDataCombo"
            Me.lciDataCombo.Size = New System.Drawing.Size(784, 25)
            Me.lciDataCombo.Text = "Shapefile and Coordinate converter:"
            Me.lciDataCombo.TextLocation = DevExpress.Utils.Locations.[Default]
            Me.lciDataCombo.TextSize = New System.Drawing.Size(175, 13)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.layoutControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.layoutControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.layoutControl1.ResumeLayout(False)
            CType((Me.mapControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.layoutControlGroup1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.layoutControlItem1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.lciDataCombo), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private layoutControl1 As DevExpress.XtraLayout.LayoutControl

        Private mapControl1 As DevExpress.XtraMap.MapControl

        Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup

        Private layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem

        Private cbData As System.Windows.Forms.ComboBox

        Private lciDataCombo As DevExpress.XtraLayout.LayoutControlItem
    End Class
End Namespace
