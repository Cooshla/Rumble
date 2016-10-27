using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using Xamarin;
using RumbleApp.Core.Interfaces;

namespace RumbleApp.Core.Services
{
	public class NavigationService : INavigationService
	{
		public INavigation Navi { get; internal set; }
		public Page myPage { get; set; }


		public Task<Page> PopAsync()
		{
			try{
			return Navi.PopAsync();
			}
			catch(Exception ex) {
				Insights.Report (ex);
				return null;
			}
		}

		public Task<Page> PopModalAsync()
		{
			try{
			if(Navi.ModalStack.Count>0)
				return Navi.PopModalAsync();
			else 
					return null;
			}
			catch(Exception ex) {
				Insights.Report (ex);
				return null;
			}
		}

		public Task PopToRootAsync()
		{
			try{
			return Navi.PopToRootAsync();
			}
			catch(Exception ex) {
				Insights.Report (ex);
				return null;
			}
		}

		public async Task PushAsync(Page page)
		{
            await Navi.PushAsync(page);
		}


		public async Task PushModalAsync(Page page)
		{
            await Navi.PushModalAsync(page);
		}

		public Task<bool> DisplayAlert(string title, string message, string accept, string cancel = null)
		{
			try {
				return myPage.DisplayAlert (title, message, accept, cancel);
			} catch (Exception ex) {
				Insights.Report (ex);
				return null;
			}
		}


		public Task DisplayOkAlert(string title, string message, string accept)
		{
			try {
				return myPage.DisplayAlert (title, message, accept);
			} catch (Exception ex) {
				Insights.Report (ex);
				return null;
			}
		}
 
		public Task<Page> PopAsync(bool animated)
		{
            return Navi.PopAsync(animated);
		}

		public Task<Page> PopModalAsync(bool animated)
		{ 
			return Navi.PopModalAsync(animated); 
		}

		public async Task PopToRootAsync(bool animated)
		{
		    await Navi.PopToRootAsync(animated);
		}

		public async Task PushAsync(Page page, bool animated)
		{
		    await Navi.PushAsync(page,animated);

		}

		public async Task PushModalAsync(Page page, bool animated)
		{
            await Navi.PushModalAsync(page, animated);
		}



		public void RemovePage (Page page)
		{
			Navi.RemovePage (page);
		}
		public void InsertPageBefore (Page page, Page before)
		{
			Navi.InsertPageBefore (page, before);
		}

		public System.Collections.Generic.IReadOnlyList<Page> NavigationStack {
			get {
				return Navi.NavigationStack;
			}
		}
		public System.Collections.Generic.IReadOnlyList<Page> ModalStack {
			get {
				return Navi.ModalStack;
			}
		}

	}
}

