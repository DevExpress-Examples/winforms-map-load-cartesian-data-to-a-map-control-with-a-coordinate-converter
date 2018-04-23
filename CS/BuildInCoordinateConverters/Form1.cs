using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraMap;

namespace BuildInCoordinateConverters {
    public partial class Form1 : Form {
        ShapefileDataAdapter adapter = new ShapefileDataAdapter();
        List<MapData> mapData = new List<MapData> {
            #region #Albers
            new MapData() {
                Filepath = "../../Shapefiles/Albers/switzerland.shp", 
                CoordinateSystem = new CartesianSourceCoordinateSystem() {
                    CoordinateConverter = new AlbersEqualAreaConticCartesianToGeoConverter() {
                        StandardParallelN = 60, StandardParallelS = 20,
                        Ellipsoid = Ellipsoid.GRS80, ProjectionCenter = new GeoPoint(40, -96)
                    }
                }
            },
            #endregion #Albers
            
            #region #Lambert
            new MapData() {
                Filepath = "../../Shapefiles/Lambert/Belize.shp", 
                CoordinateSystem = new CartesianSourceCoordinateSystem() {
                    CoordinateConverter = new LambertConformalConicCartesianToGeoConverter() {
                        StandardParallelN = 60, StandardParallelS = 20,
                        Ellipsoid = Ellipsoid.GRS80, ProjectionCenter = new GeoPoint(40, -96)
                    }
                }
            },
            #endregion #Lambert
            
            #region #TransverseMercator
            new MapData() {
                Filepath = "../../Shapefiles/TransverseMercator/israel.shp", 
                CoordinateSystem = new CartesianSourceCoordinateSystem() {
                    CoordinateConverter = new TransverseMercatorCartesianToGeoConverter() {
                        Ellipsoid = Ellipsoid.WGS84, ProjectionCenter = new GeoPoint(0, 33),
                        ScaleFactor = 0.9996, FalseNorthing = 0, FalseEasting = 500000
                    }
                }
            },
            #endregion #TransverseMercator
            
            #region #UTM
            new MapData() {
                Filepath = "../../Shapefiles/TransverseMercator/israel.shp", 
                CoordinateSystem = new CartesianSourceCoordinateSystem() {
                    CoordinateConverter = new UTMCartesianToGeoConverter() {
                        UtmZone = 36, Hemisphere = Hemisphere.Northern
                    }
                }
            },
            #endregion #UTM
            
            #region #MercatorAuxiliary
            new MapData() {
                Filepath = "../../Shapefiles/MercatorAux/montenegro.shp", 
                CoordinateSystem = new CartesianSourceCoordinateSystem() {
                    CoordinateConverter = new MercatorAuxiliarySphereCartesianToGeoConverter() {
                        SphereType = 0, ProjectionCenter = new GeoPoint(0,0)
                    }
                }
            },
            #endregion #MercatorAuxiliary
            
        };

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            cbData.DataSource = mapData;

            VectorItemsLayer layer = new VectorItemsLayer() {Data = adapter};
            layer.ItemStyle.Fill = Color.FromArgb(40, 255, 128, 0);
            layer.DataLoaded +=layer_DataLoaded;
            mapControl1.Layers.Add(layer);
        }

        void layer_DataLoaded(object sender, DataLoadedEventArgs e) {
            mapControl1.ZoomToFitLayerItems(0.4);
        }

        private void cbData_SelectedIndexChanged(object sender, EventArgs e) {
            MapData data = cbData.SelectedValue as MapData;
            if (data == null) return;

            Uri baseUri = new Uri(System.Reflection.Assembly.GetEntryAssembly().Location);
            Uri fileUri = new Uri(baseUri, data.Filepath);
            adapter.FileUri = fileUri;
            adapter.SourceCoordinateSystem = data.CoordinateSystem;
        }
    }

    class MapData {
        public string Filepath { get; set; }
        public SourceCoordinateSystem CoordinateSystem { get; set; }

        public override string ToString() {
            return String.Format("{0}; with {1}", Filepath, CoordinateSystem.CoordinateConverter);
        }
    }
}
