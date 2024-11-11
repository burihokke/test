using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;
using System.IO;
using System.Reactive.Disposables;
using System.Windows.Media.Imaging;
using WpfApp5.Core;
using WpfApp5.Properties;

namespace WpfApp5.ViewModels
{
	class BaseServiceModel : ObservableObject, IDisposable
	{
		#region フィールドプロパティ
		/// <summary>
		/// 機能名
		/// </summary>
		public ReactivePropertySlim<string> ServiceName { get; }

		/// <summary>
		/// ステータス画像
		/// </summary>
        public ReactivePropertySlim<BitmapImage> StatusImage { get; set; }

		/// <summary>
		/// 結果
		/// </summary>
        public ReactivePropertySlim<string> Result { get; set; }
		#endregion

		#region 列挙体
		/// <summary>
		/// ステータス軍
		/// </summary>
		public enum Statuses
        {
            None,
            Processing,
			Pause,
            Success,
            Error
        }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="serviceName">機能名</param>
		public BaseServiceModel(string serviceName)
        {
            this.ServiceName = new ReactivePropertySlim<string>(serviceName);
            this.StatusImage = new ReactivePropertySlim<BitmapImage>(ChangeStatus(Statuses.None));
            this.Result = new ReactivePropertySlim<string>("");
        }
		#endregion

		#region publicメソッド
		/// <summary>
		/// ステータス変更
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <returns>ステータス画像</returns>
		public BitmapImage ChangeStatus(Statuses status)
		{
			Uri imageUri = GetStatusImageUri(status);
            BitmapImage bitmap = ImageService.ConvertUriToBitmapImage(imageUri);
			return bitmap;
		}
		#endregion

		#region privateメソッド
		/// <summary>
		/// ステータス画像データを取得
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <returns>画像データURI</returns>
		private Uri GetStatusImageUri(Statuses status)
		{
			string fileName;
			switch (status)
			{
				case Statuses.Processing:
					fileName = "loading.gif";
					break;
				case Statuses.Pause:
					fileName = "StatusPaused.png";
					break;
				case Statuses.Success:
					fileName = "StatusOK.png";
					break;
				case Statuses.Error:
					fileName = "StatusError.png";
					break;
				default:
					fileName = "StatusExcludedOutline.png";
					break;
			}

			return new Uri($"pack://application:,,,/Resources/{fileName}", UriKind.Absolute);
		}
		#endregion

		private readonly CompositeDisposable disposable = new CompositeDisposable();
		public void Dispose() => disposable.Dispose();
	}
}
