package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

public class FindDispCostManagementReportResult  extends AbstractServiceResult{

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;

    /** セキュリティInfo */
    private List<SecurityInfoVO> _secinfo;


    /**
     * 機能制御InfoVOリストを取得する
     * @return 機能制御InfoVOリスト
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _funcinfo;
    }

    /**
     * 機能制御InfoVOリストを設定する
     * @param secinfo 機能制御InfoVOリスト
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> funcinfo) {
        _funcinfo = funcinfo;
    }

    /**
     * セキュリティInfoVOリストを取得する
     * @return セキュリティInfoVOリスト
     */
    public List<SecurityInfoVO> getSecurityInfoVoList() {
        return _secinfo;
    }

    /**
     * セキュリティInfoVOリストを設定する
     * @param secinfo セキュリティInfoVOリスト
     */
    public void setSecurityInfoVoList(List<SecurityInfoVO> secinfo) {
        _secinfo = secinfo;
    }

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
