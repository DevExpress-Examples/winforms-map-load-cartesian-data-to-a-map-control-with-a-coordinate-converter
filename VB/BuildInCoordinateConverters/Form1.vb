Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraMap

Namespace BuildInCoordinateConverters

    Public Partial Class Form1
        Inherits Form

        Private adapter As ShapefileDataAdapter = New ShapefileDataAdapter()

'#Region "#Albers"
'#End Region  ' #Albers
'#Region "#Lambert"
'#End Region  ' #Lambert
'#Region "#TransverseMercator"
'#End Region  ' #TransverseMercator
'#Region "#UTM"
'#End Region  ' #UTM
'#Region "#MercatorAuxiliary"
'#End Region  ' #MercatorAuxiliary
        Private mapData As List(Of MapData) = New List(Of MapData) From {New MapData() With {.Filepath = "../../Shapefiles/Albers/switzerland.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With {.CoordinateConverter = New AlbersEqualAreaConticCartesianToGeoConverter() With {.StandardParallelN = 60, .StandardParallelS = 20, .Ellipsoid = Ellipsoid.GRS80, .ProjectionCenter = New GeoPoint(40, -96)}}}, New MapData() With {.Filepath = "../../Shapefiles/Lambert/Belize.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With {.CoordinateConverter = New LambertConformalConicCartesianToGeoConverter() With {.StandardParallelN = 60, .StandardParallelS = 20, .Ellipsoid = Ellipsoid.GRS80, .ProjectionCenter = New GeoPoint(40, -96)}}}, New MapData() With {.Filepath = "../../Shapefiles/TransverseMercator/israel.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With {.CoordinateConverter = New TransverseMercatorCartesianToGeoConverter() With {.Ellipsoid = Ellipsoid.WGS84, .ProjectionCenter = New GeoPoint(0, 33), .ScaleFactor = 0.9996, .FalseNorthing = 0, .FalseEasting = 500000}}}, New MapData() With {.Filepath = "../../Shapefiles/TransverseMercator/israel.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With {.CoordinateConverter = New UTMCartesianToGeoConverter() With {.UtmZone = 36, .Hemisphere = Hemisphere.Northern}}}, New MapData() With {.Filepath = "../../Shapefiles/MercatorAux/montenegro.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With {.CoordinateConverter = New MercatorAuxiliarySphereCartesianToGeoConverter() With {.SphereType = 0, .ProjectionCenter = New GeoPoint(0, 0)}}}}

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            cbData.DataSource = mapData
            Dim layer As VectorItemsLayer = New VectorItemsLayer() With {.Data = adapter}
            layer.ItemStyle.Fill = Color.FromArgb(40, 255, 128, 0)
            AddHandler layer.DataLoaded, AddressOf layer_DataLoaded
            mapControl1.Layers.Add(layer)
        End Sub

        Private Sub layer_DataLoaded(ByVal sender As Object, ByVal e As DataLoadedEventArgs)
            mapControl1.ZoomToFitLayerItems(0.4)
        End Sub

        Private Sub cbData_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim data As MapData = TryCast(cbData.SelectedValue, MapData)
            If data Is Nothing Then Return
            Dim baseUri As Uri = New Uri(Reflection.Assembly.GetEntryAssembly().Location)
            Dim fileUri As Uri = New Uri(baseUri, data.Filepath)
            adapter.FileUri = fileUri
            adapter.SourceCoordinateSystem = data.CoordinateSystem
        End Sub
    End Class

    Friend Class MapData

        Public Property Filepath As String

        Public Property CoordinateSystem As SourceCoordinateSystem

        Public Overrides Function ToString() As String
            Return String.Format("{0}; with {1}", Filepath, CoordinateSystem.CoordinateConverter)
        End Function
    End Class
End Namespace
