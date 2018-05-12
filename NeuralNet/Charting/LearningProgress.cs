using System.Windows.Forms;

namespace Charting
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;
    using LiveCharts;
    using LiveCharts.Wpf;

    public partial class LearningProgress : Form
    {
        public LearningProgress()
        {
            InitializeComponent();
            liveChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double>(),
                    PointGeometry = DefaultGeometries.None
                }
            };

            Separator BackgroundGrid() => new Separator
            {
                Stroke = Brushes.LightGray,
                StrokeThickness = 0.5
            };

            liveChart.AxisY.Add(new Axis { Separator = BackgroundGrid() });
            liveChart.AxisX.Add(new Axis { Separator = BackgroundGrid() });
        }

        public void SetChartSeries(IReadOnlyCollection<double> points)
        {
            const int idealPointCount = 1000;
            var takeEveryNth = points.Count < idealPointCount ? 1 : points.Count / idealPointCount;
            var sparsePoints = points.Where((p, idx) => idx % takeEveryNth == 0);
            liveChart.Series.First().Values.AddRange(sparsePoints.Cast<object>());
        }
    }
}
