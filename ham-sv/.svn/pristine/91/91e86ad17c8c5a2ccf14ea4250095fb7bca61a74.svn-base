package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj20CarCategoryVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 素材一覧Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・HDX対応(2016/02/29 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 *
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialListResult extends AbstractServiceResult {

    /**
     * コードマスタリスト変数
     */
    private List<Mbj12CodeVO> _codeList = null;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _functionControlInfoVoList = null;

    /** セキュリティ情報 */
    private List<SecurityInfoVO> _securityInfoVoList = null;

    /**
     * カテゴリマスタリスト変数
     */
    private List<Mbj20CarCategoryVO> _cateList = null;

    /**
     * 車種マスタリスト変数
     */
    private List<MaterialCarMstVO> _carList = null;

    /**
     * 画面項目表示列制御マスタ
     */
    private List<Mbj37DisplayControlVO> _mbj37DisplayControlVoList = null;

    /**
     * 画面項目表示列制御テーブル
     */
    private List<Tbj30DisplayPatternVO> _tbj30DisplayPatternVoList = null;

    /**
     * 素材情報リスト変数
     */
    private List<MaterialListVO> _materialList = null;

    /**
     * 素材登録リスト変数
     */
    private List<MaterialListVO> _materialRegistList = null;

    /**
     * 契約情報リスト変数
     */
    private List<MaterialListCntrctVO> _cntrctList = null;

    /**
     * 素材一覧ログリスト変数
     */
    private List<LogMaterialListVO> _materialLogList = null;

    /* 2016/02/29 HDX対応 HLC K.Soga ADD Start */
    /**
     * 車種担当者情報リスト変数
     */
    private List<SzTntUserListVO> _szTntUserList = null;

    /**
     * セキュリティグループユーザー(HC/HM)情報リスト変数
     */
    private List<HCHMSecGrpUserVO> _hchmSecGrpUserList = null;
    /* 2016/02/29 HDX対応 HLC K.Soga ADD End */

    /**
     * コードマスタリストを設定します
     * @param val コードマスタリスト
     */
    public void setCodeList(List<Mbj12CodeVO> val) {
        _codeList = val;
    }

    /**
     * コードマスタリストを取得します
     * @return コードマスタリスト
     */
    public List<Mbj12CodeVO> getCodeList() {
        return _codeList;
    }

    /**
     * 車種マスタリストを設定します
     * @param val 車種マスタリスト
     */
    public void setCarList(List<MaterialCarMstVO> val) {
        _carList = val;
    }

    /**
     * 車種マスタリストを取得します
     * @return 車種マスタリスト
     */
    public List<MaterialCarMstVO> getCarList() {
        return _carList;
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
     * カテゴリマスタリストを設定します
     * @param val
     */
    public void setCategoryList(List<Mbj20CarCategoryVO> val) {
        _cateList = val;
    }

    /**
     * カテゴリマスタリストを取得します
     * @param val
     */
    public List<Mbj20CarCategoryVO> getCategoryList() {
        return _cateList;
    }

    /**
     * 画面項目表示列制御マスタVOリストを設定する
     * @param mbj30InputTntVoList 画面項目表示列制御マスタVOリスト
     */
    public void setMbj37DisplayControlVoList(List<Mbj37DisplayControlVO> val) {
        this._mbj37DisplayControlVoList = val;
    }

    /**
     * 画面項目表示列制御マスタVOリストを取得する
     * @return 画面項目表示列制御マスタVOリスト
     */
    public List<Mbj37DisplayControlVO> getMbj37DisplayControlVoList() {
        return _mbj37DisplayControlVoList;
    }

    /**
     * 一覧表示パターンVOリストを設定する
     * @param val 一覧表示パターンVOリスト
     */
    public void setTbj30DisplayPatternVoList(List<Tbj30DisplayPatternVO> val) {
        this._tbj30DisplayPatternVoList = val;
    }


    /**
     * 一覧表示パターンVOリストを取得する
     * @return 一覧表示パターンVOリスト
     */
    public List<Tbj30DisplayPatternVO> getTbj30DisplayPatternVoList() {
        return _tbj30DisplayPatternVoList;
    }

    /**
     * 素材情報リストを設定します
     * @param val 素材情報リスト
     */
    public void setMaterialList(List<MaterialListVO> val) {
        _materialList = val;
    }

    /**
     * 素材情報リストを取得します
     * @return 素材情報リスト
     */
    public List<MaterialListVO> getMaterialList() {
        return _materialList;
    }

    /**
     * 素材登録リストを設定します
     * @param val 素材登録リスト
     */
    public void setMaterialRegistList(List<MaterialListVO> val) {
        _materialRegistList = val;
    }

    /**
     * 素材登録リストを取得します
     * @return 素材登録リスト
     */
    public List<MaterialListVO> getMaterialRegistList() {
        return _materialRegistList;
    }

    /**
     * 契約情報を設定します
     * @param val 契約情報リスト
     */
    public void setCntrctList(List<MaterialListCntrctVO> val) {
        _cntrctList = val;
    }

    /**
     * 契約情報リストを取得します
     * @return 契約情報リスト
     */
    public List<MaterialListCntrctVO> getCntrctList() {
        return _cntrctList;
    }

    /**
     * 素材一覧ログリストを設定します
     * @param val
     */
    public void setMaterialListLogList(List<LogMaterialListVO> val) {
        _materialLogList = val;
    }

    /**
     * 素材一覧ログリストを取得します
     * @return
     */
    public List<LogMaterialListVO> getMaterialListLogList() {
        return _materialLogList;
    }

    /* 2016/02/29 HDX対応 HLC K.Soga ADD Start */
    /**
     * 車種担当者情報リストを設定します
     * @param val 車種担当者情報リスト
     */
    public void setSzTntUserList(List<SzTntUserListVO> val) {
        _szTntUserList = val;
    }

    /**
     * 車種担当者情報リストを取得します
     * @return 車種担当者情報リスト変数
     */
    public List<SzTntUserListVO> getSzTntUserList() {
        return _szTntUserList;
    }

    /**
     * セキュリティグループユーザー(HC/HM)情報リストを設定します
     * @param val セキュリティグループユーザー(HC/HM)情報リスト
     */
    public void setHCHMSecGrpUserList(List<HCHMSecGrpUserVO> val) {
        _hchmSecGrpUserList = val;
    }

    /**
     * セキュリティグループユーザー(HC/HM)情報リストを取得します
     * @return セキュリティグループユーザー(HC/HM)情報リスト変数
     */
    public List<HCHMSecGrpUserVO> getHCHMSecGrpUserList() {
        return _hchmSecGrpUserList;
    }
    /* 2016/02/29 HDX対応 HLC K.Soga ADD End */
}
