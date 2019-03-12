namespace Charting
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Media;
    using LiveCharts;
    using LiveCharts.Configurations;
    using LiveCharts.Wpf;

    public sealed partial class SimpleChart : Form
    {
        public double MinValueAxisY
        {
            get => liveChart.AxisY[0].MinValue;
            set => liveChart.AxisY[0].MinValue = value;
        }

        public int PointCountAxisX { get; set; } = 1000;

        private readonly IChartValues _chartValues = new ChartValues<PointModel>();

        public SimpleChart()
        {
            InitializeComponent();

            liveChart.DisableAnimations = true;
            liveChart.Hoverable = false;
            liveChart.DataTooltip = null;

            var mapper = Mappers.Xy<PointModel>()
                .X(model => model.Id)
                .Y(model => model.Value);

            Charting.For<PointModel>(mapper);

            liveChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = _chartValues,
                    PointGeometry = DefaultGeometries.None,
                }
            };

            Separator BackgroundGrid() => new Separator
            {
                Stroke = Brushes.LightGray,
                StrokeThickness = 0.5
            };

            liveChart.AxisY.Add(new Axis { Separator = BackgroundGrid(), MinValue = 0 });
            liveChart.AxisX.Add(new Axis { Separator = BackgroundGrid() });
        }

        public void SetChartSeries(IReadOnlyCollection<double> points)
        {
            var takeEveryNth = points.Count < PointCountAxisX ? 1 : points.Count / PointCountAxisX;
            var sparsePoints = points.Where((p, idx) => idx % takeEveryNth == 0);
            var pointModels = sparsePoints.Select((v, idx) => new PointModel((idx + 1) * takeEveryNth, v)).ToList();
            _chartValues.Clear();
            _chartValues.AddRange(pointModels);
        }

        private int _seenPointsCount;
        private int _takeEveryNth = 1;
        public void AddChartPoint(double value)
        {
            _seenPointsCount++;
            if (_seenPointsCount % _takeEveryNth != 0) return;

            if (_chartValues.Count >= PointCountAxisX)
            {
                RescaleChart();
                return;
            }

            _chartValues.Add(new PointModel(_seenPointsCount, value));
        }

        private void RescaleChart()
        {
            var result = _chartValues.Cast<object>().Where((t, i) => i % 2 == 0).ToList();
            _chartValues.Clear();
            _chartValues.AddRange(result);
            _takeEveryNth *= 2;
        }

        private class PointModel
        {
            public readonly int Id;
            public readonly double Value;

            public PointModel(int id, double value)
            {
                Id = id;
                Value = value;
            }
        }
    }
}
