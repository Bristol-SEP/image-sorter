using System;
using System.Collections.Generic;
using app.Model;
using app.ViewModels;
using app.ViewModels.Interfaces;
using app.ViewModels.Interfaces.Popup;
using app.ViewModels.Popup;
using Image_Sorter_UI.Mock.ViewModels;
using NUnit.Framework;

namespace Image_Sorter_UI.ViewModels.Popup;

[TestFixture]
public class PopupMainPageViewModelTest
{
   private readonly IViewModelProvider _vmProvider = new MockViewModelProvider();
   
   [Test]
   public void SetupTest()
   {
      // Setup
      var folderViewModel = _vmProvider.GetFolderStructureViewModel();
      var featureGroup = new FeatureGroup("TestGroup", new List<Feature>()
      {
         new("test", new ViewModelBase()),
         new("test2", new ViewModelBase()),
      });
      var featureGroup2 = new FeatureGroup("TestGroup2", new List<Feature>()
      {
         new("test3", new ViewModelBase()),
         new("test4", new ViewModelBase())
      });
      var featureGroupList = new List<FeatureGroup>() { featureGroup, featureGroup2};
      // No selected feature groups
      IPopupMainPageViewModel viewModel = new PopupMainPageViewModel(featureGroupList, folderViewModel);
      Assert.Multiple(() =>
      {
         Assert.That(viewModel.FeatureGroup, Is.Empty);
         Assert.That(viewModel.FolderView, Is.EqualTo(folderViewModel));
      });
      // One feature group selected
      featureGroup2.Features[0].ToggleSelected();
      featureGroupList = new List<FeatureGroup>() { featureGroup, featureGroup2 };
      viewModel = new PopupMainPageViewModel(featureGroupList, folderViewModel);
      Assert.Multiple(() =>
      {
         Assert.That(viewModel.FeatureGroup.Count, Is.EqualTo(1));
         Assert.That(viewModel.FeatureGroup[0].Name, Is.EqualTo("test3"));
         Assert.That(viewModel.FolderView, Is.EqualTo(folderViewModel));
      });
      // Two features of group selected
      featureGroup2.Features[1].ToggleSelected();
      featureGroupList = new List<FeatureGroup>() { featureGroup, featureGroup2 };
      viewModel = new PopupMainPageViewModel(featureGroupList, folderViewModel);
      Assert.Multiple(() =>
      {
         Assert.That(viewModel.FeatureGroup.Count, Is.EqualTo(2));
         Assert.That(viewModel.FeatureGroup[0].Name, Is.EqualTo("test3"));
         Assert.That(viewModel.FeatureGroup[1].Name, Is.EqualTo("test4"));
         Assert.That(viewModel.FolderView, Is.EqualTo(folderViewModel));
      });
   }

   [Test]
   public void ChooseFeatureTest()
   {
      // Setup
      var folderViewModel = _vmProvider.GetFolderStructureViewModel();
      var featureGroup = new FeatureGroup("TestGroup", new List<Feature>()
      {
         new("test", new ViewModelBase()),
         new("test2", new ViewModelBase()),
      });
      featureGroup.Features[0].ToggleSelected();
      var featureGroupList = new List<FeatureGroup>() { featureGroup };
      IPopupMainPageViewModel viewModel = new PopupMainPageViewModel(featureGroupList, folderViewModel);
      viewModel.ChooseFeature(viewModel.FeatureGroup[0].View); 
      Assert.That(folderViewModel.View, Is.EqualTo(viewModel.FeatureGroup[0].View));
   }
   
   [Test]
   public void BackToMainTest()
   {
      // Setup
      var folderViewModel = _vmProvider.GetFolderStructureViewModel();
      var featureGroup = new FeatureGroup("TestGroup", new List<Feature>()
      {
         new("test", new ViewModelBase()),
         new("test2", new ViewModelBase()),
      });
      featureGroup.Features[0].ToggleSelected();
      var featureGroupList = new List<FeatureGroup>() { featureGroup };
      IPopupMainPageViewModel viewModel = new PopupMainPageViewModel(featureGroupList, folderViewModel);
      viewModel.BackToMain();
      Assert.That(folderViewModel.View, Is.EqualTo(viewModel));
      viewModel.ChooseFeature(viewModel.FeatureGroup[0].View); 
      Assert.That(folderViewModel.View, Is.EqualTo(viewModel.FeatureGroup[0].View));
      viewModel.BackToMain();
      Assert.That(folderViewModel.View, Is.EqualTo(viewModel));
   }

   [Test]
   public void ClosePopupTest()
   {
      // Setup
      var folderViewModel = _vmProvider.GetFolderStructureViewModel();
      IPopupMainPageViewModel viewModel = new PopupMainPageViewModel(new List<FeatureGroup>(), folderViewModel);
      folderViewModel.ShowPopup = true;
      Assert.That(folderViewModel.ShowPopup, Is.True);
      viewModel.ClosePopup();
      Assert.That(folderViewModel.ShowPopup, Is.False);
   }

   [Test]
   public void ReturnTest()
   {
      // Setup
      var folderViewModel = _vmProvider.GetFolderStructureViewModel();
      var viewModel = new PopupMainPageViewModel(new List<FeatureGroup>(), folderViewModel);
      Assert.Throws<NotSupportedException>((() => viewModel.Return()));
   }
   
   [Test]
   public void CloseTest()
   {
      // Setup
      var folderViewModel = _vmProvider.GetFolderStructureViewModel();
      var viewModel = new PopupMainPageViewModel(new List<FeatureGroup>(), folderViewModel);
      folderViewModel.ShowPopup = true;
      Assert.That(folderViewModel.ShowPopup, Is.True);
      viewModel.Close();
      Assert.That(folderViewModel.ShowPopup, Is.False);
      
   }
}