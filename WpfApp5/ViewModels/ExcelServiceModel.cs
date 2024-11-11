using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace WpfApp5.ViewModels
{
    class ExcelServiceModel : BaseServiceModel
	{
		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="serviceName">機能名</param>
		public ExcelServiceModel(string serviceName) : base(serviceName) { }
		#endregion

		#region publicメソッド
		/// <summary>
		/// 実行
		/// </summary>
		public void Execute()
        {
            this.Result.Value = "終わった";
            this.StatusImage.Value = ChangeStatus(Statuses.Processing);
        }
		#endregion
	}
}
