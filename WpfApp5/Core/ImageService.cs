using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp5.Core
{
    class ImageService
	{
		/// <summary>
		/// イメージのバイトからビットマップに変換
		/// </summary>
		/// <param name="imageData">画像データ</param>
		/// <returns>ビットマップイメージ</returns>
		public static BitmapImage ConvertByteToBitmapImage(byte[] imageData)
		{
			using (var stream = new MemoryStream(imageData))
			{
				var bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = stream;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();

				return bitmapImage;
			}
		}
	}
}
