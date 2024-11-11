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
		/// イメージのURIからビットマップに変換
		/// </summary>
		/// <param name="uri">画像データURI</param>
		/// <returns>ビットマップイメージ</returns>
		public static BitmapImage ConvertUriToBitmapImage(Uri uri)
		{
			var bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.UriSource = uri;
			bitmapImage.EndInit();

			return bitmapImage;
		}
	}
}
