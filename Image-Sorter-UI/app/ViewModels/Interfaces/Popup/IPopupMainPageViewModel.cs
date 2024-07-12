using System.Collections.Generic;
using app.Model;
using app.Views.Popup;

namespace app.ViewModels.Interfaces.Popup;

public interface IPopupMainPageViewModel
{
    /// <summary>
    /// A <see cref="List{T}">list</see> of <see cref="Feature"/> used in folder adding
    /// within the <see cref="PopupMainPageView"/>
    /// </summary>
    public List<Feature> FeatureGroup { get; }
    
    /// <summary>
    /// Holds a reference to <see cref="FolderStructureDisplayViewModel"/>
    /// </summary>
    public IFolderStructureDisplayViewModel FolderView { get; }
    
    /// <summary>
    /// Returns the <see cref="ContextView"/> back to the <see cref="PopupMainPageView"/>
    /// </summary>
    public void BackToMain();
    
    /// <summary>
    /// Changes the popup to that of the
    /// selected feature
    /// </summary>
    public void ChooseFeature(ViewModelBase view);

    /// <summary>
    /// Makes the popup invisible
    /// </summary>
    public void ClosePopup();
}