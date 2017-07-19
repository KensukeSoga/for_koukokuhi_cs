package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj05CarVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 契約情報登録画面起動時データ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * ・JASRAC対応(2015/12/03 HLC S.Fujimoto)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractRegisterResult extends AbstractServiceResult {

    /* =============================================================================================*/
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        _dummy = dummy;
    }
    /* =============================================================================================*/

    /** コードマスタVOリスト */
    private List<Mbj12CodeVO> _mbj12CodeVOList = null;

    /** 車種マスタVOリスト */
    private List<Mbj05CarVO> _mbj05CarVOList = null;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _functionControlInfoVoList = null;

    /** セキュリティ情報 */
    private List<SecurityInfoVO> _securityInfoVoList = null;

    /** 契約情報テーブルVOリスト */
    private List<Tbj16ContractInfoVO> _tbj16ContractInfoVOList = null;

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _mbj37DisplayControlVoList = null;

    /**
     * 画面項目表示列制御テーブル
     */
    private List<Tbj30DisplayPatternVO> _tbj30DisplayPatternVoList = null;

    /** 使用素材表示用(タレント・ナレーター)データVOリスト */
    private List<FindUseMaterialVO> _findUseMaterialTalentVOList = null;

    /** 使用素材表示用データ(楽曲)VOリスト */
    private List<FindUseMaterialVO> _findUseMaterialMusicVOList = null;

    /** カテゴリ(使用素材)用リストの設定値*/
    private List<Tbj18SozaiKanriDataVO> _categoryList = null;
    /** 秒数(使用素材)用リストの設定値*/
    private List<Tbj18SozaiKanriDataVO> _secondList = null;
    /** 車種担当(使用素材)用リストの設定値*/
    private List<Tbj18SozaiKanriDataVO> _syatanList = null;

    /* 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD Start */
    /** ラジオ番組割付済み素材情報 */
    private List<Tbj18SozaiKanriDataVO> _rdPgmMaterialList = null;
    /* 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD End */
    /**
     * コードマスタVOリストを取得する
     * @return コードマスタVOリスト
     */
    public List<Mbj12CodeVO> getMbj12CodeVOList() {
        return _mbj12CodeVOList;
    }

    /**
     * コードマスタVOリストを設定する
     * @param mbj12CodeVOList コードマスタVOリスト
     */
    public void setMbj12CodeVOList(List<Mbj12CodeVO> mbj12CodeVOList) {
        _mbj12CodeVOList = mbj12CodeVOList;
    }

    /**
     * 車種マスタVOリストを取得する
     * @return 車種マスタVOリスト
     */
    public List<Mbj05CarVO> getMbj05CarVOList() {
        return _mbj05CarVOList;
    }

    /**
     * 車種マスタVOリストを設定する
     * @param mbj05CarVOList 車種マスタVOリスト
     */
    public void setMbj05CarVOList(List<Mbj05CarVO> mbj05CarVOList) {
        _mbj05CarVOList = mbj05CarVOList;
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
     * 契約情報テーブルVOリストを取得する
     * @return 契約情報テーブルVOリスト
     */
    public List<Tbj16ContractInfoVO> getTbj16ContractInfoVOList() {
        return _tbj16ContractInfoVOList;
    }

    /**
     * 契約情報テーブルVOリストを設定する
     * @param tbj16ContractInfoVOList 契約情報テーブルVOリスト
     */
    public void setTbj16ContractInfoVOList(List<Tbj16ContractInfoVO> tbj16ContractInfoVOList) {
        _tbj16ContractInfoVOList = tbj16ContractInfoVOList;
    }

//	/**
//	 * コンテンツテーブルVOリストを取得する
//	 * @return コンテンツテーブルVOリスト
//	 */
//	public List<Tbj17ContentVO> getTbj17ContentVOList() {
//		return _tbj17ContentVOList;
//	}
//
//	/**
//	 * コンテンツテーブルVOリストを設定する
//	 * @param tbj17ContentVOList コンテンツテーブルVOリスト
//	 */
//	public void setTbj17ContentVOList(List<Tbj17ContentVO> tbj17ContentVOList) {
//		_tbj17ContentVOList = tbj17ContentVOList;
//	}

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
        _mbj37DisplayControlVoList = mbj37DisplayControlVoList;
    }

    /**
     * 一覧表示パターンVOリストを設定する
     * @param val 一覧表示パターンVOリスト
     */
    public void setTbj30DisplayPatternVoList(List<Tbj30DisplayPatternVO> val) {
        _tbj30DisplayPatternVoList = val;
    }

    /**
     * 一覧表示パターンVOリストを取得する
     * @return 一覧表示パターンVOリスト
     */
    public List<Tbj30DisplayPatternVO> getTbj30DisplayPatternVoList() {
        return _tbj30DisplayPatternVoList;
    }

    /**
     * 使用素材表示用(タレント・ナレーター)データを取得する
     * @return 使用素材表示用データVOリスト
     */
    public List<FindUseMaterialVO> getFindUseMaterialTalentVOList() {
        return _findUseMaterialTalentVOList;
    }

    /**
     * 使用素材表示用(タレント・ナレーター)データを設定する
     * @param findUseMaterialVOList 使用素材表示用データVOリスト
     */
    public void setFindUseMaterialTalentVOList(List<FindUseMaterialVO> findUseMaterialTalentVOList) {
        _findUseMaterialTalentVOList = findUseMaterialTalentVOList;
    }

    /**
     * 使用素材表示用(楽曲)データを取得する
     * @return 使用素材表示用データVOリスト
     */
    public List<FindUseMaterialVO> getFindUseMaterialMusicVOList() {
        return _findUseMaterialMusicVOList;
    }

    /**
     * 使用素材表示用(楽曲)データを設定する
     * @param findUseMaterialVOList 使用素材表示用データVOリスト
     */
    public void setFindUseMaterialMusicVOList(List<FindUseMaterialVO> findUseMaterialMusicVOList) {
        _findUseMaterialMusicVOList = findUseMaterialMusicVOList;
    }

    /**
     * カテゴリリスト用データを取得する
     * @return カテゴリリスト用データ
     */
    public List<Tbj18SozaiKanriDataVO> getCategoryList() {
        return _categoryList;
    }

    /**
     * カテゴリリスト用データを設定する
     * @param カテゴリリスト用データ
     */
    public void setCategoryList(List<Tbj18SozaiKanriDataVO> categoryList) {
        _categoryList = categoryList;
    }

    /**
     * 秒数リスト用データを取得する
     * @return 秒数リスト用データ
     */
    public List<Tbj18SozaiKanriDataVO> getSecondList() {
        return _secondList;
    }

    /**
     * 秒数リスト用データを設定する
     * @param 秒数リスト用データ
     */
    public void setSecondList(List<Tbj18SozaiKanriDataVO> secondList) {
        _secondList = secondList;
    }

    /**
     * 車種担当リスト用データを取得する
     * @return 車種担当リスト用データ
     */
    public List<Tbj18SozaiKanriDataVO> getSyatanList() {
        return _syatanList;
    }

    /**
     * 車種担当リスト用データを設定する
     * @param 車種担当リスト用データ
     */
    public void setSyatanList(List<Tbj18SozaiKanriDataVO> syatanList) {
        _syatanList = syatanList;
    }

    /* 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD Start */
    /**
     * ラジオ番組割付済み素材情報を取得する
     * @return List<Tbj38RdProgramMaterialVO> ラジオ番組割付済み素材情報
     */
    public List<Tbj18SozaiKanriDataVO> getRdPgmMaterialList() {
        return _rdPgmMaterialList;
    }

    /**
     * ラジオ番組割付済み素材情報を設定する
     * @param vo List<Tbj38RdProgramMaterilVO> ラジオ番組割付済み素材情報
     */
    public void setRdPgmMaterialList(List<Tbj18SozaiKanriDataVO> vo) {
        _rdPgmMaterialList = vo;
    }
    /* 2015/12/03 JASRAC対応 HLC S.Fujimoto ADD End */

}
