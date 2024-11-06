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
	public partial class MainViewModel : ObservableObject, IDisposable
	{
		// テキストプロパティ
		public ReactivePropertySlim<string> InputText { get; } = new ReactivePropertySlim<string>("");

		// 数値入力プロパティ
		public ReactivePropertySlim<double> Number1 { get; } = new ReactivePropertySlim<double>(0);
		public ReactivePropertySlim<double> Number2 { get; } = new ReactivePropertySlim<double>(0);

		// 合計プロパティ
		public ReadOnlyReactiveProperty<double> Sum { get; }

		// カウントプロパティ
		public ReactivePropertySlim<int> Count { get; } = new ReactivePropertySlim<int>(0);

		// カウントアップコマンド
		public IRelayCommand IncrementCountCommand { get; }

		private readonly CompositeDisposable disposable = new CompositeDisposable();

		public MainViewModel()
		{
			Sum = Number1.CombineLatest(Number2, (n1, n2) => n1 + n2).ToReadOnlyReactiveProperty().AddTo(disposable);

			// コマンドの初期化
			IncrementCountCommand = new RelayCommand(IncrementCount);
		}


		private void IncrementCount()
		{
			Count.Value++;
		}

		public void Dispose() => disposable.Dispose();
	}
}
