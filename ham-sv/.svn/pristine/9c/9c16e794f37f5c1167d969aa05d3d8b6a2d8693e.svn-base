package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj01SysStsVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj15CrClassVO;
import jp.co.isid.ham.common.model.Mbj16CrExpenceVO;
import jp.co.isid.ham.common.model.Mbj17CrDivisionVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Mbj29SetteiKykVO;
import jp.co.isid.ham.common.model.Mbj30InputTntVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.Mbj41AlertDispControlWithUserVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.common.model.UserVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費　起動時データ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetIniDataForCostManageResult  extends AbstractServiceResult {

    /* =============================================================================================*/
//    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
//    private String _dummy;
//
//    /**
//     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
//     * @return String ダミープロパティ
//     */
//    public String getDummy() {
//        return _dummy;
//    }
//
//	/**
//	 * ListだけではWebサービスに公開されないのでダミープロパティを設定します
//	 * @param dummy ダミープロパティ
//	 */
//	public void setDummy(String dummy) {
//		this._dummy = dummy;
//	}
    /* =============================================================================================*/

    /** システム使用状況マスタVOリスト */
    private Mbj01SysStsVO _mbj01SysStsVo = null;

    /** 担当者マスタVOリスト */
    //private List<Mbj02UserVO> _mbj02UserVoList = null;
    private List<UserVO> _userVoList = null;

    /** 区分マスタVOリスト */
    private List<Mbj17CrDivisionVO> _mbj17CrDivisionVoList = null;

    /** 請求グループマスタVOリスト */
    private List<Mbj26BillGroupVO> _mbj26BillGroupVoList = null;

    /** 車種+権限マスタVOリスト */
    private List<CarListVO> _carListVoList = null;

    /** CR予算分類マスタVOリスト */
    private List<Mbj15CrClassVO> _mbj15CrClassVoList = null;

    /** CR予算費目マスタVOリスト */
    private List<Mbj16CrExpenceVO> _mbj16CrExpenceVoList = null;

    /** 設定局マスタVOリスト */
    private List<Mbj29SetteiKykVO> _mbj29SetteiKykVoList = null;

    /** 入力担当マスタVOリスト */
    private List<Mbj30InputTntVO> _mbj30InputTntVoList = null;

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _mbj37DisplayControlVoList = null;

    /** 一覧表示パターン */
    private List<Tbj30DisplayPatternVO> _tbj30DisplayPatternVoList = null;

    /** コードマスタ */
    private List<Mbj12CodeVO> _mbj12CodeVoList = null;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _functionControlInfoVoList = null;

    /** セキュリティ情報 */
    private List<SecurityInfoVO> _securityInfoVoList = null;

    /** アラート表示制御マスタ */
    private List<Mbj41AlertDispControlWithUserVO> _mbj41AlertDispControlVoList = null;

    /**
     * セキュリティ情報VOリストを取得します
     * @return セキュリティ情報VOリスト
     */
    public List<SecurityInfoVO> getSecurityInfoVoList()
    {
        return _securityInfoVoList;
    }

    /**
     * セキュリティ情報VOリストを設定します
     * @param securityInfoVoList セキュリティ情報VOリスト
     */
    public void setSecurityInfoVoList(List<SecurityInfoVO> securityInfoVoList)
    {
        _securityInfoVoList = securityInfoVoList;
    }

    /**
     * システム使用状況マスタVOリストを取得する
     * @return システム使用状況マスタVOリスト
     */
    public Mbj01SysStsVO getMbj01SysStsVo() {
        return _mbj01SysStsVo;
    }

    /**
     * システム使用状況マスタVOリストを設定する
     * @param mbj01SysStsVoList システム使用状況マスタVOリスト
     */
    public void setMbj01SysStsVo(Mbj01SysStsVO mbj01SysStsVo) {
        this._mbj01SysStsVo = mbj01SysStsVo;
    }

//    /**
//     * 担当者マスタVOリストを取得する
//     * @return 担当者マスタVOリスト
//     */
//    public List<Mbj02UserVO> getMbj02UserVoList() {
//        return _mbj02UserVoList;
//    }
//
//    /**
//     * 担当者マスタVOリストを設定する
//     * @param mbj17CrDivisionVoList 担当者マスタVOリスト
//     */
//    public void setMbj02UserVoList(List<Mbj02UserVO> mbj02UserVoList) {
//        this._mbj02UserVoList = mbj02UserVoList;
//    }
    /**
     * 担当者マスタVOリストを取得する
     * @return 担当者マスタVOリスト
     */
    public List<UserVO> getUserVoList() {
        return _userVoList;
    }

    /**
     * 担当者マスタVOリストを設定する
     * @param userVoList 担当者マスタVOリスト
     */
    public void setUserVoList(List<UserVO> userVoList) {
        this._userVoList = userVoList;
    }

    /**
     * 区分マスタVOリストを取得する
     * @return 区分マスタVOリスト
     */
    public List<Mbj17CrDivisionVO> getMbj17CrDivisionVoList() {
        return _mbj17CrDivisionVoList;
    }

    /**
     * 区分マスタVOリストを設定する
     * @param mbj17CrDivisionVoList 区分マスタVOリスト
     */
    public void setMbj17CrDivisionVoList(List<Mbj17CrDivisionVO> mbj17CrDivisionVoList) {
        this._mbj17CrDivisionVoList = mbj17CrDivisionVoList;
    }

    /**
     * 請求グループマスタVOリストを取得する
     * @return 請求グループマスタVOリスト
     */
    public List<Mbj26BillGroupVO> getMbj26BillGroupVoList() {
        return _mbj26BillGroupVoList;
    }

    /**
     * 請求グループマスタVOリストを設定する
     * @param mbj26BillGroupVoList 請求グループマスタVOリスト
     */
    public void setMbj26BillGroupVoList(List<Mbj26BillGroupVO> mbj26BillGroupVoList) {
        this._mbj26BillGroupVoList = mbj26BillGroupVoList;
    }

    /**
     * 車種+権限マスタVOリストを取得する
     * @return 車種+権限マスタVOリスト
     */
    public List<CarListVO> getCarListVoList() {
        return _carListVoList;
    }

    /**
     * 車種+権限マスタVOリストを設定する
     * @param carListVoList 車種マスタVOリスト
     */
    public void setCarListVoList(List<CarListVO> carListVoList) {
        this._carListVoList = carListVoList;
    }

    /**
     * CR予算分類マスタVOリストを取得する
     * @return CR予算分類マスタVOリスト
     */
    public List<Mbj15CrClassVO> getMbj15CrClassVoList() {
        return _mbj15CrClassVoList;
    }

    /**
     * CR予算分類マスタVOリストを設定する
     * @param mbj15CrClassVoList CR予算分類マスタVOリスト
     */
    public void setMbj15CrClassVoList(List<Mbj15CrClassVO> mbj15CrClassVoList) {
        this._mbj15CrClassVoList = mbj15CrClassVoList;
    }

    /**
     * CR予算費目マスタVOリストを取得する
     * @return CR予算費目マスタVOリスト
     */
    public List<Mbj16CrExpenceVO> getMbj16CrExpenceVoList() {
        return _mbj16CrExpenceVoList;
    }

    /**
     * CR予算費目マスタVOリストを設定する
     * @param mbj16CrExpenceVoList CR予算費目マスタVOリスト
     */
    public void setMbj16CrExpenceVoList(List<Mbj16CrExpenceVO> mbj16CrExpenceVoList) {
        this._mbj16CrExpenceVoList = mbj16CrExpenceVoList;
    }

    /**
     * 設定局マスタVOリストを取得する
     * @return 設定局マスタVOリスト
     */
    public List<Mbj29SetteiKykVO> getMbj29SetteiKykVoList() {
        return _mbj29SetteiKykVoList;
    }

    /**
     * 設定局マスタVOリストを設定する
     * @param mbj29SetteiKykVoList 設定局マスタVOリスト
     */
    public void setMbj29SetteiKykVoList(List<Mbj29SetteiKykVO> mbj29SetteiKykVoList) {
        this._mbj29SetteiKykVoList = mbj29SetteiKykVoList;
    }

    /**
     * 入力担当マスタVOリストを取得する
     * @return 入力担当マスタVOリスト
     */
    public List<Mbj30InputTntVO> getMbj30InputTntVoList() {
        return _mbj30InputTntVoList;
    }

    /**
     * 入力担当マスタVOリストを設定する
     * @param mbj30InputTntVoList 入力担当マスタVOリスト
     */
    public void setMbj30InputTntVoList(List<Mbj30InputTntVO> mbj30InputTntVoList) {
        this._mbj30InputTntVoList = mbj30InputTntVoList;
    }

    /**
     * 画面項目表示列制御マスタVOリストを取得する
     * @return 画面項目表示列制御マスタVOリスト
     */
    public List<Mbj37DisplayControlVO> getMbj37DisplayControlVoList() {
        return _mbj37DisplayControlVoList;
    }

    /**
     * 画面項目表示列制御マスタVOリストを設定する
     * @param mbj30InputTntVoList 画面項目表示列制御マスタVOリスト
     */
    public void setMbj37DisplayControlVoList(List<Mbj37DisplayControlVO> mbj37DisplayControlVoList) {
        this._mbj37DisplayControlVoList = mbj37DisplayControlVoList;
    }

    /**
     * 一覧表示パターンVOリストを取得する
     * @return 一覧表示パターンVOリスト
     */
    public List<Tbj30DisplayPatternVO> getTbj30DisplayPatternVoList() {
        return _tbj30DisplayPatternVoList;
    }

    /**
     * 一覧表示パターンVOリストを設定する
     * @param tbj30DisplayPatternVoList 一覧表示パターンVOリスト
     */
    public void setTbj30DisplayPatternVoList(List<Tbj30DisplayPatternVO> tbj30DisplayPatternVoList) {
        this._tbj30DisplayPatternVoList = tbj30DisplayPatternVoList;
    }

    /**
     * コードマスタVOリストを取得する
     * @return コードマスタVOリスト
     */
    public List<Mbj12CodeVO> getMbj12CodeVoList() {
        return _mbj12CodeVoList;
    }

    /**
     * コードマスタVOリストを設定する
     * @param mbj12CodeVoList コードマスタVOリスト
     */
    public void setMbj12CodeVoList(List<Mbj12CodeVO> mbj12CodeVoList) {
        this._mbj12CodeVoList = mbj12CodeVoList;
    }

    /**
     * 機能制御InfoVOリストを取得する
     * @return 機能制御InfoVOリスト
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _functionControlInfoVoList;
    }

    /**
     * 機能制御InfoVOリストを設定する
     * @param secinfo 機能制御InfoVOリスト
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> functionControlInfoVoList) {
        _functionControlInfoVoList = functionControlInfoVoList;
    }

    /**
     * アラート表示制御VOリストを取得します
     * @return アラート表示制御VOリスト
     */
    public List<Mbj41AlertDispControlWithUserVO> getMbj41AlertDispControlVoList()
    {
        return _mbj41AlertDispControlVoList;
    }

    /**
     * アラート表示制御VOリストを設定します
     * @param securityInfoVoList アラート表示制御VOリスト
     */
    public void setMbj41AlertDispControlVoList(List<Mbj41AlertDispControlWithUserVO> mbj41AlertDispControlVoList)
    {
        _mbj41AlertDispControlVoList = mbj41AlertDispControlVoList;
    }

}
