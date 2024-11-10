using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace WpfApp5.ViewModels
{
    class ErrorServiceModel : BaseServiceModel
	{
		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="serviceName">機能名</param>
		public ErrorServiceModel(string serviceName) : base(serviceName) { }
		#endregion

		#region publicメソッド
		/// <summary>
		/// 実行
		/// </summary>
		public void Execute()
        {
            this.Result.Value = "エラーもどき";
            this.StatusImage.Value = ChangeStatus(Statuses.Error);
        }
		#endregion
	}
}
