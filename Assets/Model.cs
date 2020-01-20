using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model {
    private int _totalCount;

    public Model() {
        _totalCount = 0;
    }

    public int GetTotalCount() {
        Debug.Log("Total count : " + _totalCount);
        return _totalCount;
    }

    public void SetTotalCount(int count) {
        _totalCount = count;
    }
}

