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
            byte[] imageData = GetStautsImageData(status);
            BitmapImage bitmap = ImageService.ConvertByteToBitmapImage(imageData);
			return bitmap;
		}
		#endregion

		#region privateメソッド
		/// <summary>
		/// ステータス画像データを取得
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <returns>画像データ</returns>
		private byte[] GetStautsImageData(Statuses status)
		{
			byte[] imageData;
			switch (status)
			{
				case Statuses.Processing:
					imageData = Resources.loading;
					break;
				case Statuses.Success:
					imageData = Resources.StatusOK;
					break;
				case Statuses.Error:
					imageData = Resources.StatusError;
					break;
				default:
					imageData = Resources.StatusPaused;
					break;
			}

            return imageData;
		}
		#endregion

		private readonly CompositeDisposable disposable = new CompositeDisposable();
		public void Dispose() => disposable.Dispose();
	}
}
