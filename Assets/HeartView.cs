using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartView : MonoBehaviour, View {

    private Presenter presenter;

    private Button _Button_Create;
    private Button _Button_Delete;

    private List<GameObject> _heartImageList = new List<GameObject>();

    private Text _Text_HeartCount;

    private Transform _Transform_HeartView;
    private GameObject _GameObject_Heart;

    public void Awake() {
        LinkComponents();
        LinkEvents();
        RegisterPresenter();
    }

    public void LinkComponents() {
        transform.LinkComponent("Layout_Button/Button_Create", ref _Button_Create);
        transform.LinkComponent("Layout_Button/Button_Delete", ref _Button_Delete);
        transform.LinkComponent("Grid_Heart", ref _Transform_HeartView);
        transform.LinkComponent("HeartCount/Count", ref _Text_HeartCount);
        transform.LinkGameObject("Image_Heart", ref _GameObject_Heart);
    }

    public void LinkEvents() {
        _Button_Create.onClick.AddListener(OnClickAddButton);
        _Button_Delete.onClick.AddListener(OnClickDeleteButton);
    }

    public void OnClickAddButton() {
        GameObject CopiedImage = Instantiate(_GameObject_Heart, _Transform_HeartView);
        CopiedImage.SetActive(true);

        _heartImageList.Add(CopiedImage);

        NotifyToPresenter();
    }

    public void OnClickDeleteButton() {
        int count = _heartImageList.Count;

        if(count < 1) {
            return;
        }

        GameObject CopiedImage = _heartImageList[count - 1];
        _heartImageList.Remove(CopiedImage);
        Destroy(CopiedImage);

        NotifyToPresenter();
    }

    public void RegisterPresenter() {
        presenter = new HeartPresenter(this);
    }

    public void RemovePresenter() {
        presenter = null;
    }

    public void NotifyToPresenter() {
        presenter.UpdateModel();
    }

    public int GetChildCount() {
        int childCount = _heartImageList.Count;
        return childCount;
    }

    public void SetTotalCount(string count) {
        _Text_HeartCount.text = count;
    }
}
