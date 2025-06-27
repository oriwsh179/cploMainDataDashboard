//using LiveChartsCore;
//using LiveChartsCore.SkiaSharpView;
//using LiveChartsCore.SkiaSharpView.Painting;
//using MainDataDashboard.Helpers;
//using MainDataDashboard.Models;
//using SkiaSharp;
//using System.Collections.ObjectModel;
//using System.Data;
//using System.Linq;
//using System.Windows.Media;

//namespace MainDataDashboard.ViewModels
//{
//    public class InformationSectionViewModel : SectionViewModel
//    {
//        // تهيئة المجموعات مباشرة (simplified)
//        public ObservableCollection<StatusItem> CarStatuses { get; } = new();
//        public ObservableCollection<DeptOfficeItem> DeptOfficeData { get; } = new();
//        public ISeries[] PieSeries { get; private set; } = new ISeries[0];

//        public InformationSectionViewModel()
//        {
//            Title = "المعلوماتية";
//            MoreCommand = new RelayCommand(_ => OpenDetails());
//            LoadAllData();
//        }

//        private void LoadAllData()
//        {
//            LoadCarData();
//            LoadDeptOfficeData();
//            BuildPieChart();
//        }

//        private void LoadCarData()
//        {
//            var dt = DbHelper.ExecuteQuery("SELECT CODE, COUNT(*) C FROM CAR_A GROUP BY CODE");
//            var palette = new[] { Brushes.Green, Brushes.Red, Brushes.Orange, Brushes.Blue };

//            CarStatuses.Clear();
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                var row = dt.Rows[i];
//                CarStatuses.Add(new StatusItem
//                {
//                    StatusName = row["CODE"].ToString(),
//                    Count = (int)row["C"],
//                    Color = palette[i % palette.Length]
//                });
//            }
//        }

//        private void LoadDeptOfficeData()
//        {
//            var dt = DbHelper.ExecuteQuery(@"
//SELECT c2 Office, c3 Dept, COUNT(*) C
//FROM CAR_A 
//GROUP BY c2, c3");

//            DeptOfficeData.Clear();
//            foreach (DataRow r in dt.Rows)
//            {
//                DeptOfficeData.Add(new DeptOfficeItem
//                {
//                    Office = r["Office"].ToString(),
//                    Dept = r["Dept"].ToString(),
//                    Count = (int)r["C"]
//                });
//            }
//        }

//        private void BuildPieChart()
//        {
//            PieSeries = CarStatuses
//                .Select(s =>
//                {
//                    // لتحويل لون WPF إلى SkiaSharp
//                    var scb = (SolidColorBrush)s.Color;
//                    var skColor = new SKColor(scb.Color.R, scb.Color.G, scb.Color.B);

//                    return (ISeries)new PieSeries<int>
//                    {
//                        Values = new[] { s.Count },
//                        Name = s.StatusName,
//                        Fill = new SolidColorPaint(skColor),
//                        DataLabelsPaint = new SolidColorPaint(SKColors.White),
//                        DataLabelsSize = 14
//                        // لم يعد هناك DataLabelsPosition أو PolarLabelPosition
//                    };
//                })
//                .ToArray();

//            OnPropertyChanged(nameof(PieSeries));
//        }

//        private void OpenDetails()
//        {
//            var win = new Views.InformationDetailsWindow
//            {
//                DataContext = this
//            };
//            win.ShowDialog();
//        }
//    }
//}
