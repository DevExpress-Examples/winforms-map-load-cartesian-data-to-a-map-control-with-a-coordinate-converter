Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraMap

Namespace BuildInCoordinateConverters
    Partial Public Class Form1
        Inherits Form

        Private adapter As New ShapefileDataAdapter()
            #Region "#Albers"
            #End Region ' #Albers
            #Region "#Lambert"
            #End Region ' #Lambert
            #Region "#TransverseMercator"
            #End Region ' #TransverseMercator
            #Region "#UTM"
            #End Region ' #UTM
            #Region "#MercatorAuxiliary"
            #End Region ' #MercatorAuxiliary
        Private mapData As New List(Of MapData)() From { _
            New MapData() With { _
                .Filepath = "../../Shapefiles/Albers/switzerland.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With { _
                    .CoordinateConverter = New AlbersEqualAreaConticCartesianToGeoConverter() With {.StandardParallelN = 60, .StandardParallelS = 20, .Ellipsoid = Ellipsoid.GRS80, .ProjectionCenter = New GeoPoint(40, -96)} _
                } _
            }, _
            New MapData() With { _
                .Filepath = "../../Shapefiles/Lambert/Belize.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With { _
                    .CoordinateConverter = New LambertConformalConicCartesianToGeoConverter() With {.StandardParallelN = 60, .StandardParallelS = 20, .Ellipsoid = Ellipsoid.GRS80, .ProjectionCenter = New GeoPoint(40, -96)} _
                } _
            }, _
            New MapData() With { _
                .Filepath = "../../Shapefiles/TransverseMercator/israel.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With { _
                    .CoordinateConverter = New TransverseMercatorCartesianToGeoConverter() With {.Ellipsoid = Ellipsoid.WGS84, .ProjectionCenter = New GeoPoint(0, 33), .ScaleFactor = 0.9996, .FalseNorthing = 0, .FalseEasting = 500000} _
                } _
            }, _
            New MapData() With { _
                .Filepath = "../../Shapefiles/TransverseMercator/israel.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With { _
                    .CoordinateConverter = New UTMCartesianToGeoConverter() With {.UtmZone = 36, .Hemisphere = Hemisphere.Northern} _
                } _
            }, _
            New MapData() With { _
                .Filepath = "../../Shapefiles/MercatorAux/montenegro.shp", .CoordinateSystem = New CartesianSourceCoordinateSystem() With { _
                    .CoordinateConverter = New MercatorAuxiliarySphereCartesianToGeoConverter() With {.SphereType = 0, .ProjectionCenter = New GeoPoint(0,0)} _
                } _
            } _
        }

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            cbData.DataSource = mapData

            Dim layer As New VectorItemsLayer() With {.Data = adapter}
            layer.ItemStyle.Fill = Color.FromArgb(40, 255, 128, 0)
            AddHandler layer.DataLoaded, AddressOf layer_DataLoaded
            mapControl1.Layers.Add(layer)
        End Sub

        Private Sub layer_DataLoaded(ByVal sender As Object, ByVal e As DataLoadedEventArgs)
            mapControl1.ZoomToFitLayerItems(0.4)
        End Sub

        Private Sub cbData_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbData.SelectedIndexChanged
            Dim data As MapData = TryCast(cbData.SelectedValue, MapData)
            If data Is Nothing Then
                Return
            End If

            Dim baseUri As New Uri(System.Reflection.Assembly.GetEntryAssembly().Location)
            Dim fileUri As New Uri(baseUri, data.Filepath)
            adapter.FileUri = fileUri
            adapter.SourceCoordinateSystem = data.CoordinateSystem
        End Sub
    End Class

    Friend Class MapData
        Public Property Filepath() As String
        Public Property CoordinateSystem() As SourceCoordinateSystem

        Public Overrides Function ToString() As String
            Return String.Format("{0}; with {1}", Filepath, CoordinateSystem.CoordinateConverter)
        End Function
    End Class
End Namespace
