using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CryptocurrencyPlatform.WPF.Views {
    public partial class AssetView : UserControl {
        private double _currentOffset = 0;
        private const double Step = 350;
        private bool isAnimating = false;

        public AssetView() {
            InitializeComponent();
        }

        private void AnimateScroll(double toValue) {
            if (isAnimating || Math.Abs(_currentOffset - toValue) < 0.1 || toValue > 0) return;

            double contentWidth = CardsScrollViewer.ExtentWidth;
            double viewportWidth = CardsScrollViewer.ViewportWidth;

            if (toValue < viewportWidth - contentWidth)
                toValue = viewportWidth - contentWidth;

            isAnimating = true;

            var animation = new DoubleAnimation {
                From = _currentOffset,
                To = toValue,
                Duration = TimeSpan.FromMilliseconds(300),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            animation.Completed += (s, e) => isAnimating = false;

            CardsTransform.BeginAnimation(System.Windows.Media.TranslateTransform.XProperty, animation);
            _currentOffset = toValue;
        }

        private void ScrollLeft_Click(object sender, RoutedEventArgs e) =>
            AnimateScroll(_currentOffset + Step);   
        private void ScrollRight_Click(object sender, RoutedEventArgs e) =>
            AnimateScroll(_currentOffset - Step);
    }
}
