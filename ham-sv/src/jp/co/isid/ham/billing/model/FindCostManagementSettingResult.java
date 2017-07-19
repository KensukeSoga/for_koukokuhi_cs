package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 制作費設定検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCostManagementSettingResult extends AbstractServiceResult {

    /** 請求グループマスタ */
    private List<Mbj26BillGroupVO> _billGroupList;

    /** 制作費取込データ */
    private List<FindCostManagementCaptureVO> _findCMCaptureList;

    /** 制作費車種データ */
    private List<FindCostManagementCarVO> _findCMCarList;

    /** 制作費車種出力設定データ */
    private List<FindCostManagementCaroutctrlVO> _findCMCaroutctrlList;

    /** 制作費データ(出力オプション以外) */
    private List<FindCostManagementExceptOptVO> _findCMExceptOptList;

    /** 変更確認用データ */
    private List<FindAfterUptakeCheckVO> _findAUCheckList;

    /** セキュリティInfo */
    private List<SecurityInfoVO> _secinfo;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _funcinfo;


    /**
     * 請求グループマスタデータ取得
     *
     * @return 請求グループマスタ
     */
    public List<Mbj26BillGroupVO> getBillGroup() {
        return _billGroupList;
    }

    /**
     * 請求グループマスタデータ設定
     *
     * @param billGroupList 請求グループマスタ
     */
    public void setBillGroup(List<Mbj26BillGroupVO> billGroupList) {
        _billGroupList = billGroupList;
    }

    /**
     * 制作費取込データ取得
     *
     * @return 制作費取込データ
     */
    public List<FindCostManagementCaptureVO> getFindCMCapture() {
        return _findCMCaptureList;
    }

    /**
     * 制作費取込データ設定
     *
     * @param findCmcList 制作費取込データ
     */
    public void setFindCMCapture(List<FindCostManagementCaptureVO> findCmcaptureList) {
        _findCMCaptureList = findCmcaptureList;
    }

    /**
     * 制作費車種データ取得
     *
     * @return 制作費取込データ
     */
    public List<FindCostManagementCarVO> getFindCMCar() {
        return _findCMCarList;
    }

    /**
     * 制作費車種データ設定
     *
     * @param findCmcList 制作費取込データ
     */
    public void setFindCMCar(List<FindCostManagementCarVO> findCmcarList) {
        _findCMCarList = findCmcarList;
    }

    /**
     * 制作費車種出力設定データ取得
     *
     * @return 制作費車種出力設定データ
     */
    public List<FindCostManagementCaroutctrlVO> getFindCMCaroutctrl() {
        return _findCMCaroutctrlList;
    }

    /**
     * 制作費車種出力設定データ設定
     *
     * @param findCmcaroutctrlList 制作費車種出力設定データ
     */
    public void setFindCMCaroutctrl(List<FindCostManagementCaroutctrlVO> findCMCaroutctrlList) {
        _findCMCaroutctrlList = findCMCaroutctrlList;
    }

    /**
     * 制作費データ(出力オプション以外)取得
     *
     * @return 制作費データ(出力オプション以外)
     */
    public List<FindCostManagementExceptOptVO>  getFindCMExceptOpt() {
        return _findCMExceptOptList;
    }

    /**
     * 制作費データ(出力オプション以外)設定
     *
     * @param findCMExceptOptList 制作費データ(出力オプション以外)
     */
    public void setFindCMExceptOpt(List<FindCostManagementExceptOptVO> findCMExceptOptList) {
        _findCMExceptOptList = findCMExceptOptList;
    }

    /**
     * 変更確認用データ取得
     *
     * @return 変更確認用データ
     */
    public List<FindAfterUptakeCheckVO>  getFindAUCheck() {
        return _findAUCheckList;
    }

    /**
     * 変更確認用データ設定
     *
     * @param findAUCheckList 変更確認用データ
     */
    public void setFindAUCheck(List<FindAfterUptakeCheckVO> findAUCheckList) {
        _findAUCheckList = findAUCheckList;
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
}
