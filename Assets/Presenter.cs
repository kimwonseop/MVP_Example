using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Presenter {
    public abstract void UpdateModel();
    public abstract void SetView(View view);
}

public class HeartPresenter : Presenter {
    private View _heartView;
    private Model _heartModel;

    private int _count;

    public HeartPresenter(View view) {
        _heartModel = new Model();
        _heartView = view;
    }

    public override void UpdateModel() {
        _count = _heartView.GetChildCount();
        _heartModel.SetTotalCount(_count);

        _count = _heartModel.GetTotalCount();
        _heartView.SetTotalCount(_count.ToString());
    }

    public override void SetView(View view) {
        this._heartView = view;
    }
}

public class TrophyPresenter : Presenter {
    private View _trophyView;
    private Model _TrophyModel;

    private int _count;

    public TrophyPresenter(View view) {
        _TrophyModel = new Model();
        _trophyView = view;
    }

    public override void UpdateModel() {
        _count = _trophyView.GetChildCount();
        _TrophyModel.SetTotalCount(_count);

        _count = _TrophyModel.GetTotalCount();
        _trophyView.SetTotalCount(_count.ToString());
    }

    public override void SetView(View view) {
        this._trophyView = view;
    }
}
