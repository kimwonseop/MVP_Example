using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyView : MonoBehaviour, View {

    private Presenter presenter;
    
    private Button _Button_Create;
    private Button _Button_Delete;

    private List<GameObject> _trophyImageList = new List<GameObject>();

    private Text _Text_TrophytCount;
    
    private Transform _Transform_TrophyView;
    private GameObject _GameObject_Trophy;

    public void Awake() {
        LinkComponents();
        LinkEvents();
        RegisterPresenter();
    }

    public void LinkComponents() {
        transform.LinkComponent("Layout_Button/Button_Create", ref _Button_Create);
        transform.LinkComponent("Layout_Button/Button_Delete", ref _Button_Delete);
        transform.LinkComponent("Grid_Trophy", ref _Transform_TrophyView);
        transform.LinkComponent("TrophyCount/Count", ref _Text_TrophytCount);
        transform.LinkGameObject("Image_Trophy", ref _GameObject_Trophy);
    }

    public void LinkEvents() {
        _Button_Create.onClick.AddListener(OnClickAddButton);
        _Button_Delete.onClick.AddListener(OnClickDeleteButton);
    }

    public void OnClickAddButton() {
        GameObject CopiedImage = Instantiate(_GameObject_Trophy, _Transform_TrophyView);
        CopiedImage.SetActive(true);

        _trophyImageList.Add(CopiedImage);

        NotifyToPresenter();
    }

    public void OnClickDeleteButton() {
        int count = _trophyImageList.Count;

        if (count < 1) {
            return;
        }

        GameObject CopiedImage = _trophyImageList[count-1];
        _trophyImageList.Remove(CopiedImage);
        Destroy(CopiedImage);

        NotifyToPresenter();
    }

    public int GetChildCount() {
        int childCount = _trophyImageList.Count;
        return childCount;
    }

    public void RegisterPresenter() {
        presenter = new TrophyPresenter(this);
    }

    public void RemovePresenter() {
        presenter = null;
    }

    public void NotifyToPresenter() {
        presenter.UpdateModel();
    }


    public void SetTotalCount(string count) {
        _Text_TrophytCount.text = count;
    }
}
