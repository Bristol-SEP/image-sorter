using System.Collections.Generic;
using app.Model;
using app.Views.Popup;

namespace app.ViewModels.Interfaces.Popup;

public interface IPopupMainPageViewModel
{
    /// <summary>
    /// A <see cref="FeatureGroup"/> used in folder adding
    /// within the <see cref="PopupMainPageView"/>
    /// </summary>
    public FeatureGroup FeatureGroup { get; }
}