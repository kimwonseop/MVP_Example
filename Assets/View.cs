using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface View {
    void LinkComponents();
    void LinkEvents();

    void OnClickAddButton();
    void OnClickDeleteButton();

    void RegisterPresenter();
    void RemovePresenter();
    void NotifyToPresenter();

    void SetTotalCount(string count);
    int GetChildCount();
}
