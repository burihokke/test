using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.ViewModels
{
	partial class NewViewModel : ObservableObject, IDisposable
	{
		#region フィールドプロパティ
		/// <summary>
		/// 機能：Excel作成
		/// </summary>
		public ExcelServiceModel ExcelService { get; }

		/// <summary>
		/// 機能：エラーをわざと起こす
		/// </summary>
		public ErrorServiceModel ErrorService { get; }

		/// <summary>
		/// 
		/// </summary>
		private readonly CompositeDisposable disposable = new CompositeDisposable();

		/// <summary>
		/// コマンド：テスト
		/// </summary>
		public IRelayCommand CommandTest { get; }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public NewViewModel()
		{
			ExcelService = new ExcelServiceModel("Excel作成");
			ErrorService = new ErrorServiceModel("エラーをわざと起こす風");

			CommandTest = new RelayCommand(OnCommandTest);
		}
		#endregion

		#region privateメソッド
		/// <summary>
		/// コマンド：テスト
		/// </summary>
		private void OnCommandTest()
		{
			ExcelService.Execute();
			ErrorService.Execute();
		}
		#endregion

		public void Dispose() => disposable.Dispose();
	}
}
