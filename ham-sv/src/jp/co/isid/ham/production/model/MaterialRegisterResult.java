package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj05CarVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj32DepartmentVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj15CmCodeVO;
import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 素材登録Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・JASRAC対応(2015/11/19 HLC K.Soga)<BR>
 * ・HDX対応(2016/02/29 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 *
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialRegisterResult extends AbstractServiceResult {

    /**
     * 車種マスタリスト変数
     */
    private List<Mbj05CarVO> _carList = null;

    /**
     * コードマスタリスト変数
     */
    private List<Mbj12CodeVO> _codeList = null;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _functionControlInfoVoList = null;

    /** セキュリティ情報 */
    private List<SecurityInfoVO> _securityInfoVoList = null;

    /**
     * 部署マスタリスト変数
     */
    private List<Mbj32DepartmentVO> _depList = null;

    /**
     * 画面項目表示列制御マスタ
     */
    private List<Mbj37DisplayControlVO> _mbj37DisplayControlVoList = null;

    /**
     * 画面項目表示列制御テーブル
     */
    private List<Tbj30DisplayPatternVO> _tbj30DisplayPatternVoList = null;

    /**
     * 採番テーブルリスト変数
     */
    private List<Tbj15CmCodeVO> _cmCdList = null;

    /**
     * 素材情報リスト変数
     */
    private List<Tbj18SozaiKanriDataVO> _materialList = null;

    /**
     * 契約情報リスト変数
     */
    private List<MaterialRegisterCntrctVO> _cntrctList = null;

    /**
     * 素材情報ログリスト変数
     */
    private List<LogMaterialRegisterVO> _materialLogList = null;

    /**
     * CMコード発行書データリスト変数
     */
    private List<CmCodeIssueDocsVO> _cmCodeIssueDocsList = null;

    /**
     * 素材エンコード表データリスト変数
     */
    private List<MaterialEncodeListVO> _materialEncodeList = null;

    /**
     * カテゴリリスト変数
     */
    private List<Tbj16ContractInfoVO> _categoryList = null;

    /* 2015/10/14 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 仮素材情報リスト変数
     */
    private List<Tbj36TempSozaiKanriDataVO> _tempMaterialList = null;

    /**
     * 割付済み素材情報リスト変数
     */
    private List<Tbj18SozaiKanriDataVO> _rdProgramMaterialList = null;
    /* 2015/10/14 JASRAC対応 HLC K.Soga ADD End */

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
    public void setCarList(List<Mbj05CarVO> val) {
        _carList = val;
    }

    /**
     * 車種マスタリストを取得します
     * @return 車種マスタリスト
     */
    public List<Mbj05CarVO> getCarList() {
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
     * 部署マスタリストを設定します
     * @param val
     */
    public void setDepList(List<Mbj32DepartmentVO> val) {
        _depList = val;
    }

    /**
     * 　部署マスタリストを取得します
     * @return
     */
    public List<Mbj32DepartmentVO> getDepList() {
        return _depList;
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
     * 採番テーブルを設定します
     * @param val
     */
    public void setCmCdList(List<Tbj15CmCodeVO> val) {
        _cmCdList = val;
    }

    /**
     * 採番テーブルを取得します
     * @return
     */
    public List<Tbj15CmCodeVO> getCmCdList() {
        return _cmCdList;
    }

    /**
     * 契約情報を設定します
     * @param val 契約情報リスト
     */
    public void setCntrctList(List<MaterialRegisterCntrctVO> val) {
        _cntrctList = val;
    }

    /**
     * 契約情報リストを取得します
     * @return 契約情報リスト
     */
    public List<MaterialRegisterCntrctVO> getCntrctList() {
        return _cntrctList;
    }

    /**
     * 素材情報リストを設定します
     * @param val 素材情報リスト
     */
    public void setMaterialList(List<Tbj18SozaiKanriDataVO> val) {
        _materialList = val;
    }

    /**
     * 素材情報リストを取得します
     * @return 素材情報リスト
     */
    public List<Tbj18SozaiKanriDataVO> getMaterialList() {
        return _materialList;
    }

    /**
     * 素材情報ログリストを設定します
     * @param val
     */
    public void setMaterialRegisterLogList(List<LogMaterialRegisterVO> val) {
        _materialLogList = val;
    }

    /**
     * 素材情報ログリストを取得します
     * @return
     */
    public List<LogMaterialRegisterVO> getMaterialRegisterLogList() {
        return _materialLogList;
    }

    /**
     * CMコード発行書データリストを設定します
     * @param val CMコード発行書データリスト
     */
    public void setCmCodeIssueDocsVOList(List<CmCodeIssueDocsVO> val) {
        _cmCodeIssueDocsList = val;
    }

    /**
     * CMコード発行書データリストを取得します
     * @return CMコード発行書データリスト
     */
    public List<CmCodeIssueDocsVO> getCmCodeIssueDocsVOList() {
        return _cmCodeIssueDocsList;
    }

    /**
     * 素材エンコード表データリストを設定します
     * @param val 素材エンコード表データリスト
     */
    public void setMaterialEncodeList(List<MaterialEncodeListVO> val) {
        _materialEncodeList = val;
    }

    /**
     * 素材エンコード表データリストを取得します
     * @return 素材エンコード表データリスト
     */
    public List<MaterialEncodeListVO> getMaterialEncodeList() {
        return _materialEncodeList;
    }

    /**
     * カテゴリリストを設定します
     * @param val カテゴリリスト
     */
    public void setCategoryList(List<Tbj16ContractInfoVO> val) {
        _categoryList = val;
    }

    /**
     * カテゴリリストを取得します
     * @return カテゴリリスト
     */
    public List<Tbj16ContractInfoVO> getCategoryList() {
        return _categoryList;
    }

    /* 2015/10/14 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 仮素材情報リストを設定します
     * @param val 仮素材情報リスト
     */
    public void setTempMaterialList(List<Tbj36TempSozaiKanriDataVO> val) {
        _tempMaterialList = val;
    }

    /**
     * 仮素材情報リストを取得します
     * @return 仮素材情報リスト
     */
    public List<Tbj36TempSozaiKanriDataVO> getTempMaterialList() {
        return _tempMaterialList;
    }

    /**
     * 割付済み素材情報リストを設定します
     * @param val 割付済み素材情報リスト
     */
    public void setRdProgramMaterialList(List<Tbj18SozaiKanriDataVO> val) {
        _rdProgramMaterialList = val;
    }

    /**
     * 割付済み素材情報リストを取得します
     * @return 割付済み素材情報リスト
     */
    public List<Tbj18SozaiKanriDataVO> getRdProgramMaterialList() {
        return _rdProgramMaterialList;
    }
    /* 2015/10/14 JASRAC対応 HLC K.Soga ADD End */

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
